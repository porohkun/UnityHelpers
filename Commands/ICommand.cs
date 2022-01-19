namespace Helpers.Commands
{
    public interface ICommand
    {
        bool CanExecute();
        void Execute();
    }

    public interface ICommand<T> : ICommand
    {
        bool CanExecute(T parameter);
        void Execute(T parameter);
    }

    public interface ICommand<T1, T2> : ICommand
    {
        bool CanExecute(T1 parameter1, T2 parameter2);
        void Execute(T1 parameter1, T2 parameter2);
    }
}
