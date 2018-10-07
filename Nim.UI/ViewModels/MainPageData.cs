using Nim.UI.Controllers;

namespace Nim.UI.ViewModels
{
    internal class MainPageData : ViewModelBase
    {
        private string _p1Name;
        private string _p2Name;

        /// <summary>
        /// The string for the first player's name
        /// </summary>
        public string P1Name
        {
            get => _p1Name; set
            {
                _p1Name = value;
                PropertyChanging();
            }
        }

        /// <summary>
        /// The string for the second player's name
        /// </summary>
        public string P2Name
        {
            get => _p2Name; set
            {
                _p2Name = value;
                PropertyChanging();
            }
        }

        /// <summary>
        /// The controller for the entire game.
        /// </summary>
        public NimController GameController { get; set; }

        /// <summary>
        /// Constructor for MainPageData in order to initalize the NimController.
        /// </summary>
        public MainPageData()
        {
            P1Name = "Player One";
            P2Name = "Player Two";
            GameController = new NimController();
        }
    }
}
