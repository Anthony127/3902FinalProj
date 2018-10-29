using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace SuperPixelBrosGame
{
    public class PlayerSpriteFactory : ISpriteFactory
    {
        private Texture2D marioSpriteSheet;
        private IDictionary<string, Type> marioDictionary = new Dictionary<string, Type>();

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

            marioDictionary.Add("LIDLSMLL", typeof(IdleSmallMarioLeftSprite));
            marioDictionary.Add("RIDLSMLL", typeof(IdleSmallMarioRightSprite));
            marioDictionary.Add("LJMPSMLL", typeof(JumpSmallMarioLeftSprite));
            marioDictionary.Add("RJMPSMLL", typeof(JumpSmallMarioRightSprite));
            marioDictionary.Add("LRUNSMLL", typeof(WalkSmallMarioLeftSprite));
            marioDictionary.Add("RRUNSMLL", typeof(WalkSmallMarioRightSprite));

            marioDictionary.Add("LIDLLRGE", typeof(IdleMarioLeftSprite));
            marioDictionary.Add("RIDLLRGE", typeof(IdleMarioRightSprite));
            marioDictionary.Add("LJMPLRGE", typeof(JumpMarioLeftSprite));
            marioDictionary.Add("RJMPLRGE", typeof(JumpMarioRightSprite));
            marioDictionary.Add("LRUNLRGE", typeof(WalkMarioLeftSprite));
            marioDictionary.Add("RRUNLRGE", typeof(WalkMarioRightSprite));
            marioDictionary.Add("LCRHLRGE", typeof(CrouchMarioLeftSprite));
            marioDictionary.Add("RCRHLRGE", typeof(CrouchMarioRightSprite));

            marioDictionary.Add("LIDLFIRE", typeof(IdleFireMarioLeftSprite));
            marioDictionary.Add("RIDLFIRE", typeof(IdleFireMarioRightSprite));
            marioDictionary.Add("LJMPFIRE", typeof(JumpFireMarioLeftSprite));
            marioDictionary.Add("RJMPFIRE", typeof(JumpFireMarioRightSprite));
            marioDictionary.Add("LRUNFIRE", typeof(WalkFireMarioLeftSprite));
            marioDictionary.Add("RRUNFIRE", typeof(WalkFireMarioRightSprite));
            marioDictionary.Add("LCRHFIRE", typeof(CrouchFireMarioLeftSprite));
            marioDictionary.Add("RCRHFIRE", typeof(CrouchFireMarioRightSprite));
        }

        public ISprite CreateSprite(IMovementState movement, IConditionState condition)
        {
            ISprite sprite;
            Type spriteType;
            string code = "";
            if (movement != null && condition != null)
            {
                string movementCode = movement.MovementCode;
                string conditionCode = condition.ConditionCode;
                code = movementCode + conditionCode;
            }

            marioDictionary.TryGetValue(code, out spriteType);
            if (spriteType != null)
            {

                ConstructorInfo[] constr = new ConstructorInfo[1];
                constr = spriteType.GetConstructors();
                sprite = (ISprite)constr[0].Invoke(new object[] { marioSpriteSheet });
            }
            else
            {
                sprite = new DeadMarioSprite(marioSpriteSheet);
            }
            return sprite;


        }
    }
}
