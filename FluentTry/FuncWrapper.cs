using System;
using System.Threading.Tasks;

namespace FluentTry
{
	internal class FuncWrapper<TResult>
    {
        private readonly Func<Task<TResult>> asyncOperation;
        private readonly Func<TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute()
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation());
            else
                return syncOperation();
        }

        public Task<TResult> ExecuteAsync()
        {
            if (asyncOperation != null)
                return asyncOperation();
            else
			{
				try
                {
                    return Task.FromResult(syncOperation());
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TResult>
    {
        private readonly Func<TArg1, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1));
            else
                return syncOperation(arg1);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TResult>
    {
        private readonly Func<TArg1, TArg2, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2));
            else
                return syncOperation(arg1, arg2);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3));
            else
                return syncOperation(arg1, arg2, arg3);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4));
            else
                return syncOperation(arg1, arg2, arg3, arg4);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> funcWrapper) => funcWrapper.Delegate;
    }

	internal class FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>
    {
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, Task<TResult>> asyncOperation;
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> syncOperation;

		public Delegate Delegate => (Delegate)syncOperation ?? asyncOperation;

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, Task<TResult>> operation)
        {
            this.asyncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public FuncWrapper(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> operation)
        {
            this.syncOperation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public TResult Execute(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15, TArg16 arg16)
        {
            if (asyncOperation != null)
                return AsyncTaskHelper.RunSync(() => asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
            else
                return syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

        public Task<TResult> ExecuteAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15, TArg16 arg16)
        {
            if (asyncOperation != null)
                return asyncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            else
			{
				try
                {
                    return Task.FromResult(syncOperation(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
			}
        }

		public static implicit operator Delegate(FuncWrapper<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> funcWrapper) => funcWrapper.Delegate;
    }

}