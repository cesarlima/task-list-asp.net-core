using System;

namespace TaskList.Domain.Entities
{
    public class Task : Entity
    {
        public string Title { get; private set; }
        public bool Completed { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public DateTime? ConclusionDate { get; private set; }
        public DateTime? ExclusionDate { get; private set; }

        public Task(string title)
        {
            Title = title;
            CreationDate = DateTime.Now;
        }

        public void ToggleCompleted()
        {
            Completed = !Completed;
            ConclusionDate = null;
            if (Completed)
                ConclusionDate = DateTime.Now;
        }
        public void SetAsDeleted()
        {
            ExclusionDate = DateTime.Now;
        }
    }
}
