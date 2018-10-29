using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperPixelBrosGame.Interfaces
{
    public interface IBlockState
    {
        string StateCode { get; }
        void Activate();
        void Bump();

    }
}
