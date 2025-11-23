using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIUAPI.Model
{
    [Table("mestre")]
    [Index(nameof(Email), IsUnique = true)]
    public class MestreModel
    {
        [Key]
        [Column("pk_mestreid")]
        public long? Id { get; private set; }
        [Required]
        [StringLength(200)]
        [Column("nome")]
        public string Nome { get; private set; }
        [Required]
        [StringLength(200)]
        [Column("email")]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        [StringLength(255)]
        [Column("senha")]
        public string Senha { get; private set; }


        public MestreModel(string Nome, string Email, string Senha)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
        }

        protected MestreModel() { }
    }
}
