using System;
using TaskList.Domain.Entities;
using TaskList.Domain.Repositories;
using TaskList.Infra.Contexts;

namespace TaskList.Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var task = Get(id);
            _context.Remove(task);
        }
        public Task Get(Guid id)
        {
            return _context.Tasks.Find(id);
        }
        public void Save(Task task)
        {
            _context.Add(task);
        }
        public void Update(Task task)
        {
            _context.Update(task);
        }
    }
}
