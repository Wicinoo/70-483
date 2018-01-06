//D. There is YatzyCalculator class in TaskD.cs Implement all methods of the class by using LINQ statements.
//Use pre-prepared XUnit unit tests to speed up your implementation.

using System;
using System.Linq;
using System.Net.Sockets;
using Xunit;
using Xunit.Extensions;
using Xunit.Sdk;

namespace Lessons._15
{
    public class YatzyCalculatorTests
    {
        private readonly YatzyCalculator _yatzyCalculator = new YatzyCalculator();

        // Chance: The player scores the sum of all dice, no matter what they read. For example,
        // • 1,1,3,3,6 placed on “chance” scores 14 (1+1+3+3+6)
        // • 4,5,5,6,1 placed on “chance” scores 21 (4+5+5+6+1)

        [Theory]
        [InlineData(new[] { 1, 1, 3, 3, 6 }, 14)]
        [InlineData(new[] { 4, 5, 5, 6, 1 }, 21)]
        public void Chance_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Chance(dice));
        }

        // Yatzy: If all dice have the same number, the player scores 50 points. For example,
        // • 1,1,1,1,1 placed on “yatzy” scores 50
        // • 1,1,1,2,1 placed on “yatzy” scores 0

        [Theory]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, 50)]
        [InlineData(new[] { 1, 1, 1, 2, 1 }, 0)]
        [InlineData(new[] { 6, 6, 6, 6, 6 }, 50)]
        public void Yatzy_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Yatzy(dice));
        }

        // Ones, Twos, Threes, Fours, Fives, Sixes: The player scores
        // the sum of the dice that reads one, two, three, four, five or six,
        // respectively.For example,
        // • 1,1,2,4,4 placed on “fours” scores 8 (4+4)
        // • 2,3,2,5,1 placed on “twos” scores 4 (2+2)
        // • 3,3,3,4,5 placed on “ones” scores 0

        [Theory]
        [InlineData(new[] { 1, 1, 2, 4, 4 }, 2)]
        [InlineData(new[] { 2, 3, 2, 6, 2 }, 0)]
        public void Ones_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Ones(dice));
        }

        [Theory]
        [InlineData(new[] { 2, 3, 2, 5, 1 }, 4)]
        [InlineData(new[] { 2, 2, 2, 2, 2 }, 10)]
        public void Twos_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Twos(dice));
        }

        [Theory]
        [InlineData(new[] { 2, 3, 2, 5, 1 }, 3)]
        [InlineData(new[] { 1, 2, 3, 4, 3 }, 6)]
        [InlineData(new[] { 1, 2, 6, 4, 1 }, 0)]
        public void Threes_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Threes(dice));
        }

        [Theory]
        [InlineData(new[] { 2, 4, 4, 4, 1 }, 12)]
        [InlineData(new[] { 1, 2, 3, 4, 3 }, 4)]
        [InlineData(new[] { 1, 2, 6, 1, 1 }, 0)]
        public void Fours_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Fours(dice));
        }

        [Theory]
        [InlineData(new[] { 2, 5, 4, 4, 1 }, 5)]
        [InlineData(new[] { 5, 5, 5, 5, 5 }, 25)]
        [InlineData(new[] { 1, 2, 6, 1, 1 }, 0)]
        public void Fives_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Fives(dice));
        }

        [Theory]
        [InlineData(new[] { 1, 5, 2, 6, 1 }, 6)]
        [InlineData(new[] { 5, 5, 5, 5, 5 }, 0)]
        public void Sixes_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Sixes(dice));
        }

        // Pair: The player scores the sum of the two highest matching dice. For example, when placed on “pair”
        // • 3,3,3,4,4 scores 8 (4+4)
        // • 1,1,6,2,6 scores 12 (6+6)
        // • 3,3,3,4,1 scores 6 (3+3)
        // • 3,3,3,3,1 scores 6 (3+3)

        [Theory]
        [InlineData(new[] { 3, 3, 3, 4, 4 }, 8)]
        [InlineData(new[] { 1, 1, 6, 2, 6 }, 12)]
        [InlineData(new[] { 3, 3, 3, 4, 1 }, 6)]
        [InlineData(new[] { 3, 3, 3, 3, 1 }, 6)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 0)]
        public void Pair_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.Pair(dice));
        }

        // Two pairs: If there are two pairs of dice with the same number, 
        // the player scores the sum of these dice. For example, when placed on “two pairs”
        // • 1,1,2,3,3 scores 8 (1+1+3+3)
        // • 1,1,2,3,4 scores 0
        // • 1,1,2,2,2 scores 6 (1+1+2+2)

        [Theory]
        [InlineData(new[] { 1, 1, 2, 3, 3 }, 8)]
        [InlineData(new[] { 1, 1, 2, 3, 4 }, 0)]
        [InlineData(new[] { 1, 1, 2, 2, 2 }, 6)]
        public void TwoPairs_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.TwoPairs(dice));
        }

        // Three of a kind: If there are three dice with the same number,
        // the player scores the sum of these dice. For example, when placed on “three of a kind”
        // • 3,3,3,4,5 scores 9 (3+3+3)
        // • 3,3,4,5,6 scores 0
        // • 3,3,3,3,1 scores 9 (3+3+3)

        [Theory]
        [InlineData(new[] { 3, 3, 3, 4, 5 }, 9)]
        [InlineData(new[] { 3, 3, 4, 5, 6 }, 0)]
        [InlineData(new[] { 3, 3, 3, 3, 1 }, 9)]
        public void ThreeOfKind_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.ThreeOfKind(dice));
        }

        // Four of a kind: If there are four dice with the same number,
        // the player scores the sum of these dice. For example, when placed on “four of a kind”
        // • 2,2,2,2,5 scores 8 (2+2+2+2)
        // • 2,2,2,5,5 scores 0
        // • 2,2,2,2,2 scores 8 (2+2+2+2)

        [Theory]
        [InlineData(new[] { 2, 2, 2, 2, 5 }, 8)]
        [InlineData(new[] { 2, 2, 2, 5, 5 }, 0)]
        [InlineData(new[] { 2, 2, 2, 2, 2 }, 8)]
        public void FourOfKind_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.FourOfKind(dice));
        }

        // Small straight: When placed on “small straight”, if the dice read(1,2,3,4,5), 
        // the player scores 15 (the sum of all the dice).

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 15)]
        [InlineData(new[] { 2, 5, 3, 4, 1 }, 15)]
        [InlineData(new[] { 2, 3, 4, 5, 6 }, 0)]
        public void SmallStraight_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.SmallStraight(dice));
        }

        // Large straight: When placed on “large straight”, if the dice read(2,3,4,5,6), 
        // the player scores 20 (the sum of all the dice).

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 0)]
        [InlineData(new[] { 2, 5, 3, 4, 6 }, 20)]
        [InlineData(new[] { 2, 3, 4, 5, 6 }, 20)]
        public void LargeStraight_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.LargeStraight(dice));
        }

        // Full house: If the dice are two of a kind and three of a kind,
        // the player scores the sum of all the dice.For example, when placed on “full house”
        // • 1,1,2,2,2 scores 8 (1+1+2+2+2)
        // • 2,2,3,3,4 scores 0
        // • 4,4,4,4,4 scores 0

        [Theory]
        [InlineData(new[] { 1, 1, 2, 2, 2 }, 8)]
        [InlineData(new[] { 2, 2, 3, 3, 4 }, 0)]
        [InlineData(new[] { 4, 4, 4, 4, 4 }, 0)]
        public void FullHouse_ForGivenDice_ShouldReturnExpectedScore(int[] dice, int expectedScore)
        {
            Assert.Equal(expectedScore, _yatzyCalculator.FullHouse(dice));
        }
    }

    public class YatzyCalculator
    {
        // Chance: The player scores the sum of all dice, no matter what they read. For example,
        // • 1,1,3,3,6 placed on “chance” scores 14 (1+1+3+3+6)
        // • 4,5,5,6,1 placed on “chance” scores 21 (4+5+5+6+1)
        public int Chance(int[] dice)
        {
            return dice == null ? 0 : dice.Sum();
        }

        // Yatzy: If all dice have the same number, the player scores 50 points. For example,
        // • 1,1,1,1,1 placed on “yatzy” scores 50
        // • 1,1,1,2,1 placed on “yatzy” scores 0
        public int Yatzy(int[] dice)
        {
            return dice.Distinct().Count() > 1 ? 0 : 50;
        }

        // Ones, Twos, Threes, Fours, Fives, Sixes: The player scores
        // the sum of the dice that reads one, two, three, four, five or six,
        // respectively.For example,
        // • 1,1,2,4,4 placed on “fours” scores 8 (4+4)
        // • 2,3,2,5,1 placed on “twos” scores 4 (2+2)
        // • 3,3,3,4,5 placed on “ones” scores 0
        public int Ones(int[] dice)
        {
            return dice.Where(x => x == 1).Sum();
        }

        public int Twos(int[] dice)
        {
            return dice.Where(x => x == 2).Sum();
        }

        public int Threes(int[] dice)
        {
            return dice.Where(x => x == 3).Sum();
        }

        public int Fours(int[] dice)
        {
            return dice.Where(x => x == 4).Sum();
        }

        public int Fives(int[] dice)
        {
            return dice.Where(x => x == 5).Sum();
        }

        public int Sixes(int[] dice)
        {
            return dice.Where(x => x == 6).Sum();
        }

        // Pair: The player scores the sum of the two highest matching dice. For example, when placed on “pair”
        // • 3,3,3,4,4 scores 8 (4+4)
        // • 1,1,6,2,6 scores 12 (6+6)
        // • 3,3,3,4,1 scores 6 (3+3)
        // • 3,3,3,3,1 scores 6 (3+3)
        public int Pair(int[] dice)
        {
            return dice.OrderByDescending(x => x).GroupBy(x => x).Where(x => x.Count() >= 2).Take(1).Select(x => x.Key*2).Sum();
        }

        public int TwoPairs(int[] dice)
        {
            var collection = dice.OrderByDescending(x => x).GroupBy(x => x).Where(x => x.Count() >= 2);
            return collection.Count() >=2 ? collection.Take(2).Select(x => x.Key * 2).Sum() : 0;
        }

        public int ThreeOfKind(int[] dice)
        {
            return dice.OrderByDescending(x => x).GroupBy(x => x).Where(x => x.Count() >= 3).Take(1).Select(x => x.Key * 3).Sum();
        }

        public int FourOfKind(int[] dice)
        {
            return dice.OrderByDescending(x => x).GroupBy(x => x).Where(x => x.Count() >= 4).Take(1).Select(x => x.Key * 4).Sum();
        }

        public int SmallStraight(int[] dice)
        {
            return dice.Count() == 5 && dice.All(x => x > 0 && x < 6) ? 15 : 0;
        }

        // Large straight: When placed on “large straight”, if the dice read(2,3,4,5,6), 
        // the player scores 20 (the sum of all the dice).
        public int LargeStraight(int[] dice)
        {
             return dice.Count() == 5 && dice.All(x => x > 1 && x < 7) ? 20 : 0;
        }

        // Full house: If the dice are two of a kind and three of a kind,
        // the player scores the sum of all the dice.For example, when placed on “full house”
        // • 1,1,2,2,2 scores 8 (1+1+2+2+2)
        // • 2,2,3,3,4 scores 0
        // • 4,4,4,4,4 scores 0
        public int FullHouse(int[] dice)
        {
            return dice.GroupBy(x => x).Any(x => x.Count() == 2) && dice.GroupBy(x => x).Any(x => x.Count() == 3) ? dice.Sum() : 0;
        }
    }
}