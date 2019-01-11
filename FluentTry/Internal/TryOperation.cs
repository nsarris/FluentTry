#pragma warning disable S3445 // Exceptions should not be explicitly rethrown

using System;
using System.Threading.Tasks;

namespace FluentTry
{
    internal sealed class TryOperation<TContext, T> : ITryOperationWithContext<TContext, T>, ITryOperationWithContext<TContext>, IFinalizedTryOperation, IFinalizedTryOperation<T>, ITryOperation, ITryOperation<T>
        where TContext : class
    {
        private readonly ExceptionHandlers<TContext, T> handlers = new ExceptionHandlers<TContext, T>();
        private readonly ExceptionHandlers<TContext, T> loggers = new ExceptionHandlers<TContext, T>();

        private readonly IFuncWrapper<TContext, T> operation;
        private readonly TContext context;
        private readonly TryOperationConfiguration configuration;

        public TryOperation(Func<TContext, T> operation, TContext context, TryOperationConfiguration configuration = null)
        {
            this.operation = new FuncWrapper<TContext, T>(operation) ?? throw new ArgumentNullException(nameof(operation));
            this.context = context;
            this.configuration = configuration ?? TryOperationConfiguration.Default;
        }

        public TryOperation(Func<TContext, Task<T>> operation, TContext context, TryOperationConfiguration configuration = null)
        {
            this.operation = new AsyncFuncWrapper<TContext, T>(operation) ?? throw new ArgumentNullException(nameof(operation));
            this.context = context;
            this.configuration = configuration ?? TryOperationConfiguration.Default;
        }

        #region ITryOperationWithContext<T>

        public ITryOperationWithContext<TContext, T> Swallow<TException>()
            where TException : Exception
        {
            handlers.AddHandler<TException>(() => default);
            return this;
        }

        ITryOperationWithContext<TContext, T> IHandleableTryOperationWithContext<TContext, T>.SwallowUnhandled()
        {
            configuration.UnhandledExceptionBehaviour = UnhandledExceptionBehaviour.Swallow;
            return this;
        }

        public ITryOperationWithContext<TContext, T> Swallow()
        {
            handlers.AddHandler<Exception>(() => default);
            return this;
        }


        public ITryOperationWithContext<TContext, T> Log(Action<Exception> handler)
        {
            loggers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Log(Action<Exception, TContext> handler)
        {
            loggers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Log<TException>(Action<TException> handler)
            where TException : Exception
        {
            loggers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Log<TException>(Action<TException, TContext> handler)
            where TException : Exception
        {
            loggers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Log(Func<Exception, Task> handler)
        {
            loggers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Log(Func<Exception, TContext, Task> handler)
        {
            loggers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Log<TException>(Func<TException, Task> handler)
            where TException : Exception
        {
            loggers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Log<TException>(Func<TException, TContext, Task> handler)
            where TException : Exception
        {
            loggers.AddAsyncHandler(handler);
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


        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch(Func<Task> handler)
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

        public ITryOperationWithContext<TContext, T> Catch(Func<Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch(Func<TContext, Task> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, TContext, Task> handler) where TException : Exception
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

        public ITryOperationWithContext<TContext, T> Catch(Func<TContext, Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception
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

        #region ITryOperationWithContext (Void)

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Swallow()
        {
            Swallow();
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.SwallowUnhandled()
        {
            configuration.UnhandledExceptionBehaviour = UnhandledExceptionBehaviour.Swallow;
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log(Action<Exception> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log(Action<Exception, TContext> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log<TException>(Action<TException> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log<TException>(Action<TException, TContext> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log(Func<Exception, Task> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log(Func<Exception, TContext, Task> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log<TException>(Func<TException, Task> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Log<TException>(Func<TException, TContext, Task> handler)
        {
            Log(handler);
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

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch(Func<Task> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch<TException>(Func<Task> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch<TException>(Func<TException, Task> handler)
        {
            Catch(handler);
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

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch(Func<TContext, Task> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperationWithContext<TContext> IHandleableTryOperationWithContext<TContext>.Catch<TException>(Func<TException, TContext, Task> handler)
        {
            Catch(handler);
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

        ITryOperation<T> IHandleableTryOperation<T>.SwallowUnhandled()
        {
            configuration.UnhandledExceptionBehaviour = UnhandledExceptionBehaviour.Swallow;
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Log(Action<Exception> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Log<TException>(Action<TException> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Log(Func<Exception, Task> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Log<TException>(Func<TException, Task> handler)
        {
            Log(handler);
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

        ITryOperation<T> IHandleableTryOperation<T>.Catch(Func<Task> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Func<Task> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Func<TException, Task> handler)
        {
            Catch(handler);
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

        ITryOperation<T> IHandleableTryOperation<T>.Catch(Func<Task<T>> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Func<Task<T>> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<T> IHandleableTryOperation<T>.Catch<TException>(Func<TException, Task<T>> handler)
        {
            Catch(handler);
            return this;
        }

        #endregion

        #region ITryOperation (Void)

        ITryOperation IHandleableTryOperation.Swallow()
        {
            Swallow();
            return this;
        }

        ITryOperation IHandleableTryOperation.SwallowUnhandled()
        {
            configuration.UnhandledExceptionBehaviour = UnhandledExceptionBehaviour.Swallow;
            return this;
        }

        ITryOperation IHandleableTryOperation.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }

        ITryOperation IHandleableTryOperation.Log(Action<Exception> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.Log<TException>(Action<TException> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.Log(Func<Exception, Task> handler)
        {
            Log(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.Log<TException>(Func<TException, Task> handler)
        {
            Log(handler);
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

        ITryOperation IHandleableTryOperation.Catch(Func<Task> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.Catch<TException>(Func<Task> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation IHandleableTryOperation.Catch<TException>(Func<TException, Task> handler)
        {
            Catch(handler);
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

                try
                {
                    if (handler == null)
                    {
                        if (configuration.UnhandledExceptionBehaviour == UnhandledExceptionBehaviour.Throw)
                            throw e;
                        else
                            return default;
                    }

                    return handler.Execute(context, e);
                }
                catch(Exception rethrownException)
                {
                    throw rethrownException;
                }
                finally
                {
                    HandleLogging(context, e, handler != null);
                }
            }
            finally
            {
                try
                {
                    handlers.GetFinallyHandler()?.Execute(context, null);
                }
                catch (Exception finallyException)
                {
                    if (configuration.FinallyExceptionBehaviour == ExceptionBehaviour.RedirectToDefaultLogger)
                        LogToDefaultLogger(context, finallyException);
                }
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

                try
                {
                    if (handler == null)
                    {
                        if (configuration.UnhandledExceptionBehaviour == UnhandledExceptionBehaviour.Throw)
                            return new TryResult<T>(e);
                        else
                            return new TryResult<T>();
                    }

                    return new TryResult<T>(handler.Execute(context, e));
                }
                catch (Exception rethrownException)
                {
                    return new TryResult<T>(rethrownException);
                }
            }
            finally
            {
                try
                {
                    handlers.GetFinallyHandler()?.Execute(context, null);
                }
                catch(Exception finallyException)
                {
                    if (configuration.FinallyExceptionBehaviour == ExceptionBehaviour.RedirectToDefaultLogger)
                        LogToDefaultLogger(context, finallyException);
                }
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

                try
                {
                    if (handler == null)
                    {
                        if (configuration.UnhandledExceptionBehaviour == UnhandledExceptionBehaviour.Throw)
                            throw e;
                        else
                            return default;
                    }

                    return await handler.ExecuteAsync(context, e).ConfigureAwait(false);
                }
                catch (Exception rethrownException)
                {
                    throw rethrownException;
                }
                finally
                {
                    await HandleLoggingAsync(context, e, handler != null);
                }
            }
            finally
            {
                var finallyHandler = handlers.GetFinallyHandler();
                try
                {
                    await finallyHandler.ExecuteAsync(context, null).ConfigureAwait(false);
                }
                catch (Exception finallyException)
                {
                    if (configuration.FinallyExceptionBehaviour == ExceptionBehaviour.RedirectToDefaultLogger)
                        await LogToDefaultLoggerAsync(context, finallyException);
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

                try
                {
                    if (handler == null)
                    {
                        if (configuration.UnhandledExceptionBehaviour == UnhandledExceptionBehaviour.Throw)
                            return new TryResult<T>(e);
                        else
                            return new TryResult<T>();
                    }

                    return new TryResult<T>(await handler.ExecuteAsync(context, e).ConfigureAwait(false));
                }
                catch (Exception rethrownException)
                {
                    return new TryResult<T>(rethrownException);
                }
                finally
                {
                    await HandleLoggingAsync(context, e, handler != null);
                }
            }
            finally
            {
                var finallyHandler = handlers.GetFinallyHandler();
                if (finallyHandler != null)
                    try
                    {
                        await finallyHandler.ExecuteAsync(context, null).ConfigureAwait(false);
                    }
                    catch(Exception finallyException)
                    {
                        if (configuration.FinallyExceptionBehaviour == ExceptionBehaviour.RedirectToDefaultLogger)
                            await LogToDefaultLoggerAsync(context, finallyException);
                    }
            }
        }

        #endregion ExecuteAsync

        #region Logging

        public void LogToDefaultLogger(TContext context, Exception e)
        {
            try
            {
                configuration.DefaultLogger?.Invoke(e, context);
            }
            catch (Exception defaultLoggerException)
            {
                if (configuration.DefaultLoggerExceptionBehaviour == DefaultLoggerExceptionBehaviour.Throw)
                    throw defaultLoggerException;
            }
        }

        public Task LogToDefaultLoggerAsync(TContext context, Exception e)
        {
            try
            {
                return configuration.DefaultLogger?.InvokeAsync(e, context);
            }
            catch (Exception defaultLoggerException)
            {
                if (configuration.DefaultLoggerExceptionBehaviour == DefaultLoggerExceptionBehaviour.Throw)
                    throw defaultLoggerException;
                else
                    return Task.CompletedTask;
            }
        }

        private void HandleLogging(TContext context, Exception e, bool handled)
        {
            if (handled && configuration.LoggerBehaviour == LoggerBehaviour.UnhandledOnly)
                return;

            try
            {
                var logger = loggers.GetHandler(e.GetType());
                if (logger != null)
                    logger.Execute(context, e);
                else
                    configuration.DefaultLogger?.Invoke(e, context);
            }
            catch(Exception loggerException)
            {
                if (configuration.LoggerExceptionBehaviour == ExceptionBehaviour.Throw)
                    throw loggerException;
                else if (configuration.LoggerExceptionBehaviour == ExceptionBehaviour.RedirectToDefaultLogger)
                    LogToDefaultLogger(context, e);
            }
        }

        public Task HandleLoggingAsync(TContext context, Exception e, bool handled)
        {
            if (handled && configuration.LoggerBehaviour == LoggerBehaviour.UnhandledOnly)
                return Task.CompletedTask;

            try
            {
                var logger = loggers.GetHandler(e.GetType());
                if (logger != null)
                    return logger.ExecuteAsync(context, e);
                else if (configuration.DefaultLogger != null)
                    return configuration.DefaultLogger.InvokeAsync(e, context);
                else
                    return Task.CompletedTask;
            }
            catch (Exception loggerException)
            {
                if (configuration.LoggerExceptionBehaviour == ExceptionBehaviour.Throw)
                    throw loggerException;
                else if (configuration.LoggerExceptionBehaviour == ExceptionBehaviour.RedirectToDefaultLogger)
                    LogToDefaultLoggerAsync(context, e);

                return Task.CompletedTask;
            }
        }

        #endregion Logging
    }
}