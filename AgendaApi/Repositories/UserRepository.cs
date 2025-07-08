using AgendaApi.Models;

namespace AgendaApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable<User> GetProfissionalUsers()
        {
            return GetAll().Where(p => p.TipoUsuario == "Profissional");
        }
        public IEnumerable<User> GetProfissionalByEspecialidade(string especialidade)
        {
            return GetAll().Where(p => p.Especialidade == especialidade);
        }
    }
}
