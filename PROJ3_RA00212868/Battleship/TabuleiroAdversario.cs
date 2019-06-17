using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Battleship.Peca;

namespace Battleship
{
    class TabuleiroAdversario
    {
        public int Linhas { get; }
        public int Colunas { get; }
        private int[] alturaDaLinha;
        public Peca[,] Matriz { get; set; }
        Navio navioAtual;
        public bool Clicada { get; set; }
        public bool Acerto { get; set; }
        public bool Agua { get; set; }

        public TabuleiroAdversario(int lin, int col)
        {
            Linhas = lin;
            Colunas = col;
            Matriz = new Peca[col, lin];
            alturaDaLinha = new int[col];
            for (int i = 0; i < col; i++)
            {
                alturaDaLinha[i] = 0;
            }
        }
        public bool ColocarNavio(Navio n)
        {
            bool ok = false;
        
            navioAtual = n;
            for (int i = 0; i < n.pecas.Length; i++)
            {
                //Random rnd;
                //rnd = new Random();
                //n.pecas[i].X = rnd.Next(0, 9);
                //n.pecas[i].Y = rnd.Next(0, 9);
                n.pecas[i].Cor = CorPeca.Nula;
                int col = n.pecas[i].X;
                int lin = n.pecas[i].Y;
                Matriz[col, lin] = n.pecas[i];
            }
        
            return ok;
        }
        public bool ColocarAgua(Agua a)
        {
            bool ok = false;
            int i = 0;
            a = new Agua();
            a.pecas[i].Cor = CorPeca.Azul;
            a.pecas[i].X = 1;
            a.pecas[i].Y = 2;
            int col = a.pecas[i].X;
            int lin = a.pecas[i].Y;
            Matriz[col, lin] = a.pecas[i];

            return ok;
        }
        public void VerificarClique(Int32 x1, Int32 y1)
        {
            if(Agua)
            {
                Agua agua;
                agua = new Agua();
                ColocarAgua(agua);
                Clicada = !Clicada;
            }
            if(Acerto)
            {

                Clicada = !Clicada;
            }
        }
    }
}
