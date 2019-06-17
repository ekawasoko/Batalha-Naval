using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Battleship.Peca;

namespace Battleship
{
    class DrawObjetos
    {
        public static int alturaPeca = 42;
        public static int larguraPeca = 42;

        public static void DrawPeca(Peca p, SpriteBatch sp, Texture2D img,int deslocX=0, int deslocY=0)
        {
         //   int deslocX = 10;
          //  int deslocY = 10;

            int posX = deslocX + p.X * larguraPeca;
            int posY = deslocY + (6 * larguraPeca) - p.Y * alturaPeca;

            Rectangle rect = new Rectangle(posX, posY, larguraPeca, alturaPeca);
            Color cor = Color.CornflowerBlue;
            switch (p.Cor)
            {
                case CorPeca.Amarela:
                    cor = Color.Yellow;
                    break;
                case CorPeca.Vermelha:
                    cor = Color.Red;
                    break;
                case CorPeca.Azul:
                    cor = Color.Blue;
                    break;
                case CorPeca.Nula:
                    cor = Color.CornflowerBlue;
                    break;
            }

            sp.Draw(img, rect, cor);
        }
        public static void DrawTabJog(TabuleiroJogador tabJog, SpriteBatch sp, Texture2D img, SpriteFont fonte)
        {
            String msg = "1   2   3   4   5   6   7   8   9  10";
            sp.DrawString(fonte, msg, new Vector2(65, 0), Color.DarkBlue);

            for (int col = 0; col < tabJog.Colunas; col++)
            {
                for (int lin = 0; lin < tabJog.Linhas; lin++)
                {
                    Peca p = tabJog.Matriz[col, lin];
                    if (p != null)
                    {
                        DrawObjetos.DrawPeca(p, sp, img,50,170);
                    }
                    else
                    {
                        p = new Peca(col, lin, Peca.CorPeca.Nula);
                        DrawObjetos.DrawPeca(p, sp, img,50,170);
                    }

                }
            }
        }
        public static void DrawTabAdv(TabuleiroAdversario tabAdv, SpriteBatch sp, Texture2D img, SpriteFont fonte)
        {
            String msg = "1   2   3   4   5   6   7   8   9  10";
            sp.DrawString(fonte, msg, new Vector2(565, 0), Color.Red);

            for (int col = 0; col < tabAdv.Colunas; col++)
            {
                for (int lin = 0; lin < tabAdv.Linhas; lin++)
                {
                    Peca p = tabAdv.Matriz[col, lin];
                    if (p != null)
                    {
                        DrawObjetos.DrawPeca(p, sp, img,550,170);
                    }
                    else
                    {
                        p = new Peca(col, lin, Peca.CorPeca.Nula);
                        DrawObjetos.DrawPeca(p, sp, img,550,170);
                    }
                }
            }
        }
        public static void DrawBotao(Botao btn, SpriteBatch sp,
                            Texture2D textura,
                            SpriteFont fonte)
        {
            Rectangle rect = new Rectangle(btn.X, btn.Y,
                                          btn.Largura, btn.Altura);
            Vector2 posTexto = new Vector2(btn.X + 140, btn.Y + 35);
            Color cor = btn.Cor;
            if (btn.Clicado == true) { cor = Color.Gray; }
            sp.Draw(textura, rect, cor);
            sp.DrawString(fonte, btn.Texto, posTexto, Color.White);
        }

        public static void Credito(Credito cred, SpriteBatch sp, SpriteFont fonte)
        {
            Vector2 posNome = new Vector2(450, 20);
            Vector2 posEmail = new Vector2(450, 60);
            Vector2 posRA = new Vector2(450, 100);
            Rectangle rectFoto = new Rectangle(500, 150, 300, 300);

            sp.DrawString(fonte, "ALUNO: " + cred.Nome, posNome, Color.Black);
            sp.DrawString(fonte, "EMAIL: " + cred.Email, posEmail, Color.Black);
            sp.DrawString(fonte, "RA   : " + cred.RA, posRA, Color.Black);
            sp.Draw(cred.Foto, rectFoto, Color.White);

        }
    }
}
