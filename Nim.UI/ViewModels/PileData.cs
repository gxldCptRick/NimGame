using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim.UI.ViewModels
{
    public class PileData
    {

        public PileData(string name, int originalAmount)
        {
            this.pileID = pileID;
            this.amountLeft = originalAmount;
        }

        public string pileID { get; set; }
        public int amountTaken { get; set; }
        public int amountLeft { get; set; }
    }
}
