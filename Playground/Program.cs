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
            Try.SetDefaultConfiguration(config => config
                .WithExceptionHandlerSequenceBehaviour(ExceptionHandlerSequenceBehaviour.AutoOrder)
                .WithLoggerBehaviour(LoggerBehaviour.Everything)
                .WithUnhandledExceptionBehaviour(UnhandledExceptionBehaviour.Swallow)
                .WithLoggerExceptionBehaviour(ExceptionBehaviour.RedirectToDefaultLogger)
                .WithDefaultLogger((e, c) => {
                    Console.WriteLine("Default Logger: " + e.ToString());
                    Console.WriteLine("Context was: " + c?.ToString());
                })
            );

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
                        //.Catch<Exception>((Exception ex) => { Console.WriteLine("Caught " + nameof(Exception)); if (int.MinValue > 0) throw ex; })
                        //.Catch<InvalidOperationException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); if (int.MinValue > 0) throw ex; })
                        .Catch<NullReferenceException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); })
                        .SwallowUnhandled()
                        .Finally((context) => Console.WriteLine("Finally"))
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
    }
}
