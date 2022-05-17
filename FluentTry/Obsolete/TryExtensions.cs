//using System;
//using System.Threading.Tasks;

//namespace FluentTry
//{
//    //interface ITry<T>
//    //{
//    //    Exception? Exception { get; }
//    //    T? Result { get; }
//    //    ITry<T> Catch<TException>(Func<TException, T> handle);
//    //    AsyncTry<T> CatchAsync<TException>(Func<TException, Task<T>> handle);
//    //}

//    //interface ITry<TState, T> : ITry<T>
//    //{
//    //    TState State { get; }
//    //    ITry<TState, T> Catch<TException>(Func<TException, TState, T> handle);
//    //    new ITry<TState, T> Catch<TException>(Func<TException, T> handle);
//    //    AsyncTry<TState, T> CatchAsync<TException>(Func<TException, TState, Task<T>> handle);
//    //    new AsyncTry<TState, T> CatchAsync<TException>(Func<TException, Task<T>> handle);
//    //}

//    public static class TryExtensions
//    {
//        public static T Catch<T, TState, TException, TResult>(this T @try, Func<TException, TState, TResult> handle)
//            where T : Try<TState, TResult>
//            where TException : Exception
//        {
//            if (@try.Exception is TException exception)
//            {
//                try
//                {
//                    @try.Result = handle(exception, @try.State);
//                }
//                catch (Exception ex)
//                {
//                    if (ex != @try.Exception)
//                        @try.Exception = ex;
//                }
//            }

//            return @try;
//        }

//        //public static T Catch<T, TException, TResult>(this T @try, Func<TException, TResult> handle)
//        //    where T : Try<TResult>
//        //    where TException : Exception
//        //{
//        //    if (@try.Exception is TException exception)
//        //    {
//        //        try
//        //        {
//        //            @try.Result = handle(exception, @try.State);
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            if (ex != @try.Exception)
//        //                @try.Exception = ex;
//        //        }
//        //    }

//        //    return @try;
//        //}


//        public async static Task<T> CatchAsync<T, TResult, TException, TState>(this T @try, Func<TException, TState, Task<TResult>> handle)
//            where T : Try<TState, TResult>
//        {
//            if (@try.Exception is TException exception)
//            {
//                try
//                {
//                    @try.Result = await handle(exception, @try.State);
//                }
//                catch (Exception ex)
//                {
//                    if (ex != @try.Exception)
//                        @try.Exception = ex;
//                }
//            }

//            return @try;
//        }

//        public async static Task<T> CatchAsync<T, TResult, TException>(this T @try, Func<TException, Task<TResult>> handle)
//            where T : Try<TResult>
//        {
//            if (@try.Exception is TException exception)
//            {
//                try
//                {
//                    @try.Result = await handle(exception);
//                }
//                catch (Exception ex)
//                {
//                    if (ex != @try.Exception)
//                        @try.Exception = ex;
//                }
//            }

//            return @try;
//        }

//        public static Task<T> CatchAsync1<T, TResult, TException>(this T @try, Func<TException, Task<TResult>> handle)
//            where T : Try<TResult>
//        {
//            if (@try.Exception is TException exception)
//            {
//                try
//                {
//                    return handle(exception).ChainAwait((task, t) =>
//                    {
//                        t!.FromTask(task);
//                        return t;
//                    }, @try);
//                }
//                catch (Exception ex)
//                {
//                    @try.Exception = ex;
//                }
//            }

//            return Task.FromResult(@try);
//        }
//    }
//}
