using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Sprites
{
    public class SpriteUtility
    {
        private static readonly SpriteUtility instance = new SpriteUtility();
        private int BLOCKUNIT;
        private int MATRIXUNIT;

        public int BLOCK_UNIT { get => BLOCKUNIT; private set => BLOCKUNIT = value; }
        public int MATRIX_UNIT { get => MATRIXUNIT; private set => MATRIXUNIT = value; }
        private Dictionary<Type, Color> colorDictionary;

        private SpriteUtility(){
            BLOCK_UNIT = 32;
            MATRIX_UNIT = 24;
            colorDictionary = new Dictionary<Type, Color>
            {
                { typeof(DeadMarioState), Color.White },
                { typeof(SmallMarioState), Color.Blue },
                { typeof(LargeMarioState), Color.White },
                { typeof(FireMarioState), Color.Red },
            };
        }

        public static SpriteUtility Instance
        {
            get
            {
                return instance;
            }
        }

        public Color ColorFromState (IConditionState conditionState)
        {
            Color color = Color.White;
            colorDictionary.TryGetValue(conditionState.GetType(), out color);
            return color;
        }
    }
}
