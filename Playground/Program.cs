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
                        .With(new TestContext
                        {
                            Id = 1,
                            Name = "Test"
                        })
                        .DoAsync(async (context) =>
                        {
                            await Task.Delay(100);
                            throw new InvalidOperationException();
                            return 5;
                        })
                        .WithExceptionHandlerSequenceBehaviour(ExceptionHandlerSequenceBehaviour.AutoOrder)
                        //.Swallow()
                        //.CatchAsync<Exception>(async (ex, context) => { Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); return 2; })
                        //.Catch<Exception>(async ex => { await Task.Delay(2000); Console.WriteLine("Caught " + nameof(Exception)); await Task.Delay(1); })
                        .Catch<Exception>(ex => { Console.WriteLine("Caught " + nameof(Exception)); throw ex; })
                        .Catch<InvalidOperationException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); throw ex; })
                        .Finally((context) => Console.WriteLine("Finally"))
                        .ExecuteAsync();
                        //.GetValueOrThrow();
                

                Console.WriteLine(result1);
                
                //var result2 = Try.Do(() =>
                //{
                //    throw new InvalidOperationException();
                //    return 5;
                //})
                //.Swallow()
                //.Catch<Exception>(ex => { Console.WriteLine("Caught " + nameof(Exception)); })
                ////.Catch<InvalidCastException>(ex => { Console.WriteLine("Caught " + nameof(InvalidCastException)); })
                ////.Catch<InvalidOperationException>(ex => { Console.WriteLine("Caught " + nameof(InvalidOperationException)); })
                //.Finally(() => Console.WriteLine("Finally"))
                //.Execute();
                ////.Value;

                //Console.WriteLine(result2);
            }
            
            catch(Exception e)
            {
                Console.WriteLine("Rethrown unhandled exception: " + e.ToString());
            }

            Console.ReadKey();
        }
    }
}
