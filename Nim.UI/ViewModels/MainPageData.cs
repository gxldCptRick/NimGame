﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nim.UI.Controllers;

namespace Nim.UI.ViewModels
{
    class MainPageData
    {
        /// <summary>
        /// The string for the first player's name
        /// </summary>
        public string p1Name { get; set; }
        /// <summary>
        /// The string for the second player's name
        /// </summary>
        public string p2Name { get; set; }
        /// <summary>
        /// The controller for the entire game.
        /// </summary>
        public NimController gameController { get; set; }
    }
}
