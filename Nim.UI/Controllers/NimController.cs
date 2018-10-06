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
        
        /// <summary>
        /// The currently selected Game Mode. 
        /// </summary>
        public GameType Type { get; set; }

        /// <summary>
        /// the currently selected Difficulty.
        /// </summary>
        public GameDifficulty Difficulty { get; set; }

        /// <summary>
        /// the current Game of Nim being played
        /// </summary>
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

            ResetPiles();
        }

        /// <summary>
        /// Processes the changes made to the GamePile Collection and update the game state.
        /// </summary>
        public void ProcessTurn()
        {
            foreach (var pile in Piles)
            {
                this.game.TakeFromPile(pile.PileID, pile.AmountTaken);
            }
            ResetPiles();
            if (Type == GameType.OnePlayer)
            {
                this.SwitchTurn();
                this.ProcessBotTurn();
            }
            else
            {
                this.SwitchTurn();
            }
        }

        /// <summary>
        /// Process the bots desired move and updates the game state.
        /// </summary>
        private void ProcessBotTurn()
        {
            var pileNames = this.game.GetPileIDs();
            bool isValidMove = false;
            do
            {
                var pileSelecting = pileNames[rnJesus.Next(0, pileNames.Length)];
                var amountInPile = this.game.GetPileSize(pileSelecting);
                isValidMove = amountInPile == 0;
                if (isValidMove)
                {
                    var amountTaking = rnJesus.Next(1, amountInPile + 1);
                    this.game.TakeFromPile(pileSelecting, amountTaking);
                }
            } while (!isValidMove);

            this.SwitchTurn();
        }

        /// <summary>
        /// Resets the pile to what the game state currently is.
        /// </summary>
        private void ResetPiles()
        {
            if (this.game.Difficulty != this.Difficulty)
            {
                var pileNames = this.game.GetPileIDs();
                this.Piles.Clear();
                foreach (var name in pileNames)
                {
                    Piles.Add(new PileData(name, this.game.GetPileSize(name)));
                }
            }
            else
            {
                foreach (var pile in Piles)
                {
                    pile.AmountTaken = 0;
                    pile.AmountLeft = this.game.GetPileSize(pile.PileID);
                }
            }
            
        }

        /// <summary>
        /// Switches the turn on the current turn property.
        /// </summary>
        private void SwitchTurn()
        {
            this.CurrentTurn = this.CurrentTurn == PlayerTurn.PlayerOne ? PlayerTurn.PlayerTwo : PlayerTurn.PlayerOne;
        }
    }
}
