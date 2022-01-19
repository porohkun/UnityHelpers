using Zenject;

namespace Helpers.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public bool CanExecute()
        {
            return OnCanExecute();
        }

        protected virtual bool OnCanExecute()
        {
            return true;
        }

        public void Execute()
        {
            if (CanExecute())
                OnExecute();
        }

        protected abstract void OnExecute();
    }

    public abstract class BaseCommand<T> : ICommand<T>
    {
        protected virtual T DefaultParameter => default(T);

        public bool CanExecute()
        {
            return CanExecute(DefaultParameter);
        }

        public bool CanExecute(T parameter)
        {
            return OnCanExecute(parameter);
        }

        protected virtual bool OnCanExecute(T parameter)
        {
            return true;
        }

        public void Execute()
        {
            if (CanExecute())
                Execute(DefaultParameter);
        }

        public void Execute(T parameter)
        {
            if (CanExecute(parameter))
                OnExecute(parameter);
        }

        protected abstract void OnExecute(T parameter);
    }

    public abstract class BaseCommand<T1, T2> : ICommand<T1, T2>
    {
        protected virtual T1 DefaultParameter1 => default(T1);
        protected virtual T2 DefaultParameter2 => default(T2);

        public bool CanExecute()
        {
            return CanExecute(DefaultParameter1, DefaultParameter2);
        }

        public bool CanExecute(T1 parameter1, T2 parameter2)
        {
            return OnCanExecute(parameter1, parameter2);
        }

        protected virtual bool OnCanExecute(T1 parameter, T2 parameter2)
        {
            return true;
        }

        public void Execute()
        {
            if (CanExecute())
                Execute(DefaultParameter1, DefaultParameter2);
        }

        public void Execute(T1 parameter1, T2 parameter2)
        {
            if (CanExecute(parameter1, parameter2))
                OnExecute(parameter1, parameter2);
        }

        protected abstract void OnExecute(T1 parameter, T2 parameter2);
    }

    public static class BaseCommandExtensions
    {
        public static void Execute<TCommand>(this IFactory<TCommand> factory) where TCommand : BaseCommand
        {
            factory.Create().Execute();
        }

        public static void Execute<TCommand, T>(this IFactory<TCommand> factory, T parameter) where TCommand : BaseCommand<T>
        {
            factory.Create().Execute(parameter);
        }

        public static void Execute<TCommand, T1, T2>(this IFactory<TCommand> factory, T1 parameter1, T2 parameter2) where TCommand : BaseCommand<T1, T2>
        {
            factory.Create().Execute(parameter1, parameter2);
        }
    }
}
