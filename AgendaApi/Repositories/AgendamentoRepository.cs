using AgendaApi.Models;

namespace AgendaApi.Repositories
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Agendamento> GetByClientId(string clientId)
        {
            return GetAll().Where(a => a.ClienteUserId == clientId);
        }
    }
}
