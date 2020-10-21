using NSubstitute;
using System;
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

        private interface IRepository
        {
        }
    }

    public class Kata{
        public bool IsSquare(double i)
        {
            return Math.Sqrt(i) % 1 == 0;
        }
    }
}
