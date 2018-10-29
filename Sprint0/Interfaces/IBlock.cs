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
        IBlockState BumpState { get; set; }
        IBlockState GetBlockState();
        Vector2 GetLocation();
        void SetLocation(Vector2 location);
        void SetBlockState(IBlockState state);
        void SpawnItem();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Activate();
        void Bump();
    }
}
