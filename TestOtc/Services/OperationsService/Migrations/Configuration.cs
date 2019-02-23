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

            // Banks
            var banks = new List<DbBank>
            {
                new DbBank {
                    Name = "��������",
                    InterestInternalTransfer = 0,
                    InterestExternalTransfer = 1,
                    AdditionalActionsType = DbAdditionalActionsType.SendTransactionsTaxOffice
                },

                new DbBank {
                    Name = "���",
                    InterestInternalTransfer = 0,
                    InterestExternalTransfer = 2,
                    AdditionalActionsType = DbAdditionalActionsType.SendTransactionPartnerBank
                },

                new DbBank {
                    Name = "���������",
                    InterestInternalTransfer = 1,
                    InterestExternalTransfer = 2.5,
                    AdditionalActionsType = DbAdditionalActionsType.DisplayWindowConfirmingOperation
                },
            };

            banks.ForEach(s => context.Banks.AddOrUpdate(p => p.Name, s));


            // DbInvoiceType
            var individual = new DbInvoiceType { Id = Guid.NewGuid(), Name = "���������� ����", };
            var legal = new DbInvoiceType { Id = Guid.NewGuid(), Name = "����������� ����", };
            var nonresident = new DbInvoiceType { Id = Guid.NewGuid(), Name = "����������", };

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

            context.SaveChanges();
        }
    }
}