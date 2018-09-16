using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sprint0
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

        public ISprite CreateUnbreakableBlockSprite()
        {
            return new UnbreakableBlockSprite(terrainSpriteSheet);
        }

        public ISprite CreateUsedBlockSprite()
        {
            return new UsedBlockSprite(terrainSpriteSheet);
        }

        public ISprite CreateQuestionBlockSprite()
        {
            return new QuestionBlockSprite(terrainSpriteSheet);
        }

        public ISprite CreateBrickBlockSprite()
        {
            return new BrickBlockSprite(terrainSpriteSheet);
        }

        public ISprite CreateHiddenBlockSprite()
        {
            return new HiddenBlockSprite(terrainSpriteSheet);
        }

        public ISprite CreateGroundBlockSprite()
        {
            return new GroundBlockSprite(terrainSpriteSheet);
        }

        public ISprite CreatePipeSprite()
        {
            return new PipeSprite(terrainSpriteSheet);
        }

    }
}
