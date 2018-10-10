using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities;
using TaskList.Infra.Map;

namespace TaskList.Infra.Contexts
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
        }
    }
}
