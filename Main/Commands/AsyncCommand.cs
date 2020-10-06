// ///////////////////////////////////////////////////////////
// Company:............. J.H. Kelly
// Department:.......... Virtual Design and Construction (VDC)
// Website:............. http://www.jhkelly.com
// Solution:............ Progress Bar For MVVM
// Project:............. Main
// File:................ AsyncCommand.cs
// Last Code Cleanup:... 10/06/2020 @ 11:17 AM Using ReSharper
// Review Comment:...... // ✓✓ 10/06/2020 - Review Comment:
// ///////////////////////////////////////////////////////////

namespace Main.Commands
{
    using System;
    using System.ServiceModel.Dispatcher;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class AsyncCommand : IAsyncCommand
    {
        #region Fields (All)

        private readonly Func<bool>    canExecute;
        private readonly IErrorHandler errorHandler;
        private readonly Func<Task>    execute;
        private          bool          isExecuting;

        #endregion

        #region Constructors (All)

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this.execute      = execute;
            this.canExecute   = canExecute;
            this.errorHandler = errorHandler;
        }

        #endregion

        #region Events (All)

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute == null)
                {
                    return;
                }

                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this.canExecute == null)
                {
                    return;
                }

                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion

        #region Methods (Non-Private)

        public bool CanExecute()
        {
            return !this.isExecuting && (this.canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (this.CanExecute())
            {
                try
                {
                    this.isExecuting = true;
                    await this.execute();
                }
                finally
                {
                    this.isExecuting = false;
                }
            }

            this.RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        #endregion

        #region Methods (Private)

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            this.ExecuteAsync().FireAndForgetSafeAsync(this.errorHandler);
        }

        #endregion
    }

    public interface IAsyncCommand<T> : ICommand
    {
        #region Methods (Non-Private)

        bool CanExecute(T parameter);

        Task ExecuteAsync(T parameter);

        #endregion
    }

    public class AsyncCommand<T> : IAsyncCommand<T>
    {
        #region Fields (All)

        private readonly Func<T, bool> _canExecute;
        private readonly IErrorHandler _errorHandler;
        private readonly Func<T, Task> _execute;

        //public event EventHandler CanExecuteChanged;

        private bool _isExecuting;

        #endregion

        #region Constructors (All)

        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this._execute      = execute;
            this._canExecute   = canExecute;
            this._errorHandler = errorHandler;
        }

        #endregion

        #region Events (All)

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute == null)
                {
                    return;
                }

                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this._canExecute == null)
                {
                    return;
                }

                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion

        #region Methods (Non-Private)

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

        #endregion

        #region Methods (Private)

        bool ICommand.CanExecute(object parameter)
        {
            return !(parameter is T t) || this.CanExecute(t);
        }

        void ICommand.Execute(object parameter)
        {
            this.ExecuteAsync((T) parameter).FireAndForgetSafeAsync(this._errorHandler);
        }

        #endregion
    }

    public interface IAsyncCommand : ICommand
    {
        #region Methods (Non-Private)

        bool CanExecute();

        Task ExecuteAsync();

        #endregion
    }
}