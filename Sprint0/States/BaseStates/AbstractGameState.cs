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

namespace SuperPixelBrosGame
{


    abstract class AbstractGameState : IGameState
    {
        protected SuperPixelBrosGame game;
        protected ArrayList controllerList;
        protected ICamera camera;
        private readonly int HURRY_UP_THRESHOLD_MUSIC = 92;
        private readonly int HURRY_UP_THRESHOLD_EFFECT = 100;

        public AbstractGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera)
        {
            this.game = game;
            this.controllerList = controllerList;
            this.camera = camera;
        }

        public virtual void Draw(GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.CornflowerBlue);
            PlayerLevel.Instance.LevelDraw(camera);
        }

        public virtual void Update()
        {
            if (game.InputDelay <= 0)
            {
                foreach (IController controller in controllerList)
                {
                    controller.Update();
                }
            }
            else
            {
                game.InputDelay--;
            }
            if (ScoreKeeper.Instance.Time == HURRY_UP_THRESHOLD_EFFECT)
            {
                MediaPlayer.Stop();
                SoundFactory.Instance.PlaySong("MUSIC_HURRY_UP");
            }
            else if (ScoreKeeper.Instance.Time == HURRY_UP_THRESHOLD_MUSIC)
            {
                MediaPlayer.Stop();
                SoundFactory.Instance.PlayBackgroundMusic();
            }
            PlayerLevel.Instance.LevelUpdate(camera);

            camera.CameraUpdate();
        }
    }
}
