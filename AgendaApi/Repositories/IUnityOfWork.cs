namespace AgendaApi.Repositories
{
    public interface IUnitOfWork
    {
        IAgendamentoRepository AgendamentoRepository { get; }
        void commit();
    }
}
