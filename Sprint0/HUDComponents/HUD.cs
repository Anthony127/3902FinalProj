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

        public void Draw(SpriteBatch spriteBatch, Rectangle location)
        {
            spriteBatch.DrawString(font, "Mario: x" + ScoreKeeper.Instance.GetLives(), new Vector2(location.Left+5, location.Top), Color.White);
            spriteBatch.DrawString(font, ScoreKeeper.Instance.GetScore().ToString() + "         Coins: " 
                + ScoreKeeper.Instance.GetCoins().ToString(), new Vector2(location.Left + 5, location.Top + 35), Color.White);
            spriteBatch.DrawString(font, "Time", new Vector2(location.Right - 100, location.Top), Color.White);
            spriteBatch.DrawString(font, ScoreKeeper.Instance.GetTime().ToString(), new Vector2(location.Right - 100, 
                location.Top + 35), Color.White);
        }
    }
}
