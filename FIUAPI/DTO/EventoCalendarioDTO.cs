namespace FIUAPI.DTO
{
    public class EventoCalendarioDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; } 
        public string? Cidade { get; set; }
        public string? Uf { get; set; }

    }
}
