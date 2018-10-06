using Nim.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim.Lib.Models
{
    public class NimGame
    {
        /// <summary>
        /// The Difficulty of the game created.
        /// </summary>
        public readonly GameDifficulty Difficulty;
        /// <summary>
        /// the event that is fired to signal when the Game is over.
        /// </summary>
        public event EventHandler GameOver;

        /// <summary>
        /// the representation of the piles for the game of nim.
        /// </summary>
        private IDictionary<string, int> piles;

        /// <summary>
        /// Constructs an instance of the Nim Game
        /// with the given difficulty. 
        /// </summary>
        /// <param name="difficulty">the difficulty of the game</param>
        public NimGame(GameDifficulty difficulty)
        {
            this.Difficulty = difficulty;
            ResetGame();
        }

        /// <summary>
        /// returns the size of the pile from the given id;
        /// </summary>
        /// <param name="pileID">the pile you want to select</param>
        /// <returns>the current size of the given pile</returns>
        public int GetPileSize(string pileID) => piles[pileID];
        
        /// <summary>
        /// Returns all the possible pile ids for the game.
        /// </summary>
        /// <returns>
        ///  all the possible ids for the game.
        /// </returns>
        public string[] GetPileIDs() => piles.Keys.ToArray();
        
        /// <summary>
        ///  This method will update the pile with the given id by removing the amount
        ///  passed in from the pile it is able.
        ///  it returns whether or not it was successfully removed.
        /// </summary>
        /// <param name="pileID">The id of the pile you wish to remove from.</param>
        /// <param name="numberOfObjectsTaking">The amount of objects you are taking from the pile.</param>
        /// <returns>Whether or not the amount was successfully removed.</returns>
        public bool TakeFromPile(string pileID, int numberOfObjectsTaking)
        {
            bool isAbleToTakeFromPile = false;
            if (piles.ContainsKey(pileID) && numberOfObjectsTaking <= piles[pileID])
            {
                isAbleToTakeFromPile = true;
                piles[pileID] -= numberOfObjectsTaking;
                if (IsGameOver())
                {
                    GameOver?.Invoke(this, EventArgs.Empty);
                }
              
            }

            return isAbleToTakeFromPile;
        }
        
        /// <summary>
        /// This Method Resets The State of the game Object back to its initial construction.
        /// </summary>
        public void ResetGame()
        {
            if (piles is null) piles = new Dictionary<string, int>();
            else piles.Clear();

            switch (Difficulty)
            {
                case GameDifficulty.Easy:
                    piles["A"] = 3;
                    piles["B"] = 3;
                    break;
                case GameDifficulty.Medium:
                    piles["A"] = 2;
                    piles["B"] = 5;
                    piles["C"] = 7;
                    break;
                case GameDifficulty.Hard:
                    piles["A"] = 2;
                    piles["B"] = 3;
                    piles["C"] = 8;
                    piles["D"] = 9;
                    break;
                default:
                    throw new ArgumentException("This is not a supported GameDifficulty");
            }
        }

        /// <summary>
        /// This Method determines whether or not the game has ended.
        /// </summary>
        /// <returns>true if the game is over</returns>
        private bool IsGameOver()
        {
            bool isGameOver = true;
            foreach (var pile in piles.Values)
            {
                isGameOver = pile == 0;
                if (!isGameOver)
                {
                    break;
                }
            }

            return isGameOver;
        }
    }
}
