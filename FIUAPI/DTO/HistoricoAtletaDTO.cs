namespace FIUAPI.DTO
{
    public class HistoricoAtletaDTO
    {
        public string AtletaNome { get; set; }
        public long EventoId { get; set; }
        public string EventoNome { get; set; }
        public DateTime EventoData { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }

    }
}
