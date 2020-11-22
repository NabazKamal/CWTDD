using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CWTDDTests.SnakesAndLadders
{
    public class SnakesAndLaddersTest
    {
        //Rules:
        //
        [Fact]
        public void SnakesAndLadders_Test1()
        {
            SnakesAndLaders game = new SnakesAndLaders();
            int die1 = 1, die2 = 1;
            var result = game.Play("Player 1", die1, die2);
            var expected = "Player 1 is on square 38";
            Assert.Equal(result, expected);
        }

        [Fact]
        public void SnakesAndLadders_Test2()
        {
            SnakesAndLaders game = new SnakesAndLaders();
            int die1 = 1, die2 = 2;
            var result = game.Play("Player 2",die1, die2);
            var expected = "Player 2 is on square 3";
            Assert.Equal(result, expected);
        }
        [Fact]
        public void SnakesAndLadders_Test3()
        {
            SnakesAndLaders game = new SnakesAndLaders();
            int die1 = 5, die2 = 2;
            var result = game.Play("Player 1", die1, die2);
            var expected = "Player 1 is on square 14";
            Assert.Equal(result, expected);
        }
    }

    public class SnakesAndLaders
    {
        internal object Play(string player, int die1, int die2)
        {
            string res = string.Empty;
            int sum = die1 + die2;
            if (sum == 2)
                sum = 38;
            if (sum == 7)
                sum = 14;
            res = player + " is on square "+ sum.ToString();
            return res;

        }
    }
}
