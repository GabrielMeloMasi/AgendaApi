namespace AgendaApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAgendamentoRepository _agendamentoRepository;
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

        public void commit()
        {
            _context.SaveChanges();
        }
    }
}
