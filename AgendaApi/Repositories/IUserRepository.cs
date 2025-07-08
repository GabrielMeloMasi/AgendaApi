using AgendaApi.Models;

namespace AgendaApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetProfissionalUsers();
        IEnumerable<User> GetProfissionalByEspecialidade(string especialidade);
    }
}
