using System;
using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest.Tests
{
    [TestClass]
    public class GameTests
    {
        //Declaring the game
        private Game game;

        public GameTests()
        {
            game = new Game();
        }


        [TestMethod]
        public void CanCreateGame()
        {
            var game = new Game();
        }

       

        [TestMethod]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
           /* for (var i = 0; i < 20; i++)
                game.Roll(1);*/
            RollMany(20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, game.Score());
        }

        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }


        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
    }
}
