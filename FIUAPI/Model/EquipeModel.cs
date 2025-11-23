using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIUAPI.Model
{
    [Table("equipe")]
    public class EquipeModel
    {
        [Key]
        [Column("pk_equipeid")]
        public long? Id { get; private set; }
        [Required]
        [Column("nome")]
        [StringLength(200)]
        public string Nome { get; private set; }
        [Required]
        [Column("fk_mestreid")]

        public long MestreId { get; private set; }

        [ForeignKey("MestreId")]
        [JsonIgnore]
        public virtual MestreModel? Mestre { get; private set; }

        public EquipeModel(string Nome, long MestreId)
        {
            this.Nome = Nome;
            this.MestreId = MestreId;
        }
        
        protected EquipeModel() { }
    }
}
