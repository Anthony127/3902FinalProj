using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperPixelBrosGame.Interfaces;
using System.Reflection;
using SuperPixelBrosGame.States.Blocks;

namespace SuperPixelBrosGame
{
    public class TerrainSpriteFactory : ISpriteFactory
    {
        private Texture2D terrainSpriteSheet;
        private IDictionary<string, Type> terrianDictionary = new Dictionary<string, Type>();

        private static TerrainSpriteFactory instance = new TerrainSpriteFactory();

        public static TerrainSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadTextures(ContentManager contentManager)
        {
            terrainSpriteSheet = contentManager.Load<Texture2D>("Sprites/terrainSMW");

            terrianDictionary.Add(typeof(BrickBlock).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(BrickBlockSprite));
            terrianDictionary.Add(typeof(BrickBlock).ToString() + typeof(ActivatedBlockState).ToString(), typeof(BrickBlockBrokenSprite));
            terrianDictionary.Add(typeof(BrickBlockWithCoin).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(BrickBlockSprite));
            terrianDictionary.Add(typeof(BrickBlockWithCoin).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(BrickBlockWithItem).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(BrickBlockSprite));
            terrianDictionary.Add(typeof(BrickBlockWithItem).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(BrickBlockWithStar).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(BrickBlockSprite));
            terrianDictionary.Add(typeof(BrickBlockWithStar).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(BrickBlockEmpty).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(BrickBlockSprite));
            terrianDictionary.Add(typeof(BrickBlockEmpty).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlock).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(QuestionBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlock).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlockCoin).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(QuestionBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlockCoin).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlockEmpty).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(QuestionBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlockEmpty).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlockStar).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(QuestionBlockSprite));
            terrianDictionary.Add(typeof(QuestionBlockStar).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlock).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(HiddenBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlock).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlockCoin).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(HiddenBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlockCoin).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlockEmpty).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(HiddenBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlockEmpty).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlockStar).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(HiddenBlockSprite));
            terrianDictionary.Add(typeof(HiddenBlockStar).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(GroundBlock).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(GroundBlockSprite));
            terrianDictionary.Add(typeof(GroundBlock).ToString() + typeof(ActivatedBlockState).ToString(), typeof(GroundBlockSprite));
            terrianDictionary.Add(typeof(UnbreakableBlock).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(UnbreakableBlockSprite));
            terrianDictionary.Add(typeof(UnbreakableBlock).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UnbreakableBlockSprite));
            terrianDictionary.Add(typeof(UsedBlock).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(UsedBlock).ToString() + typeof(ActivatedBlockState).ToString(), typeof(UsedBlockSprite));
            terrianDictionary.Add(typeof(Pipe).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(PipeSprite));
            terrianDictionary.Add(typeof(Pipe).ToString() + typeof(ActivatedBlockState).ToString(), typeof(PipeSprite));
            terrianDictionary.Add(typeof(PipeBottom).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(PipeBottomSprite));
            terrianDictionary.Add(typeof(PipeBottom).ToString() + typeof(ActivatedBlockState).ToString(), typeof(PipeBottomSprite));
            terrianDictionary.Add(typeof(WarpPipe).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(PipeSprite));
            terrianDictionary.Add(typeof(WarpPipe).ToString() + typeof(ActivatedBlockState).ToString(), typeof(PipeSprite));
            terrianDictionary.Add(typeof(FlagPole).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(FlagPoleSprite));
            terrianDictionary.Add(typeof(FlagPole).ToString() + typeof(ActivatedBlockState).ToString(), typeof(FlagPoleSprite));
            terrianDictionary.Add(typeof(Flag).ToString() + typeof(NotActivatedBlockState).ToString(), typeof(FlagSprite));
            terrianDictionary.Add(typeof(Flag).ToString() + typeof(ActivatedBlockState).ToString(), typeof(FlagSprite));

        }

        public ISprite CreateSprite(string code)
        {
            ISprite sprite;
            terrianDictionary.TryGetValue(code, out Type spriteType);
            if (spriteType != null)
            {

                ConstructorInfo[] constr = new ConstructorInfo[1];
                constr = spriteType.GetConstructors();
                sprite = (ISprite)constr[0].Invoke(new object[] { terrainSpriteSheet });
            }
            else
            {
                sprite = new GoombaLeftSprite(terrainSpriteSheet);
            }


            return sprite;
        }
    }
}
