using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint0.Interfaces
{
    public interface IBlockState
    {
        void Activate();
        string GetStateCode();
    }
}
