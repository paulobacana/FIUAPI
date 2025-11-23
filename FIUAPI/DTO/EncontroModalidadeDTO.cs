namespace FIUAPI.DTO
{
    public class EncontroModalidadeDTO
    {
        public long EventoId { get; set; }
        public string EventoNome { get; set; }
        public DateTime EventoData { get; set; }
        public string Modalidade { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
    }
}
