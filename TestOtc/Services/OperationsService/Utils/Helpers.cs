using NotificationService.Contracts.Dtos;
using OperationsService.Data;
using OperationsService.Data.Entities;
using OperationsService.Migrations;
using System.Collections.Generic;
using System.Data.Entity;

namespace OperationsService.Utils
{
    public static class Helpers
    {
        /// <summary>
        /// Инициализация БД
        /// </summary>
        public static void InitializerDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OperationsDbContext, Configuration>());
            var contexttest = new OperationsDbContext();
            contexttest.Database.Initialize(true);
        }

        /// <summary>
        /// Расчет комиссии за перевод.
        /// </summary>
        /// <param name="dbMatrixInvoiceTypes"></param>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public static decimal CalcTransferInterested(DbMatrixInvoiceTypes dbMatrixInvoiceTypes, decimal ammount)
        {
            var interested = CalcPercent(ammount, dbMatrixInvoiceTypes.Interest);

            return interested;
        }

        /// <summary>
        /// Расчет комиссии банка
        /// </summary>
        /// <param name="senderBank"></param>
        /// <param name="senderInvoice"></param>
        /// <param name="recipientInvoice"></param>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public static decimal CalcBankInterested(DbBank senderBank, DbInvoice senderInvoice, DbInvoice recipientInvoice, decimal ammount)
        {
            var percent = (IsInternalTransfer(senderInvoice, recipientInvoice))
                          ? senderBank.InterestInternalTransfer
                          : senderBank.InterestExternalTransfer;

            return CalcPercent(ammount, percent);
        }

        /// <summary>
        /// Внутренний ли перевод
        /// </summary>
        /// <param name="senderInvoice"></param>
        /// <param name="recipientInvoice"></param>
        /// <returns></returns>
        public static bool IsInternalTransfer(DbInvoice senderInvoice, DbInvoice recipientInvoice)
            => senderInvoice.BankId == recipientInvoice.BankId;

        /// <summary>
        /// Расчет процентов.
        /// </summary>
        /// <param name="ammount"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static decimal CalcPercent(decimal ammount, decimal percent)
            => ammount / 100 * percent;

        /// <summary>
        /// Создать уведомления
        /// </summary>
        /// <param name="senderInvoiceType"></param>
        /// <param name="senderBank"></param>
        /// <returns></returns>
        public static IList<Notification> CreateNotifications(DbInvoiceType senderInvoiceType, DbBank senderBank)
        {
            var result = new List<Notification>
            {
                new Notification
                {
                    Type = senderInvoiceType.AdditionalActionsType.ToString()
                },
                new Notification
                {
                    Type = senderBank.AdditionalActionsType.ToString()
                }
            };

            return result;
        }
    }
}
