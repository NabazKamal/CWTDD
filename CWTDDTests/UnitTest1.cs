using CWTDD;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CWTDDTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(25, true)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(0, true)]
        public void Test1(double input, bool expected)
        {
            var mock = Substitute.For<IRepository>();
            Kata kata = new Kata();
            bool square = kata.IsSquare(input);
            Assert.Equal(expected, square);
        }

        [Fact]
        public void Vowels_ReturnsNumberOfVowels()
        {
            VowelCounter vc = new VowelCounter();
            string str = "Hello friend";
            var count = vc.GetVowelCount(str);
            Assert.Equal(4, count);
        }

        [Fact]
        public void TowNumbers_ReturnsBinary()
        {
            SUT sut = new SUT();
            string res = sut.AddBinary(6, 3);
            Assert.Equal("1001", res);
        }

        [Fact]
        public void TwoStrings_ReturnsOneSortedString()
        {
            SUT sut = new SUT();
            string s1 = "hehe"; string s2 = "adb";
            string res = sut.Longest(s1, s2);
            Assert.Equal("abdeh", res);
        }

        private class VowelCounter
        {
            public VowelCounter()
            {
            }

            internal int GetVowelCount(string str)
            {
                HashSet<char> hs = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
                return str.Where(x=> hs.Contains(x) ).ToList().Count;
            }
        }

        private class SUT
        {
            public SUT()
            {
            }

            internal string AddBinary(int v1, int v2)
            {
                var sum = v1 + v2;
                return Convert.ToString(sum, 2);
            }

            internal string Longest(string s1, string s2)
            {
                List<char> strList = new List<char>();
                strList.AddRange((s1 + s2).ToArray().Distinct().OrderBy(x => x));
                return new string(strList.ToArray());
            }
        }
    }
    public interface IRepository
    {
    }

}
