using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Peca
    {
        public enum CorPeca { Amarela, Vermelha, Azul, Nula }

        public int X { get; set; }
        public int Y { get; set; }
        public CorPeca Cor { get; set; }

        public Peca(int posX, int posY, CorPeca corPeca)
        {
            X = posX;
            Y = posY;
            Cor = corPeca;
        }
    }
}
