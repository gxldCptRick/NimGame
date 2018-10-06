using Nim.Lib.Enums;
using Nim.Lib.Models;
using Nim.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim.UI.Controllers
{
    public class NimController
    {
        /// <summary>
        /// the random number generator to be used when calculating the boss moves. 
        /// </summary>
        private static readonly Random rnJesus;

        /// <summary>
        /// this creates the intial random instance for the static rnJesus Random variable.
        /// </summary>
        static NimController()
        {
            rnJesus = new Random();
        }

        /// <summary>
        /// this is a list of data represention of the piles in the nim game.
        /// </summary>
        public List<PileData> Piles { get; set; }
        /// <summary>
        /// this is the marker to determine whose turn it currently is.
        /// </summary>
        public PlayerTurn CurrentTurn { get; set; }
        public GameType Type { get; set; }
        public GameDifficulty Difficulty { get; set; }
        private NimGame game;

        public NimController()
        {
            Piles = new List<PileData>();
            ResetGame();
        }

        /// <summary>
        /// Resets the Game Object state based on the current diffculty.
        /// </summary>
        public void ResetGame()
        {
            CurrentTurn = PlayerTurn.PlayerOne;
            if (game != null && game.Difficulty == this.Difficulty)
            {
                game.ResetGame();
            }
            else
            {
                game = new NimGame(Difficulty == 0 ? GameDifficulty.Easy: Difficulty);
            }
        }

        public void ProcessTurn()
        {

        }

        private void ProcessBotTurn()
        {
        }

        private void ResetPiles()
        {
        }
        private void SwitchTurn()
        {
        }
    }
}
