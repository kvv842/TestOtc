using OperationsService.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsService.Data.Entities
{
    [Table("Bank", Schema = "oper")]
    public class DbBank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public double InterestInternalTransfer { get; set; }

        [Required]
        public double InterestExternalTransfer { get; set; }

        [Required]
        public DbAdditionalActionsType AdditionalActionsType { get; set; }
    }
}
