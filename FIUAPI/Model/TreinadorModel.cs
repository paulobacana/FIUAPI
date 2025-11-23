using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIUAPI.Model
{
    [Table("treinador")]
    [Index(nameof(Email), IsUnique = true)]
    public class TreinadorModel
    {
        [Key]
        [Column("pk_treinadorid")]
        public long? Id { get; private set; }
        [Required]
        [Column("nome")]
        [StringLength(200)]
        public string Nome { get; private set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        [Column("senha")]
        [StringLength(255)]
        public string Senha { get; private set; }


        public TreinadorModel(string Nome, string Email, string Senha)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
        }
        protected TreinadorModel() { }
    }
}
