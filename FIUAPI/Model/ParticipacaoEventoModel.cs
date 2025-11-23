using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("participacao_evento")]
    public class ParticipacaoEventoModel
    {
        [Key]
        [Column("pk_participacaoeventoid")]
        public long? Id { get; private set; }
        [Column("fk_eventoid")]
        [Required]
        public long EventoId { get; private set; }
        [Column("fk_atletaid")]
        [Required]
        public long AtletaId { get; private set; }
        [Column("colocacao")]
        [Required]
        [StringLength(50)]
        public string Colocacao { get; private set; }

        [ForeignKey("EventoId")]
        [JsonIgnore]
        public virtual EventoModel? Evento { get; private set; }
        [ForeignKey("AtletaId")]
        [JsonIgnore]
        public virtual AtletaModel? Atleta { get; private set; } 


        public ParticipacaoEventoModel(long EventoId, long AtletaId, string Colocacao)
        {
            this.EventoId = EventoId;
            this.AtletaId = AtletaId;
            this.Colocacao = Colocacao;
        }
        protected ParticipacaoEventoModel() { }
    }
}
