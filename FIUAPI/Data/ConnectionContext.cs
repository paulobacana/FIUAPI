using Microsoft.EntityFrameworkCore;
using FIUAPI.Model;

namespace FIUAPI.Data
{
    public class ConnectionContext : DbContext
    {

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {

        }

        public DbSet<AtletaModel> Atletas { get; set; }
        public DbSet<TreinadorModel> Treinadores { get; set; }
        public DbSet<RelatorioModel> Relatorios { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<CT_EventoModel> Ct_Eventos { get; set; }
        public DbSet<CTModel> Cts { get; set; }
        public DbSet<EventoModel> Eventos { get; set; }
        public DbSet<EquipeModel> Equipes { get; set; }
        public DbSet<FaixaModel> Faixas { get; set; }
        public DbSet<LocalModel> Locais { get; set; }
        public DbSet<MestreModel> Mestres { get; set; }
        public DbSet<ModalidadeModel> Modalidades { get; set; }
        public DbSet<ParticipacaoEventoModel> ParticipacaoEvento { get; set; }

    }
}
