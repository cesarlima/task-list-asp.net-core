namespace TaskList.Domain.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
