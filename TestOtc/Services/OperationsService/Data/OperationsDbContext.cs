using OperationsService.Data.Entities;
using System.Data.Entity;

namespace OperationsService.Data
{
    public class OperationsDbContext: DbContext
    {
        public DbSet<DbBank> Banks { get; set; }
        public DbSet<DbInvoiceType> InvoiceTypes { get; set; }
        public DbSet<DbInvoice> Invoices { get; set; }
        public DbSet<DbMatrixInvoiceTypes> Matrices { get; set; }
        public DbSet<DbTransation> Transations { get; set; }

        public OperationsDbContext() : base("OperationsDbContext") { }
    }
}
