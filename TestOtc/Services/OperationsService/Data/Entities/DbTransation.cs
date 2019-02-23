using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsService.Data.Entities
{
    [Table("Transations", Schema = "oper")]
    public class DbTransation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RecipientInvoiceId { get; set; }

        [Column("RecipientInvoiceId")]
        public virtual DbInvoice RecipientInvoice { get; set; }

        [Required]
        public Guid SenderInvoiceId { get; set; }

        [Column("SenderInvoiceId")]
        public virtual DbInvoice SenderInvoice { get; set; }

        [Required]
        public double Ammount { get; set; }

        [Required]
        public double TransferInterest { get; set; }

        [Required]
        public double BankInterest { get; set; }

        [Required]
        public DateTime TransferDate { get; set; }

        [Required]
        public Guid TransferUserId { get; set; }
    }
}
