using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsService.Data.Entities
{
    [Table("MatrixInvoices", Schema = "oper")]
    public class DbMatrixInvoiceTypes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RecipientTypeId { get; set; }

        [Column("RecipientTypeId")]
        public virtual DbInvoiceType RecipientType { get; set; }

        [Required]
        public Guid SenderTypeId { get; set; }

        [Column("SenderTypeId")]
        public virtual DbInvoiceType SenderType { get; set; }

        [Required]
        public decimal Interest { get; set; }
    }
}
