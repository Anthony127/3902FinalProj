using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.HUDComponents
{
    class HUD
    {
        private SpriteFont font;
        private static HUD instance = new HUD();

        public static HUD Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private HUD()
        {
        }

        public void LoadContent(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("ComicSans");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Mario", new Vector2(0, 0), Color.White);
        }

        public void Update()
        {
        }

    }
}
