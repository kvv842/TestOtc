namespace OperationsService.Migrations
{
    using global::OperationsService.Data;
    using global::OperationsService.Data.Entities;
    using global::OperationsService.Data.Entities.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OperationsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OperationsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Banks.Any())
            {
                // Banks
                var sberbank = new DbBank
                {
                    Id = Guid.Parse("{569E5810-82BD-498C-AB21-2E1E8593A7F0}"),
                    Name = "Сбербанк",
                    InterestInternalTransfer = 0,
                    InterestExternalTransfer = 1,
                    AdditionalActionsType = DbAdditionalActionsType.SendTransactionsTaxOffice
                };

                var vtbbank = new DbBank
                {
                    Id = Guid.Parse("{00C7DA8B-A7BE-446D-AD5F-E41AF650B576}"),
                    Name = "Втб",
                    InterestInternalTransfer = 0,
                    InterestExternalTransfer = 2,
                    AdditionalActionsType = DbAdditionalActionsType.SendTransactionPartnerBank
                };

                var alfabank = new DbBank
                {
                    Id = Guid.Parse("{264848B8-4782-4FC1-A265-D255CDE56911}"),
                    Name = "Альфабанк",
                    InterestInternalTransfer = 1,
                    InterestExternalTransfer = 2.5m,
                    AdditionalActionsType = DbAdditionalActionsType.DisplayWindowConfirmingOperation
                };

                var banks = new List<DbBank>
            {
                sberbank, vtbbank, alfabank
            };

                banks.ForEach(s => context.Banks.AddOrUpdate(p => p.Name, s));


                // DbInvoiceType
                var individual = new DbInvoiceType { Id = Guid.NewGuid(), Name = "Физическое лицо", };
                var legal = new DbInvoiceType { Id = Guid.NewGuid(), Name = "Юридическое лицо", };
                var nonresident = new DbInvoiceType { Id = Guid.NewGuid(), Name = "Нерезидент", };

                var invoiceTypes = new List<DbInvoiceType>
            {
                individual,
                legal,
                nonresident,
            };

                invoiceTypes.ForEach(s => context.InvoiceTypes.AddOrUpdate(p => p.Name, s));

                var matrix = new List<DbMatrixInvoiceTypes>
            {
                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{A538953A-169C-400D-B686-CEFD66FE9332}"), SenderTypeId = individual.Id, RecipientTypeId = individual.Id, Interest = 0 },
                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{1B829439-7FF2-46DA-95FC-0A4955F0E1E3}"), SenderTypeId = individual.Id, RecipientTypeId = legal.Id, Interest = 2 },
                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{8D42D820-26BF-49D2-9D40-399FFD48CB6C}"), SenderTypeId = individual.Id, RecipientTypeId = nonresident.Id, Interest = 4 },

                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{0401A91C-33CD-40ED-A667-EB29B47D1110}"), SenderTypeId = legal.Id, RecipientTypeId = individual.Id, Interest = 0 },
                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{776E4438-C0C1-47A5-B6BF-58277A00D021}"), SenderTypeId = legal.Id, RecipientTypeId = legal.Id, Interest = 3 },
                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{D192504D-5C29-47D8-97FC-DCE72E5B7F8E}"), SenderTypeId = legal.Id, RecipientTypeId = nonresident.Id, Interest = 6 },

                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{60121C40-3823-463A-9186-E307507C7A5C}"), SenderTypeId = nonresident.Id, RecipientTypeId = individual.Id, Interest = 0 },
                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{A32CCDDE-640D-4328-8914-665BE96B96B8}"),  SenderTypeId = nonresident.Id, RecipientTypeId = legal.Id, Interest = 4 },
                new DbMatrixInvoiceTypes{ Id = Guid.Parse("{C996F506-8453-487D-80FE-F41991041368}"), SenderTypeId = nonresident.Id, RecipientTypeId = nonresident.Id, Interest = 6 },
            };

                matrix.ForEach(s => context.Matrices.AddOrUpdate(p => p.Id, s));

                var invoices = new List<DbInvoice>
            {
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 1000,
                    Number = "58000000000000000001",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 1000,
                    Number = "58000000000000000002",
                },

                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 5000,
                    Number = "58000000000000000003",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000004",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000005",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000006",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000007",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000008",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000009",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000010",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000011",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000012",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000013",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000014",
                },
                new DbInvoice
                {
                    BankId = sberbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 2000,
                    Number = "58000000000000000015",
                },

                new DbInvoice
                {
                    BankId = vtbbank.Id,
                    InvoiceTypeId = individual.Id,
                    Ammount = 100000m,
                    Number = "68000000000000000001",
                },
                new DbInvoice
                {
                    BankId = vtbbank.Id,
                    InvoiceTypeId = nonresident.Id,
                    Ammount = 100000,
                    Number = "68000000000000000002",
                },

                new DbInvoice
                {
                    BankId = alfabank.Id,
                    InvoiceTypeId = legal.Id,
                    Ammount = 100000,
                    Number = "78000000000000000002",
                },
            };

                invoices.ForEach(s => context.Invoices.AddOrUpdate(p => p.Number, s));

                context.SaveChanges();
            }
        }
    }
}
