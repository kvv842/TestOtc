using FluentValidation;
using OperationsService.Contracts.Dtos;
using OperationsService.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace OperationsService.Validators
{
    public class TransferRequestValidator: AbstractValidator<TransferRequest>
    {
        private readonly OperationsDbContext operationsDbContext;

        public TransferRequestValidator(OperationsDbContext operationsDbContext)
        {
            this.operationsDbContext = operationsDbContext;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(a => a.Ammount)
                .NotEmpty().WithMessage("Не указана сумма перевода.")
                .GreaterThan(0).WithMessage("Сумма должна быть больше 0");

            RuleFor(a => a.SenderInvoiceId)
                .NotEmpty().WithMessage("Не указана отправитель.");

            RuleFor(a => a.RecipientInvoiceId)
                .NotEmpty().WithMessage("Не указана получатель.");

            RuleFor(r => r)
               .CustomAsync(async (r, context, ct) =>
               {
                   var recipientInvoice = await operationsDbContext.Invoices.FirstOrDefaultAsync(a => a.Id == r.RecipientInvoiceId);

                   if (recipientInvoice == null)
                       context.AddFailure("Получатель не найден.");

                   var senderInvoice = await operationsDbContext.Invoices.FirstOrDefaultAsync(a => a.Id == r.SenderInvoiceId);

                   if (senderInvoice == null)
                       context.AddFailure("Отправитель не найден.");

                   if (senderInvoice.Ammount < r.Ammount)
                       context.AddFailure("Недостаточно средств.");

               });
        }

    }
}
