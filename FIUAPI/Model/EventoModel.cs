using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIUAPI.Model
{
    [Table("evento")]
    public class EventoModel
    {
        [Key]
        [Column("pk_eventoid")]
        public long? Id { get; private set; }
        [Column("nome")]
        [Required]
        [StringLength(200)]
        public string Nome { get; private set; }
        [Column("data")]
        [Required]
        public DateTime Data { get; private set; }

        public EventoModel(string Nome, DateTime Data)
        {
            this.Nome = Nome;
            this.Data = Data;
        }

        protected EventoModel() { }
    }
}
