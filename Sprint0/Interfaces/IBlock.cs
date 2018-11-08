using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface IBlock
    {
        int BumpTimer { get; set; }
        int Timeout { get; set; }
        IBlockState BumpState { get; set; }
        IBlockState BlockState { get; set; }
        Vector2 Location { get; set; }
        void SpawnItem();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Activate();
        void Bump();
        void UpdateSprite();
    }
}
