using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class ControladorMouse:Controlador
    {
        bool leftPressedButton;
        public ControladorMouse()
        {
            leftPressedButton = false;

        }

        public override int Jogar()
        {
            int jogada = -1;

            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                leftPressedButton = true;
            }

            if (mouse.LeftButton == ButtonState.Released && leftPressedButton == true)
            {
                leftPressedButton = false;
                jogada = mouse.X / DrawObjetos.larguraPeca;
            }
            return jogada;
        }
    }
}
