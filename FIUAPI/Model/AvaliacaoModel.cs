using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("avaliacao")]
    public class AvaliacaoModel
    {
        [Key]
        [Column("pk_avaliacaoid")]
        public long? Id { get; private set; }
        [Column("descricao")]
        [Required]
        public string Descricao { get; private set; }
        [Column("nota", TypeName = "decimal(4,2)")]
        [Required]
        public decimal Nota { get; private set; }
        [Column("fk_equipeid")]
        [Required]
        public long EquipeId { get; private set; }

        [ForeignKey("EquipeId")]
        [JsonIgnore]
        public virtual EquipeModel? Equipe { get; private set; }

        public AvaliacaoModel(string Descricao, decimal Nota, long EquipeId)
        {
            this.Descricao = Descricao;
            this.Nota = Nota;
            this.EquipeId = EquipeId;
        }

        protected AvaliacaoModel() { }
    }
}
