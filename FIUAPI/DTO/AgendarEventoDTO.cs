using System.ComponentModel.DataAnnotations;

namespace FIUAPI.DTO
{
    public class AgendarEventoDTO
    {
        [Required]
        public string NomeBase { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public long ModalidadeId { get; set; }

        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Uf { get; set; }
        [Required]
        public string Cep { get; set; }
        public int? Numero { get; set; }
    }
}
