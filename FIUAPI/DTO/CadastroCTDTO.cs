namespace FIUAPI.DTO
{
    public class CadastroCTDTO
    {
        public string Nome { get; set; }
        public long EquipeId { get; set; }
        public long TreinadorId { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
