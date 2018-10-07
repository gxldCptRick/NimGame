using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nim.Lib.Enums;
using Nim.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim.Lib.Tests.Models
{
    [TestClass]
    public class NimGameShould
    {

        [TestMethod]
        public void Be_Created_With_2_Piles_When_Easy_Selected()
        {
            //arrange 
            int expected = 2;
            int actual;

            //act
            var game = new NimGame(GameDifficulty.Easy);
            actual = game.GetPileIDs().Length;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Be_Created_With_3_Piles_When_Medium_Selected()
        {
            //arrange 
            int expected = 3;
            int actual;

            //act
            var game = new NimGame(GameDifficulty.Medium);
            actual = game.GetPileIDs().Length;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Be_Created_With_4_Piles_When_Hard_Selected()
        {
            //arrange 
            int expected = 4;
            int actual;

            //act
            var game = new NimGame(GameDifficulty.Hard);
            actual = game.GetPileIDs().Length;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Have_The_Configuration_3_3_When_Easy_Selected()
        {
            //arrange 
            int expected = 3;

            //act
            var game = new NimGame(GameDifficulty.Easy);
            var names = game.GetPileIDs();

            //assert
            foreach (var name in names)
            {
                Assert.AreEqual(expected, game.GetPileSize(name));
            }
        }

        [TestMethod]
        public void Have_The_Configuration_2_5_7_When_Medium_Selected()
        {
            //arrange 
            int[] expectedConfiguration = { 2, 5, 7 };

            //act
            var game = new NimGame(GameDifficulty.Medium);
            var names = game.GetPileIDs();
            
            //assert
            for (int i = 0; i < expectedConfiguration.Length && i < names.Length; i++)
            { 
                Assert.AreEqual(expectedConfiguration[i], game.GetPileSize(names[i]), $"The Value Expected was {expectedConfiguration[i]} in position {i} but was {game.GetPileSize(names[i])}");
            }
        }

        [TestMethod]
        public void Have_The_Configuration_2_3_8_9_When_Hard_Selected()
        {
            //arrange 
            int[] expectedConfiguration = { 2, 3, 8, 9 };

            //act
            var game = new NimGame(GameDifficulty.Hard);
            var names = game.GetPileIDs();

            //assert
            for (int i = 0; i < expectedConfiguration.Length && i < names.Length; i++)
            {
                Assert.AreEqual(expectedConfiguration[i], game.GetPileSize(names[i]), $"The Value Expected was {expectedConfiguration[i]} in position {i} but was {game.GetPileSize(names[i])}");
            }
        }

        [TestMethod]
        public void Fire_Game_Over_When_All_Piles_Are_Empty()
        {
            //arrange 
            var game = new NimGame(GameDifficulty.Hard);
            bool gameIsOver = false;
            game.GameOver += (s, e) => gameIsOver = true;
            
            //act
            foreach (var pileID in game.GetPileIDs())
            {
                game.TakeFromPile(pileID, game.GetPileSize(pileID));
            }

            //assert
            if (!gameIsOver) Assert.Fail();
        }

        [TestMethod]
        public void Not_Allow_You_To_Take_More_Objects_Then_Present_In_a_Pile()
        {
            //arrange 
            var game = new NimGame(GameDifficulty.Easy);
            var ids = game.GetPileIDs();
            var amountTaking = game.GetPileSize(ids[0]) + 1;
            bool result;
            
            //act
            result = game.TakeFromPile(ids[0], amountTaking);
            
            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Allow_You_To_Take_The_Same_Number_Of_Objects_Present_In_a_Pile()
        {
            //arrange 
            var game = new NimGame(GameDifficulty.Easy);
            var ids = game.GetPileIDs();
            var amountTaking = game.GetPileSize(ids[0]);
            bool result;

            //act
            result = game.TakeFromPile(ids[0], amountTaking);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Not_Allow_You_To_Take_Zero_Objects_From_a_Pile()
        {
            //arrange 
            var game = new NimGame(GameDifficulty.Easy);
            var ids = game.GetPileIDs();
            var amountTaking = 0;
            bool result;

            //act
            result = game.TakeFromPile(ids[0], amountTaking);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Not_Allow_You_To_Take_A_Negative_Number_Of_Objects_From_a_Pile()
        {
            //arrange 
            var game = new NimGame(GameDifficulty.Easy);
            var ids = game.GetPileIDs();
            var amountTaking = -10;
            bool result;

            //act
            result = game.TakeFromPile(ids[0], amountTaking);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Allow_You_To_Take_One_Object_From_a_Pile()
        {
            //arrange 
            var game = new NimGame(GameDifficulty.Easy);
            var ids = game.GetPileIDs();
            var amountTaking = -10;
            bool result;

            //act
            result = game.TakeFromPile(ids[0], amountTaking);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Reset_To_Original_State_After_ResetGame_Is_Called()
        {
            //arrange 
            var game = new NimGame(GameDifficulty.Easy);
            var ids = game.GetPileIDs();
            var amountTaking = game.GetPileSize(ids[0]);
            var expectedConfiguration = new [] { 3, 3  };
            //act

            game.TakeFromPile(ids[0], amountTaking);
            game.ResetGame();

            //assert
            for (int i = 0; i < expectedConfiguration.Length; i++)
            {
                Assert.AreEqual(expectedConfiguration[i], game.GetPileSize(ids[i]));
            }
        }
    }
}