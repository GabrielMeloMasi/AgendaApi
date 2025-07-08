namespace AgendaApi.Repositories
{
    public interface IUnitOfWork
    {
        IAgendamentoRepository AgendamentoRepository { get; }
        IUserRepository UserRepository { get; }
        void commit();
    }
}
