﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.PileID = pileID;
            this.AmountLeft = originalAmount;
        }

        /// <summary>
        /// the id for the pile being represented.
        /// </summary>
        public string PileID
        {
            get => _pileID; set
            {
                _pileID = value;
                this.PropertyChanging();
            }
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
            }
        }
    }
}
