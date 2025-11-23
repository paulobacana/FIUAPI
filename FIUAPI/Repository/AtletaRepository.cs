using FIUAPI.Data;
using FIUAPI.DTO;
using FIUAPI.Model;
using FIUAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FIUAPI.Repository
{
    public class AtletaRepository : Repository<AtletaModel>, IAtletaRepository
    {
        private readonly IAtletaRepository _repository;
        public AtletaRepository(ConnectionContext context) : base(context) { }

        public async Task<IEnumerable<HistoricoAtletaDTO>> GetHistoricoAsync(long atletaId)
        {
            var sql = @"SELECT
                            atleta_nome AS AtletaNome,
                            evento_id AS EventoId,
                            evento_nome AS EventoNome,
                            evento_data AS EventoData,
                            logradouro AS Logradouro,
                            bairro AS Bairro,
                            cidade AS Cidade,
                            uf AS Uf
                        FROM historico_atleta(@atletaId)";
            var pAtletaId = new Npgsql.NpgsqlParameter("atletaId", atletaId);
            var query = _context.Database.SqlQueryRaw<HistoricoAtletaDTO>(sql, pAtletaId);
            return await query.ToListAsync();
        }
    }
}
