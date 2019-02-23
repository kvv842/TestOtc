using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Data.Entities
{
    [Table("User", Schema = "auth")]
    public class DbUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Login { get; set; }

        [Required]
        [MaxLength(25)]
        public string Password { get; set; }
    }
}
