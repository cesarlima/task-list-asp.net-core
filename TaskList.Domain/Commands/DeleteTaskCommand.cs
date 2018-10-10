using System;

namespace TaskList.Domain.Commands
{
    public class DeleteTaskCommand
    {
        public Guid Id { get; set; }
    }
}
