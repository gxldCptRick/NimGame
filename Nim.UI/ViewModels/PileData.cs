using System;

namespace Nim.UI.ViewModels
{
    public class PileData : ViewModelBase
    {
        private string _pileID;
        private int _amountTaken;
        private int _amountLeft;

        /// <summary>
        /// constructs a pile data object with the given pileID and starting amount.
        /// </summary>
        /// <param name="pileID">the id for the pile</param>
        /// <param name="originalAmount">the original amount to start with</param>
        public PileData(string pileID, int originalAmount)
        {
            PileID = pileID;
            AmountLeft = originalAmount;
            IsEnabled = true;
        }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get => _isEnabled && AmountLeft!=0; set
            {
                _isEnabled = value;
                PropertyChanging();
            }
        }


        /// <summary>
        /// the id for the pile being represented.
        /// </summary>
        public string PileID
        {
            get => _pileID; set
            {
                _pileID = value;
                PropertyChanging();
            }
        }

        public event Action ActionDid;

        internal void Invoke()
        {
            ActionDid?.Invoke();
        }

        /// <summary>
        /// amount to be taken on next update.
        /// </summary>
        public int AmountTaken
        {
            get => _amountTaken; set
            {
                _amountTaken = value;
                PropertyChanging();
            }
        }

        /// <summary>
        /// amount that will be remaining after next update.
        /// </summary>
        public int AmountLeft
        {
            get => _amountLeft; set
            {
                _amountLeft = value;
                PropertyChanging();
                PropertyChanging("IsEnabled");
            }
        }
    }
}
