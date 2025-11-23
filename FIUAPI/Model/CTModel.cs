using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("ct")]
    public class CTModel
    {
        [Key]
        [Column("pk_ctid")]
        public long? Id { get; private set; }

        [Column("nome")]
        [Required]
        [StringLength(200)]
        public string Nome { get; private set; }

        [Column("fk_equipeid")]
        [Required]
        public long EquipeId { get; private set; }

        [Column("fk_treinadorid")]
        [Required]
        public long TreinadorId { get; private set; }

        [ForeignKey("EquipeId")]
        [JsonIgnore]
        public virtual EquipeModel? Equipe { get; private set; }

        [ForeignKey("TreinadorId")]
        [JsonIgnore]
        public virtual TreinadorModel? Treinador { get; private set; }

        public CTModel(string Nome, long EquipeId, long TreinadorId)
        {
            this.Nome = Nome;
            this.EquipeId = EquipeId;
            this.TreinadorId = TreinadorId;
        }

        protected CTModel() { }
    }
}
