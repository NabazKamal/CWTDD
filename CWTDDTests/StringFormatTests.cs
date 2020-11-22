using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Xunit;

namespace CWTDDTests
{
    public class StringFormatTests
    {
        [Theory]
        [InlineData(0, "00:00:00")]
        [InlineData(5, "00:00:05")]
        [InlineData(60, "00:01:00")]
        [InlineData(86399, "23:59:59")]
        [InlineData(359999, "99:59:59")]
        public void StringFormat_TimeInSecunds_ReturnsFormatedTime(int input, string expected)
        {
            StringFormatter sf = new StringFormatter();
            string result = sf.GetReadableTime(input);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);
            Assert.Equal(expected, result);

        }

        [Fact]
        public void StringFormat_IntArray_SortOddNumbers()
        {
            StringFormatter sf = new StringFormatter();
            int[] array = new int[] {2, 1, 4, 5, 3 };
            int[] expected = new int[] {2, 1, 4, 3, 5 };
            int[] res = sf.SortArray2(array);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(new int[] {2,2,1}, 1)]
        [InlineData(new int[] {1,3,2,4,2,2,2,1}, 3)]
        public void StringFormat_IntArray_FindUnique(int[] input, int expected)
        {
            StringFormatter sf = new StringFormatter();
            int i = sf.FindUnique(input);
            Assert.Equal(expected, i);
        }
    }

    internal class StringFormatter
    {
        internal int FindUnique(int[] input)
        {
            return input.GroupBy(x => x)
                        .Where(x => x.Count() == 1).First().Key;
                        //.ToDictionary(x => x.Key, x => x.Count()).Keys.First();
        }

        internal string GetReadableTime(int input)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(input);

            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    (int)timeSpan.TotalHours,
                                    timeSpan.Minutes,
                                    timeSpan.Seconds);
        }

        internal int[] SortArray(int[] array)
        {
            //give the numbers an index
            var indexedArray = array.Select((num, indx) => new { num, indx }).ToList();
            var odds = indexedArray.Where(x => x.num % 2 == 1);
            var evens = indexedArray.Where(x => x.num % 2 == 0);
            var sortedOdds = odds.OrderBy(x => x.num);
            var reindexedArray = sortedOdds.Zip(odds, (o1,o2) => new { o1.num, o2.indx});
            var sortedArray = evens.Concat(reindexedArray).OrderBy(x => x.indx).Select(x => x.num);

            return sortedArray.ToArray();

            // array;
            //return array.OrderBy(x => x % 2==1).ToArray();
        }

        internal int[] SortArray2(int[] array)
        {
            Queue<int> odds = new Queue<int>(array.Where(e => e % 2 == 1).OrderBy(e => e));

            return array.Select(e => e % 2 == 1 ? odds.Dequeue() : e).ToArray();
        }
    }
}
