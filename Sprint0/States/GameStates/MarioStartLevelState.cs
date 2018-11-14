using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
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
    class MarioStartLevelState : AbstractGameState, IGameState
    {
        private int loadTimeOut;

        public MarioStartLevelState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera) : base(game, controllerList, camera)
        {
            MediaPlayer.Stop();
            SuperPixelBrosGame.ResetLevel();
            if (ScoreKeeper.Instance.Lives == -1)
            {
                SoundFactory.Instance.PlaySoundEffect("SOUND_GAMEOVER");
                loadTimeOut = 250;
            }
            else
            {
                loadTimeOut = 120;
            }

        }

        public override void Update()
        {
            if (loadTimeOut > 0)
            {
                loadTimeOut--;
            }
            else if (loadTimeOut <= 0 && ScoreKeeper.Instance.Lives != -1)
            {
                game.GameState = new NormalGameState(game, controllerList, camera);
                SoundFactory.Instance.PlaySong("BACKGROUND_MUSIC_THEME");
            }
            else
            {
                ScoreKeeper.Instance.Lives = 3;
                game.GameState = new MarioStartLevelState(game, controllerList, camera);
            }
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
            spriteBatch.Begin();
            if (loadTimeOut > 0 && ScoreKeeper.Instance.Lives != -1)
            {
                graphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(HUD.Instance.Font, "Mario: x" + ScoreKeeper.Instance.Lives, new Vector2(340, 200), Color.White);
                spriteBatch.DrawString(HUD.Instance.Font, "World 1 - 1", new Vector2(330, 150), Color.White);
            }
            else if (ScoreKeeper.Instance.Lives == -1)
            {
                graphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(HUD.Instance.Font, "Game Over", new Vector2(330, 150), Color.White);
            }
            else
            {
                base.Draw(graphicsDevice);
            }
            spriteBatch.End();
        }
    }
}
