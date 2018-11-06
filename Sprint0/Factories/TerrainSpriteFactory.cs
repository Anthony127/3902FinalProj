using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperPixelBrosGame.Interfaces;
using System.Reflection;

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

            terrianDictionary.Add("BBNACT", typeof(BrickBlockSprite));
            terrianDictionary.Add("BBACTI", typeof(HiddenBlockSprite));
            terrianDictionary.Add("BINACT", typeof(BrickBlockSprite));
            terrianDictionary.Add("BIACTI", typeof(UsedBlockSprite));
            terrianDictionary.Add("QBNACT", typeof(QuestionBlockSprite));
            terrianDictionary.Add("QBACTI", typeof(UsedBlockSprite));
            terrianDictionary.Add("HBNACT", typeof(HiddenBlockSprite));
            terrianDictionary.Add("HBACTI", typeof(UsedBlockSprite));
            terrianDictionary.Add("GBNACT", typeof(GroundBlockSprite));
            terrianDictionary.Add("GBACTI", typeof(GroundBlockSprite));
            terrianDictionary.Add("UBNACT", typeof(UnbreakableBlockSprite));
            terrianDictionary.Add("UBACTI", typeof(UnbreakableBlockSprite));
            terrianDictionary.Add("SBNACT", typeof(UsedBlockSprite));
            terrianDictionary.Add("SBACTI", typeof(UsedBlockSprite));
            terrianDictionary.Add("PINACT", typeof(PipeSprite));
            terrianDictionary.Add("PIACTI", typeof(PipeSprite));
            terrianDictionary.Add("FPNACT", typeof(FlagPoleSprite));
            terrianDictionary.Add("FPACTI", typeof(FlagPoleSprite));
            terrianDictionary.Add("FGNACT", typeof(FlagSprite));
            terrianDictionary.Add("FGACTI", typeof(FlagSprite));

        }

        public ISprite CreateSprite(IBlockState state, string id)
        {
            string stateCode = state.StateCode;
            string code = id + stateCode;
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
