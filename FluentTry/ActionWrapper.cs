using System;
using System.Threading.Tasks;

namespace FluentTry
{
	internal class ActionWrapper
    {
        private readonly Func<Task> asyncOperation;
        private readonly Action syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute()
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation());
            else
                syncOperation();
        }

        public Task ExecuteAsync()
        {
            if (asyncOperation != null)
                return asyncOperation();
            else
			{
				try
                {
                    syncOperation();
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1>
    {
        private readonly Func<TArg1, Task> asyncOperation;
        private readonly Action<TArg1> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1));
            else
                syncOperation(arg1);
        }

        public Task ExecuteAsync(TArg1 arg1)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1);
            else
			{
				try
                {
                    syncOperation(arg1);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2>
    {
        private readonly Func<TArg1, TArg2, Task> asyncOperation;
        private readonly Action<TArg1, TArg2> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2));
            else
                syncOperation(arg1, arg2);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2);
            else
			{
				try
                {
                    syncOperation(arg1, arg2);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3>
    {
        private readonly Func<TArg1, TArg2, TArg3, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3));
            else
                syncOperation(arg1, arg2, arg3);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4));
            else
                syncOperation(arg1, arg2, arg3, arg4);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> actionWrapper) => actionWrapper.Delegate;
    }

	internal class ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, Task> asyncOperation;
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public ActionWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, Task> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public ActionWrapper(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public void Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15, TArg16 arg16)
        {
            if (asyncOperation != null)
                AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
            else
                syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

        public Task ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15, TArg16 arg16)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            else
			{
				try
                {
                    syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
			}
        }

		public static implicit operator Delegate(ActionWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16> actionWrapper) => actionWrapper.Delegate;
    }

}