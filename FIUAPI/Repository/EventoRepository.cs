using FIUAPI.Data;
using FIUAPI.DTO;
using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FIUAPI.Repository
{
    public class EventoRepository : Repository<EventoModel>, IEventoRepository
    {
        public EventoRepository(ConnectionContext context) : base(context) { }

        public async Task<IEnumerable<EventoCalendarioDTO>> GetCalendarioAsync(string viewType, DateTime data)
        {
            var dataUtc = DateTime.SpecifyKind(data, DateTimeKind.Utc);

            var pViewType = new NpgsqlParameter("viewType", viewType);
            var pData = new NpgsqlParameter("data", dataUtc);


            var sql = "SELECT * FROM calendario_eventos(@viewType, @data::DATE)";

            var query = _context.Database.SqlQueryRaw<EventoCalendarioDTO>(sql, pViewType, pData);
            
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<AvaliacaoEventoDTO>> GetAvaliacoesAsync(long? modalidadeId, DateTime? data, long? localId)
        {
            object pDataValue = DBNull.Value;
            if (data.HasValue)
            {
                var dataUtc = DateTime.SpecifyKind(data.Value, DateTimeKind.Utc);
            }

            var pModId = new NpgsqlParameter("modId", (object?)modalidadeId ?? DBNull.Value);
            var pData = new NpgsqlParameter("data", pDataValue);
            var pLocalId = new NpgsqlParameter("localId", (object?)localId ?? DBNull.Value);


            var sql = @"SELECT 
                            evento_id AS ""EventoId"",
                            evento_nome AS ""EventoNome"",      
                            evento_data AS ""EventoData"",
                            logradouro AS ""Logradouro"",
                            bairro AS ""Bairro"",
                            cidade AS ""Cidade"",
                            uf AS ""Uf"",
                            modalidade AS ""Modalidade"",
                            media_avaliacao AS ""MediaAvaliacao"",
                            comentarios AS ""Comentarios""
                        FROM avaliacoes_eventos(@modId, @data::DATE, @localId)";

            var query = _context.Database.SqlQueryRaw<AvaliacaoEventoDTO>(sql, pModId, pData, pLocalId);

            return await query.ToListAsync();
        }

        public async Task RegistrarPresencaAsync(long atletaId, long eventoId)
        {
            var pAtletaId = new NpgsqlParameter("atletaId", atletaId);
            var pEventoId = new NpgsqlParameter("eventoId", eventoId);
            var sql = "CALL registrar_presenca(@atletaId, @eventoId)";
            await _context.Database.ExecuteSqlRawAsync(sql, pAtletaId, pEventoId);
        }

        public async Task<IEnumerable<ParticipanteEventoDTO>> GetParticipantesAsync(long eventoId)
        {
            var pEventoId = new NpgsqlParameter("eventoId", eventoId);
            var sql = @"SELECT 
                            evento AS ""Evento"",
                            atleta_id AS ""AtletaId"",
                            atleta_nome AS ""AtletaNome""
                        FROM exibir_participantes_evento(@eventoId)";
            var query = _context.Database.SqlQueryRaw<ParticipanteEventoDTO>(sql, pEventoId);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<DetalhesEncontroDTO>> GetDetalhesEncontroAsync(long eventoId)
        {
            var pEventoId = new NpgsqlParameter("eventoId", eventoId);
            var sql = @"SELECT 
                            evento_nome AS ""EventoNome"",
                            evento_data AS ""EventoData"",
                            logradouro AS ""Logradouro"",
                            bairro AS ""Bairro"",
                            cidade AS ""Cidade"",
                            ct_nome AS ""CtNome"",
                            atleta_nome AS ""AtletaNome""
                        FROM exibir_detalhes_encontro(@eventoId)";

            var query = _context.Database.SqlQueryRaw<DetalhesEncontroDTO>(sql, pEventoId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<EncontroModalidadeDTO>> GetPorModalidadeAsync(long modalidadeId)
        {
            var pModalidadeId = new NpgsqlParameter("modalidadeId", modalidadeId);

            var sql = @"SELECT 
                            evento_id AS ""EventoId"",
                            evento_nome AS ""EventoNome"",
                            evento_data AS ""EventoData"",
                            modalidade AS ""Modalidade"",
                            cidade AS ""Cidade"",
                            bairro AS ""Bairro""
                        FROM filtrar_encontros_por_modalidade(@modalidadeId)";

            var query = _context.Database.SqlQueryRaw<EncontroModalidadeDTO>(sql, pModalidadeId);

            return await query.ToListAsync();
        }
    }
}
