using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario;

namespace SuperPixelBrosGame
{
    public class PlayerSpriteFactory : ISpriteFactory
    {
        private Texture2D marioSpriteSheet;

        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerSpriteFactory()
        {

        }

        public void LoadTextures(ContentManager contentManager)
        {
            marioSpriteSheet = contentManager.Load<Texture2D>("Sprites/marioSMW");
        }

        public ISprite CreateSprite(IMovementState movement, IConditionState condition)
        {
            string movementCode = movement.GetMovementCode();
            string conditionCode = condition.GetConditionCode();
            string code = movementCode + conditionCode;

            switch (code)
            {
                case "LIDLSMLL":
                    return new IdleSmallMarioLeftSprite(marioSpriteSheet);
                case "RIDLSMLL":
                    return new IdleSmallMarioRightSprite(marioSpriteSheet);
                case "LJMPSMLL":
                    return new JumpSmallMarioLeftSprite(marioSpriteSheet);
                case "RJMPSMLL":
                    return new JumpSmallMarioRightSprite(marioSpriteSheet);
                case "LRUNSMLL":
                    return new WalkSmallMarioLeftSprite(marioSpriteSheet);
                case "RRUNSMLL":
                    return new WalkSmallMarioRightSprite(marioSpriteSheet);

                case "LIDLLRGE":
                    return new IdleMarioLeftSprite(marioSpriteSheet);
                case "RIDLLRGE":
                    return new IdleMarioRightSprite(marioSpriteSheet);
                case "LJMPLRGE":
                    return new JumpMarioLeftSprite(marioSpriteSheet);
                case "RJMPLRGE":
                    return new JumpMarioRightSprite(marioSpriteSheet);
                case "LCRHLRGE":
                    return new CrouchMarioLeftSprite(marioSpriteSheet);
                case "RCRHLRGE":
                    return new CrouchMarioRightSprite(marioSpriteSheet);
                case "LRUNLRGE":
                    return new WalkMarioLeftSprite(marioSpriteSheet);
                case "RRUNLRGE":
                    return new WalkMarioRightSprite(marioSpriteSheet);

                case "LIDLFIRE":
                    return new IdleFireMarioLeftSprite(marioSpriteSheet);
                case "RIDLFIRE":
                    return new IdleFireMarioRightSprite(marioSpriteSheet);
                case "LJMPFIRE":
                    return new JumpFireMarioLeftSprite(marioSpriteSheet);
                case "RJMPFIRE":
                    return new JumpFireMarioRightSprite(marioSpriteSheet);
                case "LCRHFIRE":
                    return new CrouchFireMarioLeftSprite(marioSpriteSheet);
                case "RCRHFIRE":
                    return new CrouchFireMarioRightSprite(marioSpriteSheet);
                case "LRUNFIRE":
                    return new WalkFireMarioLeftSprite(marioSpriteSheet);
                case "RRUNFIRE":
                    return new WalkFireMarioRightSprite(marioSpriteSheet);
                default:
                    return new DeadMarioSprite(marioSpriteSheet);
            }
        }
    }
}
