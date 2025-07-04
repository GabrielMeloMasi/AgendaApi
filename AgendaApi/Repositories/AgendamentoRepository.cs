using AgendaApi.Models;

namespace AgendaApi.Repositories
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
