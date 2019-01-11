using FluentTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public  class TestContext
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
                        .DoAsync(async (context) =>
                        {
                            await Task.Delay(100);
                            throw new InvalidOperationException();
                            return 5;
                        })
                        //.Swallow()
                        //.CatchAsync<Exception>(async (ex, context) => { Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); return 2; })
                        //.CatchAsync(async ex => { Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); return 2; })
                        //.CatchAsync(async (Exception ex) => { await Task.Delay(2000); Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); })
                        .Catch<Exception>(ex => { Console.WriteLine("Caught " + nameof(Exception)); throw ex; })
                        .Catch<InvalidOperationException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); throw ex; })
                        .Finally((context) => Console.WriteLine("Finally"))
                        .ExecuteAsync();
                        //.GetValueOrThrow();
                

                Console.WriteLine(result1);

                var result2 = Try.Do(() =>
                {
                    throw new InvalidOperationException();
                    return 5;
                })
                //.Swallow()
                //.Catch<Exception>(ex => { Console.WriteLine("Caught " + nameof(Exception)); })
                //.Catch<InvalidCastException>(ex => { Console.WriteLine("Caught " + nameof(InvalidCastException)); })
                //.Catch<InvalidOperationException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); })
                //.Finally(() => Console.WriteLine("Finally"))
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
            Test1(() => { });
            Test1(async () => { await Task.Delay(1); });
        }

        private static void Test1(Action a) { }
        private static void Test1(Func<Task> a) { }

    }
}
