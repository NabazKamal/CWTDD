using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CWTDDTests.SnakesAndLadders
{
    public class SnakesAndLaddersTest
    {
        //Rules:

        /*
        1.  There are two players and both start off the board on square 0.

        2.  Player 1 starts and alternates with player 2.

        3.  You follow the numbers up the board in order 1=>100

        4.  If the value of both die are the same then that player will have another go.

        5.  Climb up ladders. The ladders on the game board allow you to move upwards and get ahead faster. If you land exactly on a square that shows an image of the bottom of a ladder, then you may move the player all the way up to the square at the top of the ladder. (even if you roll a double).

        6.  Slide down snakes. Snakes move you back on the board because you have to slide down them. If you land exactly at the top of a snake, slide move the player all the way to the square at the bottom of the snake or chute. (even if you roll a double).

        7.  Land exactly on the last square to win. The first person to reach the highest square on the board wins. But there's a twist! If you roll too high, your player "bounces" off the last square and moves back. You can only win by rolling the exact number needed to land on the last square. For example, if you are on square 98 and roll a five, move your game piece to 100 (two moves), then "bounce" back to 99, 98, 97 (three, four then five moves.)

        8.  If the Player rolled a double and lands on the finish square “100” 
        without any remaining moves then the Player wins the game and does not have to roll again.
         * 
         */


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
