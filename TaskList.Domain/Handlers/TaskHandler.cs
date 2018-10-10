using TaskList.Domain.Commands;
using TaskList.Domain.Entities;
using TaskList.Domain.Repositories;

namespace TaskList.Domain.Handlers
{
    public class TaskHandler
        : ICommandHandler<TaskRegisterCommand>
        , ICommandHandler<ToggleTaskCommand>
        , ICommandHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _uow;

        public TaskHandler(ITaskRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public object Handler(TaskRegisterCommand command)
        {
            var task = new Task(command.Title);
            _repository.Save(task);
            _uow.Commit();

            return new { task.Id, task.Title };
        }

        public object Handler(ToggleTaskCommand command)
        {
            var task = _repository.Get(command.Id);
            task.ToggleCompleted();

            _repository.Update(task);
            _uow.Commit();

            return new { task.Id, task.Completed };
        }

        public object Handler(DeleteTaskCommand command)
        {
            var task = _repository.Get(command.Id);
            task.SetAsDeleted();
            _uow.Commit();

            return new { command.Id };
        }
    }
}
