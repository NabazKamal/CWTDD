using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CWTDDTests
{
    public class OddTimesNumber
    {
        [Theory]
        [InlineData(new int[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }, 5)]
        public void OddNumber_ArrayOfNumbers_ReturnsOdd(int[] input, int expected)
        {
            OddTimeNumberFinder ot = new OddTimeNumberFinder();
            int i = ot.find_it(input);
            Assert.Equal(expected, i);
        }
    }

    internal class OddTimeNumberFinder
    {
        internal int find_it(int[] vs)
        {

            //Dictionary<int, int> count = vs.ToList().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            // return count.Where(x => x.Value % 2 != 0).First().Key;
            return vs.GroupBy(x => x)
                     .ToDictionary(x => x.Key, x => x.Count())//;
                     .Where(x => x.Value % 2 != 0).First().Key;
        }
    }
}
