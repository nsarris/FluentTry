﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentTry
{
    internal static class DictionaryExtensions
    {
        public static void Add<TKey,TElement>(this IDictionary<TKey,List<TElement>> dictionary, TKey key, TElement element)
        {
            if (dictionary.TryGetValue(key, out var elementList))
                elementList.Add(element);
            else
            {
                elementList = new List<TElement>{ element };
                dictionary.Add(key, elementList);
            }
        }
    }

    internal static class ExceptionExtensions
    {
        public static Exception FlattenRecursive(this AggregateException aggregateException)
        {
            var flattenedException = aggregateException.Flatten();
            while (flattenedException.InnerException is AggregateException)
                flattenedException = flattenedException.Flatten();
            return flattenedException;
        }
    }

    internal static class TypeExtensions
    {
        public static IEnumerable<Type> GetHierarchy(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }

        public static int GetHierarchyDepth(this Type type)
            => GetHierarchy(type).Count();
    }
}