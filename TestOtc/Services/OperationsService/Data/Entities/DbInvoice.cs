using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsService.Data.Entities
{
    [Table("Invoice", Schema = "oper")]
    public class DbInvoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Index("IX_oper_Invoice_Number", 1, IsUnique = true)]
        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        public Guid BankId { get; set; }

        public virtual DbBank Bank { get; set; }

        [Required]
        public Guid InvoiceTypeId { get; set; }

        [Column("InvoiceTypeId")]
        public virtual DbInvoiceType InvoiceType { get; set; }

        [Required]
        public double Ammount { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
