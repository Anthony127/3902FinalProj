using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint0.Interfaces;
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
    class TimeOutGameState : AbstractGameState, IGameState
    {
        private int levelTimeOut;
        public TimeOutGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera) : base(game, controllerList, camera)
        {
            levelTimeOut = 150;
            MediaPlayer.Stop();
        }

        public override void Update()
        {
            if (levelTimeOut > 0)
            {
                base.Update();
                levelTimeOut--;
                Console.WriteLine("Timeout: " + levelTimeOut);
            }
            else
            {
                Console.WriteLine("Timeout: " + levelTimeOut);
                Console.WriteLine("Resetting...");
                game.ResetLevel();
                game.GameState = new NormalGameState(game, controllerList, camera);
                SoundFactory.Instance.PlaySong("BACKGROUND_MUSIC_THEME");
                MediaPlayer.IsRepeating = true;
            }
        }
    }
}
