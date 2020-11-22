using CWTDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace CWTDDTests
{
    public class ArrayHandler
    {
        [Fact]
            public void Array_ReturnsUniqueInOrder()
        {
            IEnumerable<string> input = new List<string> { "1", "2", "3","3","3", "4", "2"};

            var kata = LocalKata<string>.UniqueInOrder(input);
            //IEnumerable<int> res = kata.UniqueInOrder(input);
            string[] expected = { "1", "2", "3", "4" };
            Assert.Equal(expected, kata);
        }

        //[Fact]
        public void DeleteNth_List_ReturnsNewArray()
        {
            var kata = new ArrayKata();
            int[] expected = { 1, 2 ,3};
            int[] input = new int[] { 1, 2, 1, 3 };
            int[] res = kata.DeleteNth(input, 1);
            Assert.Equal(expected, res);
        }
    }

    internal class ArrayKata
    {
        public ArrayKata()
        {
        }

        internal int[] DeleteNth(int[] input, int v)
        {
            //var res = input.Select(x => x).ToList().Take(v);
            List<int> list = input.ToList();//.OrderByDescending(x => x).ToList();
            List<int> list2 = new List<int>();//.OrderByDescending(x => x).ToList();
                                              //list2.AddRange(input.Reverse());

            // List<int> res = Enumerable.Repeat(input.Select(x => x), v).ToList();

            //foreach (var item in list.ToList())
            //{
            //    if (list2.Where(x => x == item).Count() < count)
            //        list2.Add(item);
            //}
            //return list2.ToArray();

            //return input<
            foreach (var item in list.ToList())
            {
                if (list.Where(x => x == item).Count() > 1)
                    list.Remove(item);
            }
             list.Reverse();
            return list.ToArray();
        }

        private bool Redudance(int i, List<int> list)
        {
            return list.Where(x=>x == i).Count() >1;
        }
    }

    internal static class LocalKata <T> where T:class
    {
        internal static IEnumerable<T> UniqueInOrder(IEnumerable<T> input)
        {
            return input.ToList().GroupBy(x => x).ToDictionary(x=>x.Key).Keys;
        }
    }
}
