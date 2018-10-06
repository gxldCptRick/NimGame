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
        public readonly GameDifficulty Difficulty;
        public event EventHandler GameOver;
        private IDictionary<string, int> piles;

        public NimGame(GameDifficulty difficulty)
        {
            this.Difficulty = difficulty;
        }

        public int GetPileSize(string pileID) => piles[pileID];
        public string[] GetPileIDs() => piles.Keys.ToArray();
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
