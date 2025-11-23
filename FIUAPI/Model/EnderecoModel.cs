using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("endereco")]
    public class EnderecoModel
    {
        [Key]
        [Column("pk_enderecoid")]
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
        [Column("fk_ctid")]
        public long CtId { get; private set; }


        [ForeignKey("CtId")]
        [JsonIgnore]
        public virtual CTModel? Ct { get; private set; }

        public EnderecoModel(string Logradouro, string Bairro, int? Numero, string Cep, string Cidade, string Uf, long CtId)
        {
            this.Logradouro = Logradouro;
            this.Bairro = Bairro;
            this.Numero = Numero;
            this.Cep = Cep;
            this.Cidade = Cidade;
            this.Uf = Uf;
            this.CtId = CtId;
        }

        protected EnderecoModel() { }
    }
}
