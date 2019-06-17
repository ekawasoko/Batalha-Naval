using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Battleship
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        enum EstadoJogo { Jogar, Menu, Credito, Sair };
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TabuleiroJogador tabJog;
        TabuleiroAdversario tabAdv;
        //Estaleiro estaleiro;
        Navio navioAdv;
        Navio navioJog;
        Texture2D imgBloco;
        Texture2D imgLogo;
        Texture2D imgBotao;
        Texture2D imgFoto;
        Texture2D imgBackground;
        Texture2D imgPropaganda;
        SpriteFont fonte;
        Credito about;
        MouseState meuMouse;
        Vector2 posMouse;
        Botao botaoVoltar;
        Botao botaoJogar;
        Botao botaoCredito;
        Botao botaoSair;
        bool leftButtonPressed;
        bool clickedMouse;
        EstadoJogo estado;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            tabJog = new TabuleiroJogador(10, 10);
            tabAdv = new TabuleiroAdversario(10, 10);
            for(int i=0;i<6;i++)
            {
                //estaleiro = new Estaleiro();
                navioAdv = FabricarAdv();
                navioJog = FabricarJog();
                tabJog.ColocarNavio(navioJog);
                tabAdv.ColocarNavio(navioAdv);
                Navio FabricarAdv()
                {
                    Navio navioAdv = null;
                    switch (i)
                    {
                        case 0:
                            navioAdv = new Navio1();
                            return navioAdv;
                        case 1:
                            navioAdv = new Navio1();
                            return navioAdv;
                        case 2:
                            navioAdv = new Navio1();
                            return navioAdv;
                        case 3:
                            navioAdv = new Navio1();
                            return navioAdv;
                        case 4:
                            navioAdv = new Navio1();
                            return navioAdv;
                        case 5:
                            navioAdv = new Navio1();
                            return navioAdv;
                    }
                    return navioAdv;
                }
                Navio FabricarJog()
                {
                    Navio navioJog = null;
                    switch (i)
                    {
                        case 0:
                            navioJog = new Navio1();
                            return navioJog;
                        case 1:
                            navioJog = new Navio1();
                            return navioJog;
                        case 2:
                            navioJog = new Navio1();
                            return navioJog;
                        case 3:
                            navioJog = new Navio1();
                            return navioJog;
                        case 4:
                            navioJog = new Navio1();
                            return navioJog;
                        case 5:
                            navioJog = new Navio1();
                            return navioJog;
                    }
                    return navioJog;
                }
            }
            this.IsMouseVisible = true;
            clickedMouse = false;
            leftButtonPressed = false;
            graphics.PreferredBackBufferWidth = 32 * 42;
            botaoVoltar = new Botao(965, 380, "VOLTAR");
            botaoJogar = new Botao(450, 180, " JOGAR");
            botaoCredito = new Botao(450, 280, " SOBRE");
            botaoSair = new Botao(450, 380, "  SAIR");
            estado = EstadoJogo.Menu;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imgBloco = Content.Load<Texture2D>("Bloco");
            fonte = Content.Load<SpriteFont>("Verdana");
            imgFoto = Content.Load<Texture2D>("Foto");
            imgBackground = Content.Load<Texture2D>("Background");
            imgPropaganda = Content.Load<Texture2D>("Propaganda");
            imgBotao = Content.Load<Texture2D>("botao");
            imgLogo = Content.Load<Texture2D>("Logo");
            about = new Credito("Vinicus Amaral Damiani",
                              "vinidamiani126@gmail.com",
                              "RA00212868",
                              imgFoto);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (estado == EstadoJogo.Jogar)
            {
                verificarCliqueMouse();
                if (clickedMouse == true)
                {
                    botaoVoltar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    if (botaoVoltar.Clicado)
                    {
                        estado = EstadoJogo.Menu;
                        botaoVoltar.Clicado = false;
                    }
                    clickedMouse = false;
                }
            }
            else if(estado==EstadoJogo.Credito)
            {
                verificarCliqueMouse();

                if (clickedMouse == true)
                {
                    botaoVoltar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    if (botaoVoltar.Clicado)
                    {
                        estado = EstadoJogo.Menu;
                        botaoVoltar.Clicado = false;
                    }
                    clickedMouse = false;
                }
            }
            else if(estado==EstadoJogo.Menu)
            {
                verificarCliqueMouse();
                if (clickedMouse)
                {
                    botaoJogar.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    botaoCredito.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    botaoSair.VerificarClique((int)posMouse.X, (int)posMouse.Y);
                    if (botaoJogar.Clicado)
                    {
                        estado = EstadoJogo.Jogar;
                        botaoJogar.Clicado = false;
                    }
                    else if (botaoCredito.Clicado)
                    {
                        estado = EstadoJogo.Credito;
                        botaoCredito.Clicado = false;
                    }
                    else if (botaoSair.Clicado)
                    {
                        estado = EstadoJogo.Sair;
                        botaoSair.Clicado = false;
                    }
                    clickedMouse = false;
                }
            }
            else if (estado == EstadoJogo.Sair)
            {
                Exit();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        private void verificarCliqueMouse()
        {
            meuMouse = Mouse.GetState();
            posMouse.X = meuMouse.X;
            posMouse.Y = meuMouse.Y;
            if (meuMouse.LeftButton == ButtonState.Pressed)
            {
                leftButtonPressed = true;
            }

            if (meuMouse.LeftButton == ButtonState.Released &&
                leftButtonPressed == true)
            {
                clickedMouse = true;
                leftButtonPressed = false;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            Rectangle rectBG = new Rectangle(0, 0,
            GraphicsDevice.Viewport.Width,
            GraphicsDevice.Viewport.Height);
            spriteBatch.Draw(imgBackground, rectBG, Color.White);
            if (estado == EstadoJogo.Jogar)
            {
                DrawObjetos.DrawTabJog(tabJog, spriteBatch, imgBloco, fonte);
                DrawObjetos.DrawTabAdv(tabAdv, spriteBatch, imgBloco, fonte);
                DrawObjetos.DrawBotao(botaoVoltar, spriteBatch,
                      imgBotao, fonte);
                Rectangle rectPropaganda = new Rectangle(1005, 20, 300, 350);
                spriteBatch.Draw(imgPropaganda, rectPropaganda, Color.White);
            }
            else if (estado == EstadoJogo.Menu)
            {
                #region DRAW MENU
                DrawObjetos.DrawBotao(botaoJogar, spriteBatch, imgBotao, fonte);
                DrawObjetos.DrawBotao(botaoCredito, spriteBatch, imgBotao, fonte);
                DrawObjetos.DrawBotao(botaoSair, spriteBatch, imgBotao, fonte);
                Rectangle rectLogo = new Rectangle(470, 10, 350, 180);
                spriteBatch.Draw(imgLogo, rectLogo, Color.White);
                #endregion

            }
            else if (estado == EstadoJogo.Credito)
            {
                //spriteBatch.DrawString(fonte, "TELA DE CREDIO", Vector2.Zero, Color.Red);
                DrawObjetos.Credito(about, spriteBatch, fonte);
                DrawObjetos.DrawBotao(botaoVoltar, spriteBatch, imgBotao, fonte);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }    
    }
}
