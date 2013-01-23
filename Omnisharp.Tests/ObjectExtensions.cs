﻿using System.Collections.Generic;
using NUnit.Framework;

namespace Omnisharp.Tests
{
    public static class ObjectExtensions
    {
        public static void ShouldContainOnly<T>(this IEnumerable<T> actual, params T[] expected)
        {
            actual.ShouldContainOnly(new List<T>(expected));
        }

        public static void ShouldContainOnly<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
        {
            var actualList = new List<T>(actual);
            var remainingList = new List<T>(actualList);
            foreach (T item in expected)
            {
                Assert.Contains(item, actualList);
                remainingList.Remove(item);
            }
            Assert.IsEmpty(remainingList);
        }
    }
}