using System;
using System.Threading.Tasks;

namespace FluentTry
{
    internal sealed class TryOperation<TContext, T> : ITryOperationWithContext<TContext, T>, ITryOperationWithContext<TContext>, IFinalizedTryOperation, IFinalizedTryOperation<T>, ITryOperation, ITryOperation<T>
        where TContext : class
    {
        private readonly ExceptionHandlers<TContext, T> handlers = new ExceptionHandlers<TContext, T>();
        private readonly IFuncWrapper<TContext, T> operation;
        private readonly TContext context;
        private readonly TryOpertationConfiguration configuration;

        public TryOperation(Func<TContext, T> operation, TContext context, TryOpertationConfiguration configuration = null)
        {
            this.operation = new FuncWrapper<TContext, T>(operation) ?? throw new ArgumentNullException(nameof(operation));
            this.context = context;
            this.configuration = configuration ?? new TryOpertationConfiguration();
        }

        public TryOperation(Func<TContext, Task<T>> operation, TContext context, TryOpertationConfiguration configuration = null)
        {
            this.operation = new AsyncFuncWrapper<TContext, T>(operation) ?? throw new ArgumentNullException(nameof(operation));
            this.context = context;
            this.configuration = configuration ?? new TryOpertationConfiguration();
        }

        #region ITryOperation<T>

        public ITryOperationWithContext<TContext, T> Swallow<TException>()
            where TException : Exception
        {
            handlers.AddHandler<TException>(() => default);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Swallow()
        {
            handlers.AddHandler<Exception>(() => default);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Action handler)
            where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Action<TException> handler)
            where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch(Action handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync(Func<Task> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch(Func<T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync(Func<Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync(Func<TContext, Task> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch(Func<TContext, T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync(Func<TContext, Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch(Action<TContext> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public IFinalizedTryOperation<T> Finally(Action handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryOperation<T> FinallyAsync(Func<Task> handler)
        {
            handlers.SetAsyncFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryOperation<T> Finally(Action<TContext> handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryOperation<T> FinallyAsync(Func<TContext, Task> handler)
        {
            handlers.SetAsyncFinallyHandler(handler);
            return this;
        }


        #endregion ITryOperation<T>

        #region ITryOperation (Void)

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Swallow()
        {
            Swallow();
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }
        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch<TException>(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch<TException>(Action<TException> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.CatchAsync(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.CatchAsync<TException>(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.CatchAsync<TException>(Func<TException, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }


        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch(Action<TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch<TException>(Action<TException, TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.CatchAsync(Func<TContext, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.CatchAsync<TException>(Func<TException, TContext, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperationWithContext<TContext>.Finally(Action<TContext> handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperationWithContext<TContext>.FinallyAsync(Func<TContext, Task> handler)
        {
            FinallyAsync(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperation.Finally(Action handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperation.FinallyAsync(Func<Task> handler)
        {
            FinallyAsync(handler);
            return this;
        }

        #endregion ITryOperation

        #region ITryOperation<T>

        ITryOperation<T> IHandleableTryOperation<T>.Swallow()
        {
            Swallow();
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Action<TException> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.CatchAsync(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.CatchAsync<TException>(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.CatchAsync<TException>(Func<TException, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch(Func<T> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Func<T> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Func<TException, T> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.CatchAsync(Func<Task<T>> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.CatchAsync<TException>(Func<Task<T>> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.CatchAsync<TException>(Func<TException, Task<T>> handler)
        {
            CatchAsync(handler);
            return this;
        }

        #endregion

        #region ITryOperation (Void)

        ITryOperation IHandleableTryOperation.Swallow()
        {
            Swallow();
            return this;
        }

        ITryOperation IHandleableTryOperation.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }

        ITryOperation IHandleableTryOperation.Catch(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.Catch<TException>(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.Catch<TException>(Action<TException> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.CatchAsync(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.CatchAsync<TException>(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.CatchAsync<TException>(Func<TException, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        #endregion

        #region Execute

        void IExecutableOperation.Execute()
        {
            Execute();
        }

        public T Execute()
        {
            try
            {
                return operation.Invoke(context);
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), configuration.ExceptionHandlerSequenceBehaviour);
                if (handler == null) throw e;
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
                return new TryResult<T>(operation.Invoke(context));
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

        #region ExecuteAsync

        Task IExecutableOperation.ExecuteAsync()
        {
            return ExecuteAsync();
        }

        public async Task<T> ExecuteAsync()
        {
            try
            {
                return await operation.InvokeAsync(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), configuration.ExceptionHandlerSequenceBehaviour);
                if (handler == null) throw e;
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

        Task<ITryResult> IExecutableOperation.ExecuteSafeAsync()
        {
            return ExecuteSafeAsync().ContinueWith(t => t.Result as ITryResult);
        }

        public async Task<ITryResult<T>> ExecuteSafeAsync()
        {
            try
            {
                return new TryResult<T>(await operation.InvokeAsync(context).ConfigureAwait(false));
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
}