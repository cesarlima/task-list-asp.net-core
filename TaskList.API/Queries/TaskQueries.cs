using System.Collections.Generic;
using System.Linq;
using TaskList.Infra.Contexts;

namespace TaskList.API.Queries
{
    public class TaskQueries
    {
        private readonly TaskContext _context;

        public TaskQueries(TaskContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskViewModel> GetAll()
        {
            return _context
                .Tasks
                .Where(t => t.ExclusionDate == null)
                .Select(t => new
                TaskViewModel()
                {
                    Id = t.Id,
                    Completed = t.Completed,
                    Title = t.Title
                })
                .ToList();
        }
    }
}
