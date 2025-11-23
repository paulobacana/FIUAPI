using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIUAPI.Model
{
    [Table("modalidade")]
    public class ModalidadeModel
    {
        [Key]
        [Column("pk_modalidadeid")]
        public long? Id { get; private set; }
        [Column("nome")]
        [Required]
        [StringLength(200)]
        public string Nome { get; private set; }

        public ModalidadeModel(string Nome)
        {
            this.Nome = Nome;
        }

        protected ModalidadeModel() { }
    }
}
