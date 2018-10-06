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
        /// this is a different databound piles
        /// </summary>
        public List<PileData> Piles { get; set; }
        public PlayerTurn CurrentTurn { get; set; }
        public GameType Type { get; set; }
        public GameDifficulty Difficulty { get; set; }
        private NimGame game;

        public void ResetGame()
        {
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
