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
               .Custom((r, context) =>
               {
                   if (r.RecipientInvoiceId == r.SenderInvoiceId)
                       context.AddFailure("Отправитель не может быть получателем.");

               });
        }

    }
}
