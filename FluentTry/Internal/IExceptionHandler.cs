using System;
using System.Threading.Tasks;

namespace FluentTry
{
    internal interface IExceptionHandler<TContext, T>
        where TContext : class
    {
        T Execute(TContext context, Exception e);
        Task<T> ExecuteAsync(TContext context, Exception e);
    }
}