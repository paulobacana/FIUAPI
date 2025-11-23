using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("faixa")]
    public class FaixaModel
    {
        [Key]
        [Column("pk_faixaid")]
        public long? Id { get; private set; }
        [Required]
        [Column("cor")]
        [StringLength(20)]
        public string Cor { get; private set; }
        [Required]
        [Column("fk_modalidadeid")]
        public long ModalidadeId { get; private set; }

        [ForeignKey("ModalidadeId")]
        [JsonIgnore]
        public virtual ModalidadeModel? Modalidade { get; private set; } 

        public FaixaModel(string Cor, long ModalidadeId)
        {
            this.Cor = Cor;
            this.ModalidadeId= ModalidadeId;
        }

        protected FaixaModel() { }
    }
}
