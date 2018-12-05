using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SuperPixelBrosGame.Sprites
{
    public class SpriteUtility
    {
        private static readonly SpriteUtility instance = new SpriteUtility();
        private int BLOCKUNIT = 32;
        private int MATRIXUNIT = 24;

        public int BLOCK_UNIT { get => BLOCKUNIT;  }
        public int MATRIX_UNIT { get => MATRIXUNIT;  }
        private Dictionary<Type, Color> colorDictionary;

        private SpriteUtility()
        {
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
