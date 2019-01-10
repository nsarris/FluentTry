using System;
using System.Text;
using System.Threading.Tasks;

namespace FluentTry
{

    #region ITryOperation / ITryAsyncOperation

    public interface IExecutableOperation
    {
        void Execute();
        ITryResult ExecuteSafe();
    }

    public interface IExecutableAsyncOperation
    {
        Task ExecuteAsync();
        Task<ITryResult> ExecuteSafeAsync();
    }

    public interface IFinalizableTryOperationNoContext
    {
        IFinalizedTryOperation Finally(Action handler);
    }

    public interface IFinalizableTryOperation<out TContext> : IFinalizableTryOperationNoContext
        where TContext : class
    {
        IFinalizedTryOperation Finally(Action<TContext> handler);
    }

    public interface IFinalizableTryAsyncOperationNoContext
    {
        IFinalizedTryAsyncOperation Finally(Action handler);
        IFinalizedTryAsyncOperation FinallyAsync(Func<Task> handler);
    }

    public interface IFinalizableTryAsyncOperation<TContext> : IFinalizableTryAsyncOperationNoContext
        where TContext : class
    {
        IFinalizedTryAsyncOperation Finally(Action<TContext> handler);
        IFinalizedTryAsyncOperation FinallyAsync(Func<TContext, Task> handler);
    }

    public interface IHandleableTryOperationNoContext : IFinalizableTryOperationNoContext
    {
        ITryOperationNoContext Swallow();
        ITryOperationNoContext Swallow<TException>() where TException : Exception;

        ITryOperationNoContext Catch(Action handler);
        ITryOperationNoContext Catch<TException>(Action handler) where TException : Exception;
        ITryOperationNoContext Catch<TException>(Action<TException> handler) where TException : Exception;
    }

    public interface IHandleableTryOperation<TContext> : IFinalizableTryOperation<TContext>
        where TContext : class
    {
        ITryOperation<TContext> Swallow();
        ITryOperation<TContext> Swallow<TException>() where TException : Exception;

        ITryOperation<TContext> Catch(Action handler);
        ITryOperation<TContext> Catch<TException>(Action handler) where TException : Exception;
        ITryOperation<TContext> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperation<TContext> Catch(Action<TContext> handler);
        ITryOperation<TContext> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperationNoContext : IFinalizableTryAsyncOperationNoContext
    {
        ITryAsyncOperationNoContext Swallow();
        ITryAsyncOperationNoContext Swallow<TException>() where TException : Exception;

        ITryAsyncOperationNoContext Catch(Action handler);
        ITryAsyncOperationNoContext Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperationNoContext Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryAsyncOperationNoContext CatchAsync(Func<Task> handler);
        ITryAsyncOperationNoContext CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperationNoContext CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperation<TContext> : IFinalizableTryAsyncOperation<TContext>
        where TContext : class
    {
        ITryAsyncOperation<TContext> Swallow();
        ITryAsyncOperation<TContext> Swallow<TException>() where TException : Exception;

        ITryAsyncOperation<TContext> Catch(Action handler);
        ITryAsyncOperation<TContext> Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperation<TContext> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryAsyncOperation<TContext> Catch(Action<TContext> handler);
        ITryAsyncOperation<TContext> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryAsyncOperation<TContext> CatchAsync(Func<Task> handler);
        ITryAsyncOperation<TContext> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext> CatchAsync(Func<TContext, Task> handler);
        ITryAsyncOperation<TContext> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception;
    }


    public interface ITryOperationNoContext : IExecutableOperation, IHandleableTryOperationNoContext
    {

    }

    public interface ITryAsyncOperationNoContext : IExecutableAsyncOperation, IHandleableTryAsyncOperationNoContext
    {

    }

    public interface ITryOperation<TContext> : IExecutableOperation, IHandleableTryOperation<TContext>
        where TContext : class
    {

    }

    public interface ITryAsyncOperation<TContext> : IExecutableAsyncOperation, IHandleableTryAsyncOperation<TContext>
        where TContext : class
    {

    }

    public interface IFinalizedTryOperation : IExecutableOperation
    {

    }

    public interface IFinalizedTryAsyncOperation : IExecutableAsyncOperation
    {

    }

    #endregion

    #region ITryOperation<T> / ITryAsyncOperation<T>

    public interface IExecutableOperation<out T>
    {
        T Execute();
        ITryResult<T> ExecuteSafe();
    }

    public interface IExecutableAsyncOperation<T>
    {
        Task<T> ExecuteAsync();
        Task<ITryResult<T>> ExecuteSafeAsync();
    }

    public interface IFinalizableTryOperationNoContext<out T>
    {
        IFinalizedTryOperation<T> Finally(Action handler);
    }

    public interface IFinalizableTryOperation<out TContext, T> : IFinalizableTryOperationNoContext<T>
        where TContext : class
    {
        IFinalizedTryOperation<T> Finally(Action<TContext> handler);
    }

    public interface IFinalizableTryAsyncOperationNoContext<T>
    {
        IFinalizedTryAsyncOperation<T> Finally(Action handler);
        IFinalizedTryAsyncOperation<T> FinallyAsync(Func<Task> handler);
    }

    public interface IFinalizableTryAsyncOperation<TContext, T> : IFinalizableTryAsyncOperationNoContext<T>
        where TContext : class
    {
        IFinalizedTryAsyncOperation<T> Finally(Action<TContext> handler);
        IFinalizedTryAsyncOperation<T> FinallyAsync(Func<TContext, Task> handler);
    }

    public interface IHandleableTryOperationNoContext<T> : IFinalizableTryOperationNoContext<T>
    {
        ITryOperationNoContext<T> Swallow();
        ITryOperationNoContext<T> Swallow<TException>() where TException : Exception;

        ITryOperationNoContext<T> Catch(Action handler);
        ITryOperationNoContext<T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperationNoContext<T> Catch<TException>(Action<TException> handler) where TException : Exception;

        ITryOperationNoContext<T> Catch(Func<T> handler);
        ITryOperationNoContext<T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperationNoContext<T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
    }

    public interface IHandleableTryOperation<TContext, T> : IFinalizableTryOperation<TContext, T>
        where TContext : class
    {
        ITryOperation<TContext, T> Swallow();
        ITryOperation<TContext, T> Swallow<TException>() where TException : Exception;

        ITryOperation<TContext, T> Catch(Action handler);
        ITryOperation<TContext, T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperation<TContext, T> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperation<TContext, T> Catch(Action<TContext> handler);
        ITryOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryOperation<TContext, T> Catch(Func<T> handler);
        ITryOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
        ITryOperation<TContext, T> Catch(Func<TContext, T> handler);
        ITryOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperationNoContext<T> : IFinalizableTryAsyncOperationNoContext<T>
    {
        ITryAsyncOperationNoContext<T> Swallow();
        ITryAsyncOperationNoContext<T> Swallow<TException>() where TException : Exception;

        ITryAsyncOperationNoContext<T> Catch(Action handler);
        ITryAsyncOperationNoContext<T> Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> Catch<TException>(Action<TException> handler) where TException : Exception;

        ITryAsyncOperationNoContext<T> CatchAsync(Func<Task> handler);
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;

        ITryAsyncOperationNoContext<T> Catch(Func<T> handler);
        ITryAsyncOperationNoContext<T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> Catch<TException>(Func<TException, T> handler) where TException : Exception;

        ITryAsyncOperationNoContext<T> CatchAsync(Func<Task<T>> handler);
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperation<TContext, T> : IFinalizableTryAsyncOperation<TContext, T>
        where TContext : class
    {
        ITryAsyncOperation<TContext, T> Swallow();
        ITryAsyncOperation<TContext, T> Swallow<TException>() where TException : Exception;

        ITryAsyncOperation<TContext, T> Catch(Action handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch(Action<TContext> handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryAsyncOperation<TContext, T> CatchAsync(Func<Task> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception;

        ITryAsyncOperation<TContext, T> Catch(Func<T> handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch(Func<TContext, T> handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception;

        ITryAsyncOperation<TContext, T> CatchAsync(Func<Task<T>> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task<T>> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception;
    }


    public interface ITryOperationNoContext<T> : IExecutableOperation<T>, IHandleableTryOperationNoContext<T>
    {

    }

    public interface ITryOperation<TContext, T> : IExecutableOperation<T>, IHandleableTryOperation<TContext, T>
        where TContext : class
    {

    }

    public interface ITryAsyncOperationNoContext<T> : IExecutableAsyncOperation<T>, IHandleableTryAsyncOperationNoContext<T>
    {

    }

    public interface ITryAsyncOperation<TContext, T> : IExecutableAsyncOperation<T>, IHandleableTryAsyncOperation<TContext, T>
        where TContext : class
    {

    }

    public interface IFinalizedTryOperation<out T> : IExecutableOperation<T>
    {

    }

    public interface IFinalizedTryAsyncOperation<T> : IExecutableAsyncOperation<T>
    {

    }

    #endregion


    internal sealed class TryOperation<TContext, T> : ITryOperation<TContext, T>, ITryOperation<TContext>, IFinalizedTryOperation, IFinalizedTryOperation<T>
        where TContext : class
    {
        private readonly ExceptionHandlers<TContext, T> handlers = new ExceptionHandlers<TContext, T>();
        private readonly Func<TContext, T> operation;
        private readonly TContext context;
        private readonly TryOpertationConfiguration configuration;

        public TryOperation(Func<TContext, T> operation, TContext context, TryOpertationConfiguration configuration = null)
        {
            this.operation = operation ?? throw new ArgumentNullException(nameof(operation));
            this.context = context;
            this.configuration = configuration ?? new TryOpertationConfiguration();
        }

        #region ITryOperation<T>

        public ITryOperation<TContext, T> Swallow<TException>()
            where TException : Exception
        {
            handlers.AddHandler<TException>(() => default);
            return this;
        }

        public ITryOperation<TContext, T> Swallow()
        {
            handlers.AddHandler<Exception>(() => default);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Action handler)
            where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Action<TException> handler)
            where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch(Action handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public ITryOperation<TContext, T> Catch(Func<T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch(Action<TContext> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch(Func<TContext, T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }


        public IFinalizedTryOperation<T> Finally(Action handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryOperation<T> Finally(Action<TContext> handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        #endregion ITryOperation<T>

        #region ITryOperation (Void)

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Swallow()
        {
            Swallow();
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch<TException>(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch<TException>(Action<TException> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch(Action<TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch<TException>(Action<TException, TContext> handler)
        {
            Catch(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperation<TContext>.Finally(Action<TContext> handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperationNoContext.Finally(Action handler)
        {
            Finally(handler);
            return this;
        }

        #endregion ITryOperation

        #region Execute

        void IExecutableOperation.Execute()
        {
            Execute();
        }

        public T Execute()
        {
            try
            {
                return operation(context);
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), configuration.ExceptionHandlerSequenceBehaviour);
                if (handler == null) throw;
                return handler.Execute(context, e);
            }
            finally
            {
                handlers.GetFinallyHandler()?.Execute(context, null);
            }
        }

        ITryResult IExecutableOperation.ExecuteSafe()
        {
            return ExecuteSafe();
        }

        public ITryResult<T> ExecuteSafe()
        {
            try
            {
                return new TryResult<T>(operation(context));
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), configuration.ExceptionHandlerSequenceBehaviour);

                if (handler == null)
                    return new TryResult<T>(e);

                try
                {
                    return new TryResult<T>(handler.Execute(context, e));
                }
                catch (Exception rethrownException)
                {
                    return new TryResult<T>(rethrownException);
                }
            }
            finally
            {
                handlers.GetFinallyHandler()?.Execute(context, null);
            }
        }

        #endregion Execute
    }

    internal sealed class TryAsyncOperation<TContext, T> : ITryAsyncOperation<TContext, T>, ITryAsyncOperation<TContext>, IFinalizedTryAsyncOperation, IFinalizedTryAsyncOperation<T>
        where TContext : class
    {
        private readonly ExceptionHandlers<TContext, T> handlers = new ExceptionHandlers<TContext, T>();
        private readonly Func<TContext, Task<T>> operation;
        private readonly TContext context;
        private readonly TryOpertationConfiguration configuration;

        public TryAsyncOperation(Func<TContext, Task<T>> operation, TContext context, TryOpertationConfiguration configuration = null)
        {
            this.operation = operation ?? throw new ArgumentNullException(nameof(operation));
            this.context = context;
            this.configuration = configuration ?? new TryOpertationConfiguration();
        }

        #region ITryAsyncOperation<T>

        public ITryAsyncOperation<TContext, T> Swallow<TException>()
            where TException : Exception
        {
            handlers.AddHandler<TException>(() => default);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Swallow()
        {
            handlers.AddHandler<Exception>(() => default);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Action handler)
            where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException> handler)
            where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Action handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<Task> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Func<T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Func<TContext, T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Action<TContext> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public IFinalizedTryAsyncOperation<T> Finally(Action handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryAsyncOperation<T> FinallyAsync(Func<Task> handler)
        {
            handlers.SetAsyncFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryAsyncOperation<T> Finally(Action<TContext> handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryAsyncOperation<T> FinallyAsync(Func<TContext, Task> handler)
        {
            handlers.SetAsyncFinallyHandler(handler);
            return this;
        }


        #endregion ITryOperation<T>

        #region ITryAsyncOperation (Void)

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Swallow()
        {
            Swallow();
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }
        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch<TException>(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch<TException>(Action<TException> handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync<TException>(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync<TException>(Func<TException, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }


        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch(Action<TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch<TException>(Action<TException, TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync(Func<TContext, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync<TException>(Func<TException, TContext, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperation<TContext>.Finally(Action<TContext> handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperation<TContext>.FinallyAsync(Func<TContext, Task> handler)
        {
            FinallyAsync(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperationNoContext.Finally(Action handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperationNoContext.FinallyAsync(Func<Task> handler)
        {
            FinallyAsync(handler);
            return this;
        }

        #endregion ITryOperation

        #region ExecuteAsync

        Task IExecutableAsyncOperation.ExecuteAsync()
        {
            return ExecuteAsync();
        }

        public async Task<T> ExecuteAsync()
        {
            try
            {
                return await operation(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), configuration.ExceptionHandlerSequenceBehaviour);
                if (handler == null) throw;
                try
                {
                    return await handler.ExecuteAsync(context, e).ConfigureAwait(false);
                }
                catch (Exception rethrownException)
                {
                    throw rethrownException;
                }
            }
            finally
            {
                var finallyHandler = handlers.GetFinallyHandler();
                if (finallyHandler != null)
                {
                    await finallyHandler.ExecuteAsync(context, null).ConfigureAwait(false);
                }
            }
        }

        Task<ITryResult> IExecutableAsyncOperation.ExecuteSafeAsync()
        {
            return ExecuteSafeAsync().ContinueWith(t => t.Result as ITryResult);
        }

        public async Task<ITryResult<T>> ExecuteSafeAsync()
        {
            try
            {
                return new TryResult<T>(await operation(context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType());

                if (handler == null)
                    return new TryResult<T>(e);

                try
                {
                    return new TryResult<T>(await handler.ExecuteAsync(context, e).ConfigureAwait(false));
                }
                catch (Exception rethrownException)
                {
                    return new TryResult<T>(rethrownException);
                }
            }
            finally
            {
                var finallyHandler = handlers.GetFinallyHandler();
                if (finallyHandler != null)
                    await finallyHandler.ExecuteAsync(context, null).ConfigureAwait(false);
            }
        }

        #endregion ExecuteAsync
    }

    #region Factory

    public static class Try
    {
        public static ITryBuilder WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate)
        {
            return new TryBuilder().WithConfiguration(configuratorDelegate);
        }

        public static ITryBuilder<TContext> WithContext<TContext>(TContext context)
            where TContext : class
        {
            return new TryBuilder<TContext>(context);
        }


        public static ITryOperation<object> Do(Action operation)
        {
            return Do<object>(null, (_) => operation());
        }

        public static ITryOperation<object, T> Do<T>(Func<T> operation)
        {
            return Do<object, T>(null, (_) => operation());
        }

        internal static ITryOperation<TContext> Do<TContext>(TContext context, Action<TContext> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryOperation<TContext, Void>((ctx) => { operation(ctx); return Void.Value; }, context, configuration);
        }

        internal static ITryOperation<TContext, T> Do<TContext, T>(TContext context, Func<TContext, T> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryOperation<TContext, T>(operation, context, configuration);
        }



        public static ITryAsyncOperation<object> DoAsync(Func<Task> operation)
        {
            return DoAsync<object>(null, (_) => operation().ContinueWith(__ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion));
        }

        public static ITryAsyncOperation<object, T> DoAsync<T>(Func<Task<T>> operation)
        {
            return DoAsync<object, T>(null, (_) => operation());
        }

        internal static ITryAsyncOperation<TContext> DoAsync<TContext>(TContext context, Func<TContext, Task> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryAsyncOperation<TContext, Void>((ctx) => operation(ctx).ContinueWith(_ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion), context, configuration);
        }

        internal static ITryAsyncOperation<TContext, T> DoAsync<TContext, T>(TContext context, Func<TContext, Task<T>> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryAsyncOperation<TContext, T>(operation, context, configuration);
        }
    }

    #endregion Static Entry point
}