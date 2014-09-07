﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class AsyncExcept
    {
        public static async Task<IEnumerable<T>> ExceptAsync<T>(this Task<IEnumerable<T>> first, Task<IEnumerable<T>> second)
        {
            Contract.Requires<ArgumentNullException>(first != null);
            Contract.Requires<ArgumentNullException>(second != null);

            IEnumerable<T>[] whenAllResults = await Task.WhenAll(first, second);
            return whenAllResults[0].Except(whenAllResults[1]);
        }

        public static async Task<IEnumerable<T>> ExceptAsync<T>(this IEnumerable<Task<T>> first, IEnumerable<Task<T>> second)
        {
            Contract.Requires<ArgumentNullException>(first != null);
            Contract.Requires<ArgumentNullException>(second != null);

            T[][] whenAllResults = await Task.WhenAll(Task.WhenAll(first), Task.WhenAll(second));
            return whenAllResults[0].Except(whenAllResults[1]);
        }

        public static async Task<IEnumerable<T>> ExceptAsync<T>(this Task<IEnumerable<T>> first, Task<IEnumerable<T>> second, IEqualityComparer<T> comparer)
        {
            Contract.Requires<ArgumentNullException>(first != null);
            Contract.Requires<ArgumentNullException>(second != null);
            Contract.Requires<ArgumentNullException>(comparer != null);

            IEnumerable<T>[] whenAllResults = await Task.WhenAll(first, second);
            return whenAllResults[0].Except(whenAllResults[1], comparer);
        }

        public static async Task<IEnumerable<T>> ExceptAsync<T>(this IEnumerable<Task<T>> first, IEnumerable<Task<T>> second, IEqualityComparer<T> comparer)
        {
            Contract.Requires<ArgumentNullException>(first != null);
            Contract.Requires<ArgumentNullException>(second != null);
            Contract.Requires<ArgumentNullException>(comparer != null);

            T[][] whenAllResults = await Task.WhenAll(Task.WhenAll(first), Task.WhenAll(second));
            return whenAllResults[0].Except(whenAllResults[1], comparer);
        }
    }
}
