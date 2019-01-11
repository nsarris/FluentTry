using FluentTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class TestContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var result1 =
                    await Try
                        .WithContext(new TestContext
                        {
                            Id = 1,
                            Name = "Test"
                        })
                        .WithConfiguration(config => config
                            .WithExceptionHandlerSequenceBehaviour(ExceptionHandlerSequenceBehaviour.AutoOrder)
                        )
                        .Do(async (context) =>
                        {
                            await Task.Delay(100);
                            throw new InvalidOperationException();
                            return 5;
                        })
                        //.Swallow()
                        //.Catch<Exception>(async (ex, context) => { Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); return 2; })
                        //.Catch(async ex => { Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); return 2; })
                        //.Catch(async (Exception ex) => { await Task.Delay(2000); Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); })
                        //.Catch(() => { throw new Exception(); })
                        .Catch<Exception>((Exception ex) => { Console.WriteLine("Caught " + nameof(Exception)); if (int.MinValue > 0) throw ex; })
                        .Catch<InvalidOperationException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); if (int.MinValue > 0) throw ex; })
                        //.Finally((context) => Console.WriteLine("Finally"))
                        .ExecuteAsync();
                //.GetValueOrThrow();

                Console.WriteLine(result1);

                var result2 =
                    Try
                    .WithContext(new TestContext
                    {
                        Id = 1,
                        Name = "Test"
                    })
                    .Do((context) =>
                    {
                        throw new InvalidOperationException();
                        return 5;
                    })

                //.Swallow()
                .Catch<Exception>(ex => { Console.WriteLine("Caught " + nameof(Exception)); if (int.MinValue > 0) throw ex; })
                .Catch<InvalidCastException>(ex => { Console.WriteLine("Caught " + nameof(InvalidCastException)); })
                .Catch<InvalidOperationException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); })
                //.Catch<Exception>(async ex => { Console.WriteLine("Caught " + nameof(Exception)); })
                //.Catch<InvalidCastException>(async ex => { Console.WriteLine("Caught " + nameof(InvalidCastException)); })
                //.Catch<InvalidOperationException>(async ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); })
                .Finally(() => Console.WriteLine("Finally"))
                .Execute();
                //.Value;

                //Console.WriteLine(result2);
            }

            catch (Exception e)
            {
                Console.WriteLine("Rethrown unhandled exception: " + e.ToString());
            }

            Console.ReadKey();
        }

        private static void Test()
        {
            ITest<string, int> t = null;
            t.Catch(() => { throw new Exception(); });
            t.Catch<Exception>(() => { throw new Exception(); });
            t.Catch(() => { throw new Exception(); return 0; });
            t.Catch<Exception>((e) => { throw e; return 0; });

            t.CatchAsync<Exception>(async (e) => { await Task.Delay(1); throw new Exception(); });

            t.Catch<Exception>((e) => 0);
            t.CatchAsync<Exception>(async (Exception e) => { await Task.Delay(1); return 0; });

            //t.Catch1(async (Exception e) => { return 0; });
        }
    }

    interface ITest<TContext,T> 
    {
        ITest<TContext, T> Catch(Action handler);
        ITest<TContext, T> Catch<TException>(Action handler) where TException : Exception;
        ITest<TContext, T> Catch<TException>(Action<TException> handler) where TException : Exception;

        ITest<TContext, T> Catch(Action<TContext> handler);
        ITest<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITest<TContext, T> CatchAsync(Func<Task> handler);
        ITest<TContext, T> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITest<TContext, T> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;

        ITest<TContext, T> CatchAsync(Func<TContext, Task> handler);
        ITest<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception;

        ITest<TContext, T> Catch(Func<T> handler);
        ITest<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITest<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception;

        ITest<TContext, T> Catch(Func<TContext, T> handler);
        ITest<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception;

        ITest<TContext, T> CatchAsync(Func<Task<T>> handler);
        ITest<TContext, T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception;
        ITest<TContext, T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception;

        ITest<TContext, T> CatchAsync(Func<TContext, Task<T>> handler);
        ITest<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception;
    }

    static class TestExtensions
    {
        public static T Catch1<T, TContext, TResult, TException>(this T t, Func<TException, Task<TResult>> func)
            where T : ITest<TContext, TResult>
            where TException : Exception
        {
            t.CatchAsync(func);
            return t;
        }
    }

    
}
