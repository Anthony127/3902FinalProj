using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame
{
    public class TerrainSpriteFactory : ISpriteFactory
    {
        private Texture2D terrainSpriteSheet;

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
        }

        public ISprite CreateSprite(IBlockState state, string id)
        {
            string stateCode = state.GetStateCode();
            string code = id + stateCode;

            switch (code)
            {
                case "BBNACT":
                    return new BrickBlockSprite(terrainSpriteSheet);
                case "BBACTI":
                    return new HiddenBlockSprite(terrainSpriteSheet);

                case "BINACT":
                    return new BrickBlockSprite(terrainSpriteSheet);
                case "BIACTI":
                    return new UsedBlockSprite(terrainSpriteSheet);

                case "QBNACT":
                    return new QuestionBlockSprite(terrainSpriteSheet);
                case "QBACTI":
                    return new UsedBlockSprite(terrainSpriteSheet);

                case "HBNACT":
                    return new HiddenBlockSprite(terrainSpriteSheet);
                case "HBACTI":
                    return new UsedBlockSprite(terrainSpriteSheet);

                case "GBNACT":
                case "GBACTI":
                    return new GroundBlockSprite(terrainSpriteSheet);

                case "UBNACT":
                case "UBACTI":
                    return new UnbreakableBlockSprite(terrainSpriteSheet);

                case "SBNACT":
                case "SBACTI":
                    return new UsedBlockSprite(terrainSpriteSheet);

                case "PINACT":
                case "PIACTI":
                    return new PipeSprite(terrainSpriteSheet);

                default:
                    return new BrickBlockSprite(terrainSpriteSheet);
            }
        }
    }
}
