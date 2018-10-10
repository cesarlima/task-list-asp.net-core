using TaskList.Domain.Repositories;
using TaskList.Infra.Contexts;

namespace TaskList.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskContext _context;

        public UnitOfWork(TaskContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
