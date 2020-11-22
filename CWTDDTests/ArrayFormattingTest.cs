using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CWTDDTests
{
    public class ArrayFormattingTest
    {
    //[Fact]
        public void ArrayFormatting_Test1()
        {
            ArrayFormatter ar = new ArrayFormatter();
            var expected = "1-2, 4-6,9";
            int[] input = new int[] { 1, 2, 4, 5, 6, 9};
            var res = ar.Extract(input);
            Assert.Equal(expected, res);
        }
    }

    internal class ArrayFormatter
    {
        internal string Extract(int[] input)
        {
            StringBuilder sb = new StringBuilder();
            List<int> ints = new List<int>();
            LinkedList<string> ll = new LinkedList<string>();
            ints.AddRange(input);
            int counter = ints[0];
            foreach(var i in ints)
            {
                string value = "";
                if (i == counter)
                    value = i.ToString();
                else
                    value = ", " + i.ToString() ;
                counter = i+1;
                sb.Append(value);
            }
            return sb.ToString().Remove(sb.Length-2,2);
        }
    }
}
