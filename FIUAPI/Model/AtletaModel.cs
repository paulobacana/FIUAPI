using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("atleta")]
    [Index(nameof(Email), IsUnique = true)]
    public class AtletaModel
    {
        [Key]
        [Column("pk_atletaid")]
        public long? Id { get; private set; }

        [Column("nome")]
        [Required]
        [StringLength(200)]
        public string Nome { get; private set; }

        [Column("email")]
        [Required]
        [StringLength(155)]
        [EmailAddress]
        public string Email { get; private set; }

        [Column("password")]
        [StringLength(255)]
        [Required]
        public string Password { get; private set; }

        [Column("fk_faixaid")]
        [Required]
        public long FaixaId{ get; private set; }

        [Column("fk_ctid")]
        [Required]
        public long CtId { get; private set; }


        [ForeignKey("FaixaId")]
        [JsonIgnore]
        public virtual FaixaModel? Faixa { get; private set; }

        [ForeignKey("CtId")]
        [JsonIgnore]
        public virtual CTModel? Ct { get; private set; }

        public AtletaModel(string Nome, string Email, string Password, long FaixaId, long CtId)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Password = Password;
            this.FaixaId = FaixaId;
            this.CtId = CtId;
        }

        protected AtletaModel(){}
    }
}
