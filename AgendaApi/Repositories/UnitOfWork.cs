namespace AgendaApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAgendamentoRepository _agendamentoRepository;
        private IUserRepository _userRepository;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAgendamentoRepository AgendamentoRepository
        {
            get
            {
                return _agendamentoRepository = _agendamentoRepository ?? new AgendamentoRepository(_context);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public void commit()
        {
            _context.SaveChanges();
        }
    }
}
