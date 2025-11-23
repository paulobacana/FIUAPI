using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("relatorio")]
    public class RelatorioModel
    {
        [Key]
        [Column("pk_relatorioid")]
        public long? Id { get; private set; }
        [Required]
        [Column("descricao")]
        public string Descricao { get; private set; }
        [Required]
        [Column("data_criacao")]
        public DateTime DataCriacao { get; private set; }
        [Required]
        [Column("fk_treinadorid")]
        public long TreinadorId { get; private set; }

        [ForeignKey("TreinadorId")]
        [JsonIgnore]
        public virtual TreinadorModel? Treinador { get; private set; }


        public RelatorioModel(string Descricao, DateTime DataCriacao, long TreinadorId)
        {
            this.Descricao = Descricao;
            this.DataCriacao = DataCriacao;
            this.TreinadorId = TreinadorId;
        }
        protected RelatorioModel() { }
    }
}
