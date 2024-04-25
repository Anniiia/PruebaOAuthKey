using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaOAuthKey.Models
{
    [Table("USUARIOPRUEBA")]
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public int IdUsuairo { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("PASS")]
        public string Password { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
    }
}
