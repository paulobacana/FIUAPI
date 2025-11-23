namespace FIUAPI.DTO
{
    public class AvaliacaoEventoDTO
    {
        public long EventoId { get; set; }
        public string EventoNome { get; set; }
        public DateTime EventoData { get; set; }
        
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }

        public string? Modalidade { get; set; }
        public double? MediaAvaliacao { get; set; }
        public string? Comentarios { get; set; }

    }
}
