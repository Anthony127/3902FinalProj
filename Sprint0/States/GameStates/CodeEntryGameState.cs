using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint0.Interfaces;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.GameStates
{
    class CodeEntryGameState : AbstractGameState, IGameState
    {
        private int pauseTimer;
        private PasswordInputController controller;
        public CodeEntryGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera) : base(game, controllerList, camera)
        {
            pauseTimer = 15;
            game.DelayInput(15);
            MediaPlayer.Stop();
            foreach (IController controller in controllerList)
            {
                if (controller is PasswordInputController)
                {
                    this.controller = (PasswordInputController)controller;
                }

            }
        }

        public override void Update()
        {
            if (pauseTimer > 0)
            {
                pauseTimer--;
            }
            else
            {
                controller.Update();
            }
        }
        public override void Draw(GraphicsDevice graphicsDevice)
        {

            base.Draw(graphicsDevice);
            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
            spriteBatch.Begin();
            spriteBatch.DrawString(HUD.Instance.Font, "\"" + controller.DynamicCode + "\"", new Vector2(330, 150), Color.White);
            spriteBatch.End();
        }
    }
}
