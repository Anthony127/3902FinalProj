using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperPixelBrosGame.Interfaces
{
    public interface IBlockState
    {
        void Activate();
        string GetStateCode();
    }
}
