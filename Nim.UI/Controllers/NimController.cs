using Nim.Lib.Enums;
using Nim.Lib.Models;
using Nim.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nim.UI.Controllers
{
    public class NimController : ViewModelBase
    {
        /// <summary>
        /// the random number generator to be used when calculating the boss moves. 
        /// </summary>
        public static readonly Random rnJesus;

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
        public ObservableCollection<PileData> Piles
        {
            get => _piles; set
            {
                _piles = value;
                PropertyChanging();
            }
        }

        /// <summary>
        /// this is the marker to determine whose turn it currently is.
        /// </summary>
        public PlayerTurn CurrentTurn
        {
            get => _currentTurn; set
            {
                _currentTurn = value;
                PropertyChanging();
            }
        }

        /// <summary>
        /// The currently selected Game Mode. 
        /// </summary>
        public GameType Type
        {
            get => _type; set
            {
                _type = value;
                PropertyChanging();
            }
        }

        /// <summary>
        /// the currently selected Difficulty.
        /// </summary>
        public GameDifficulty Difficulty
        {
            get => _difficulty; set
            {
                _difficulty = value;
                ResetGame();
                PropertyChanging();
            }
        }

        /// <summary>
        /// signals when the internal nim game object is over.
        /// </summary>
        public event EventHandler GameOver;

        /// <summary>
        /// the current Game of Nim being played
        /// </summary>
        private NimGame game;
        private ObservableCollection<PileData> _piles;
        private PlayerTurn _currentTurn;
        private GameType _type;
        private GameDifficulty _difficulty;
        private bool isGameOver = false;

        /// <summary>
        /// Initializes a blank NimController with a default game object of type easy.
        /// </summary>
        public NimController()
        {
            Piles = new ObservableCollection<PileData>();
            Difficulty = GameDifficulty.Easy;
            Type = GameType.OnePlayer;
            ResetGame();
        }

        /// <summary>
        /// Resets the Game Object state based on the current diffculty.
        /// </summary>
        public void ResetGame()
        {
            isGameOver = false;

            CurrentTurn = PlayerTurn.PlayerOne;
            if (game != null && game.Difficulty == Difficulty)
            {
                game.ResetGame();
            }
            else
            {
                game = new NimGame(Difficulty);
                game.GameOver += (s, e) =>
                {
                    isGameOver = true;
                    GameOver?.Invoke(s, e);
                };
                Piles.Clear();
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
                game.TakeFromPile(pile.PileID, pile.AmountTaken);
            }

            ResetPiles();
            if (Type == GameType.OnePlayer)
            {
                SwitchTurn();
                ProcessBotTurn();
            }
            else
            {
                SwitchTurn();
            }

            ResetPiles();
        }

        /// <summary>
        /// Process the bots desired move and updates the game state.
        /// </summary>
        private void ProcessBotTurn()
        {
            var pileNames = game.GetPileIDs();
            bool isValidMove = false;
            do
            {
                var pileSelecting = pileNames[rnJesus.Next(0, pileNames.Length)];
                var amountInPile = game.GetPileSize(pileSelecting);
                isValidMove = amountInPile != 0;
                if (isValidMove)
                {
                    var amountTaking = rnJesus.Next(1, amountInPile + 1);
                    game.TakeFromPile(pileSelecting, amountTaking);
                }
            } while (!isValidMove);

            SwitchTurn();
        }

        /// <summary>
        /// Resets the pile to what the game state currently is.
        /// </summary>
        private void ResetPiles()
        {
            if (game.Difficulty != Difficulty || Piles.Count == 0)
            {
                var pileNames = game.GetPileIDs();
                Piles.Clear();
                foreach (var name in pileNames)
                {
                    Piles.Add(new PileData(name, game.GetPileSize(name)));
                }
            }
            else
            {
                foreach (var pile in Piles)
                {
                    pile.AmountTaken = 0;
                    pile.AmountLeft = game.GetPileSize(pile.PileID);
                    pile.IsEnabled = true;
                }
            }

        }

        /// <summary>
        /// Switches the turn on the current turn property.
        /// </summary>
        private void SwitchTurn()
        {
            if(!isGameOver) CurrentTurn = CurrentTurn == PlayerTurn.PlayerOne ? PlayerTurn.PlayerTwo : PlayerTurn.PlayerOne;
        }
    }
}