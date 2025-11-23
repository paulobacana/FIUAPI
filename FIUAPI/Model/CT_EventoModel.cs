using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("ct_evento")]
    public class CT_EventoModel
    {
        [Key]
        [Column("pk_ct_eventoid")]
        public long? Id  { get; private set; }
        [Column("fk_eventoid")]
        [Required]
        public long EventoId  { get; private set; }
        [Column("fk_ctid")]
        [Required]
        public long CtId  { get; private set; }

        [ForeignKey("CtId")]
        [JsonIgnore]
        public virtual CTModel? Ct { get; private set; }

        [ForeignKey("EventoId")]
        [JsonIgnore]
        public virtual EventoModel? Evento { get; private set; }

        public CT_EventoModel(long EventoId, long CtId)
        {
            this.EventoId = EventoId;
            this.CtId = CtId;
        }

        protected CT_EventoModel() { }

    }
}
