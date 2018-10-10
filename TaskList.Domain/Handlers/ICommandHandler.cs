namespace TaskList.Domain.Handlers
{
    public interface ICommandHandler<T>
    {
        object Handler(T command);
    }
}
