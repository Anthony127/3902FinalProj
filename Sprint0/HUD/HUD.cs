using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.MasterClasses
{
    class HUD
    {
        private HUD instance = new HUD();

        public HUD Instance()
        {
            return instance;
        }

        private HUD()
        {
        }

        public void Update()
        {
        }

    }
}
