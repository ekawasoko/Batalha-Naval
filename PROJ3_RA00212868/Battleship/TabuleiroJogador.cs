using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Battleship.Peca;

namespace Battleship
{
    class TabuleiroJogador
    {
        public int Linhas { get; }
        public int Colunas { get; }
        private int[] alturaDaLinha;
        public Peca[,] Matriz { get; set; }
        Navio navioAtual;

        public TabuleiroJogador(int lin, int col)
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
                n.pecas[i].Cor = CorPeca.Amarela;
                int col = n.pecas[i].X;
                int lin = n.pecas[i].Y;
                Matriz[col, lin] = n.pecas[i];
            }
        
            return ok;
        }
    }
}
