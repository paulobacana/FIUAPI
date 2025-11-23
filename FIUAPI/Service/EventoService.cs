using FIUAPI.Data;
using FIUAPI.DTO;
using FIUAPI.Model;

namespace FIUAPI.Service
{
    public class EventoService
    {
        private readonly ConnectionContext _context;

        public EventoService(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<string> AgendarEvento(AgendarEventoDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var modalidade = await _context.Modalidades.FindAsync(dto.ModalidadeId);
                string nomeFinal = dto.NomeBase;

                if (modalidade != null)
                {
                    nomeFinal = $"{dto.NomeBase} - {modalidade.Nome}";
                }

                var dataUtc = DateTime.SpecifyKind(dto.Data, DateTimeKind.Utc);
                var novoEvento = new EventoModel(nomeFinal, dataUtc);

                _context.Eventos.Add(novoEvento);
                await _context.SaveChangesAsync();

                var novoLocal = new LocalModel(
                    dto.Logradouro,
                    dto.Bairro,
                    dto.Numero,
                    dto.Cep,
                    dto.Cidade,
                    dto.Uf,
                    novoEvento.Id.Value
                );

                _context.Locais.Add(novoLocal);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return $"Evento '{nomeFinal}' agendado com sucesso. (ID: {novoEvento.Id})";
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
