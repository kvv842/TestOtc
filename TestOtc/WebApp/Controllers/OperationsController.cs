using AutoMapper;
using OperationsService.Contracts;
using OperationsService.Contracts.Dtos;
using OperationsService.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApp.Models.Operations;

namespace WebApp.Controllers
{
    [Authorize]
    public class OperationsController : Controller
    {
        private readonly IOperationsService _operationsService;

        public OperationsController(IOperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        [ActionName("SenderInvoices")]
        public async Task<ActionResult> GetSenderInvoicesAsync(Guid id)
        {
            var invoices = await _operationsService.GetSenderInvoicesAsync(id);

            var invoicesViewModel = Mapper.Map<IEnumerable<InvoiceModel>>(invoices);

            return PartialView(invoicesViewModel);
        }

        [ActionName("RecipientInvoices")]
        public async Task<ActionResult> GetRecipientInvoicesAsync(Guid id, Guid senderInvoiceId)
        {
            var invoices = await _operationsService.GetRecipientInvoicesAsync(id, senderInvoiceId);

            var invoicesViewModel = Mapper.Map<IEnumerable<InvoiceModel>>(invoices);

            return PartialView(invoicesViewModel);
        }

        [ActionName("banks")]
        public async Task<ActionResult> GetBankAsync()
        {
            var banks = await _operationsService.GetBanksAsync();

            var banksViewModel = Mapper.Map<IEnumerable<BankModel>>(banks);

            return PartialView(banksViewModel);
        }

        [HttpPost]
        [ActionName("Transfer")]
        public async Task<ActionResult> TransferAsync(TransferModel transferModel)
        {
            if (ModelState.IsValid)
            {
                var transferRequest = Mapper.Map<TransferRequest>(transferModel);

                if (Guid.TryParse(HttpContext.User.Identity.Name, out Guid userId))
                {
                    try
                    {
                        await _operationsService.TransferAsync(transferRequest, userId);
                    }
                    catch (TransferException ex)
                    {
                        return Json(new { success = false, m = string.Join(",", ex.Messages) });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { success = false, m = ex.Message });
                    }

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            else
            {
                return Json(new { success = false });
            }
        }

        // GET: Operations
        public ActionResult Index()
        {
            return View();
        }
    }
}