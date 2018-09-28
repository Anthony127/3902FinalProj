using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint0.Interfaces;

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

        public IBlockSprite CreateQuestionBlockSprite()
        {
            return new QuestionBlockSprite(terrainSpriteSheet);
        }

        public IBlockSprite CreateBrickBlockSprite()
        {
            return new BrickBlockSprite(terrainSpriteSheet);
        }

        public IBlockSprite CreateHiddenBlockSprite()
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

        public ISprite CreateSprite(IMovementState movement, IConditionState condition)
        {
            throw new NotImplementedException();
        }
    }
}
