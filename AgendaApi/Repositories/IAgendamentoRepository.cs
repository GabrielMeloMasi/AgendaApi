using AgendaApi.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace AgendaApi.Repositories
{
    public interface IAgendamentoRepository : IRepository<Agendamento>
    {
        IEnumerable<Agendamento> GetByClientId(string clientId);

    }
}
