using OperationsService.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsService.Data.Entities
{
    [Table("InvoiceType", Schema = "oper")]
    public class DbInvoiceType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public DbAdditionalActionsType AdditionalActionsType { get; set; }
}
}
