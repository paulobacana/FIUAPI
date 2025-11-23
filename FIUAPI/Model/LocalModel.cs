using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("local")]
    public class LocalModel
    {
        [Key]
        [Column("pk_localid")]
        public long? Id { get; private set; }
        [Required]
        [Column("logradouro")]
        [StringLength(200)]
        public string Logradouro { get; private set; }
        [Required]
        [Column("bairro")]
        [StringLength(100)]
        public string Bairro { get; private set; }
        [Column("numero")]
        public int? Numero { get; private set; }
        [Required]
        [Column("cep")]
        [StringLength(8)]
        public string Cep { get; private set; }
        [Required]
        [Column("cidade")]
        [StringLength(50)]
        public string Cidade { get; private set; }
        [Required]
        [Column("uf")]
        [StringLength(2)]
        public string Uf { get; private set; }
        [Required]
        [Column("fk_eventoid")]
        public long EventoId { get; private set; }

        [ForeignKey("EventoId")]
        [JsonIgnore]
        public virtual EventoModel? Evento { get; private set; }

        public LocalModel(string Logradouro, string Bairro, int? Numero, string Cep, string Cidade, string Uf, long EventoId)
        {
            this.Logradouro = Logradouro;
            this.Bairro = Bairro;
            this.Numero = Numero;
            this.Cep = Cep;
            this.Cidade = Cidade;
            this.Uf = Uf;
            this.EventoId = EventoId;
        }
        protected LocalModel() { }
    }
}
