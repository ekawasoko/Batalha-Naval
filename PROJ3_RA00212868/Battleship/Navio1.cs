﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Battleship.Peca;

namespace Battleship
{
    class Navio1:Navio
    {
        public Navio1()
        {
            pecas = new Peca[1];
            int lin = RandomNumber.GetRandomNumber(0,9);
            int col = RandomNumber.GetRandomNumber(0,9);
            pecas[0] = new Peca(lin, col, CorPeca.Amarela);
        }
    }
}
