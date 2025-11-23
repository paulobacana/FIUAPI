using FIUAPI.Data;
using FIUAPI.DTO;
using FIUAPI.Model;

namespace FIUAPI.Service
{
    public class CTService
    {
        private readonly ConnectionContext _context;

        public CTService(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<string> CadastrarCTCompleto(CadastroCTDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var novoCT = new CTModel(dto.Nome, dto.EquipeId, dto.TreinadorId);
                _context.Cts.Add(novoCT);

                await _context.SaveChangesAsync();

                var novoEndereco = new EnderecoModel(
                    dto.Logradouro,
                    dto.Bairro,
                    dto.Numero,
                    dto.Cep,
                    dto.Cidade,
                    dto.Uf,
                    novoCT.Id.Value
                );

                _context.Enderecos.Add(novoEndereco);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return "CT e endereço cadastrados com sucesso.";
            }
            catch (Exception) 
            { 
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
