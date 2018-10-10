using System;
using TaskList.Domain.Entities;

namespace TaskList.Domain.Repositories
{
    public interface ITaskRepository
    {
        void Save(Task task);
        void Update(Task task);
        void Delete(Guid id);
        Task Get(Guid id);
    }
}
