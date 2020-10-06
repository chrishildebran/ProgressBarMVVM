namespace Main.Commands
{
    using System;
    using System.ServiceModel.Dispatcher;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class AsyncCommand : IAsyncCommand
    {
        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

        public AsyncCommand(
            Func<Task> execute,
            Func<bool> canExecute = null,
            IErrorHandler errorHandler = null)
        {
            this._execute      = execute;
            this._canExecute   = canExecute;
            this._errorHandler = errorHandler;
        }

        public bool CanExecute()
        {
            return !this._isExecuting && (this._canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (this.CanExecute())
            {
                try
                {
                    this._isExecuting = true;
                    await this._execute();
                }
                finally
                {
                    this._isExecuting = false;
                }
            }

            this.RaiseCanExecuteChanged();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested -= value;
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            this.ExecuteAsync().FireAndForgetSafeAsync(this._errorHandler);
        }
        #endregion
    }



    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);
        bool CanExecute(T parameter);
    }

    public class AsyncCommand<T> : IAsyncCommand<T>
    {
        //public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this._execute      = execute;
            this._canExecute   = canExecute;
            this._errorHandler = errorHandler;
        }

        public bool CanExecute(T parameter)
        {
            return !this._isExecuting && (this._canExecute?.Invoke(parameter) ?? true);
        }

        public async Task ExecuteAsync(T parameter)
        {
            if (this.CanExecute(parameter))
            {
                try
                {
                    this._isExecuting = true;
                    await this._execute(parameter);
                }
                finally
                {
                    this._isExecuting = false;
                }
            }

            this.RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this._canExecute == null)
                    return;
                CommandManager.RequerySuggested -= value;
            }
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object parameter)
        {
            return !(parameter is T t) || this.CanExecute(t);
        }

        void ICommand.Execute(object parameter)
        {
            this.ExecuteAsync((T)parameter).FireAndForgetSafeAsync(this._errorHandler);
        }
        #endregion

       
    }

    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
