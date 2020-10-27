using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CWTDDTests
{
    public class SortTest
    {
        [Theory]
        [InlineData("ab1", "ab1")]
        [InlineData("ab2 bc1", "bc1 ab2")]
        public void StringSort_StringArray_SortByNumber(string input, string expected)
        {
            StringSorter ss = new StringSorter();
            string s = ss.Order(input);
            Assert.Equal(expected, s);

        }
    }

    internal class StringSorter
    {
        public StringSorter()
        {
        }

        internal string Order(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return string.Join(" ", input.Split(' ').OrderBy(x => x.ToList().Find(c => char.IsDigit(c))));
            //var res = input.Split(' ').ToList();
            //SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
            //foreach (var item in res)
            //{
            //    sortedDictionary.Add(item.Where(x => char.IsDigit(x)).First(), item);
            //}
            //return string.Join(" ", sortedDictionary.Values);
        }
    }
}
