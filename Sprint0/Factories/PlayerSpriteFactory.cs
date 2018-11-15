using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario;
using System.Collections.Generic;
using System;
using System.Reflection;
using SuperPixelBrosGame.States.Mario.Movement;
using SuperPixelBrosGame.States.Mario.Condition;

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

            marioDictionary.Add(typeof(MarioLeftIdleState).ToString() + typeof(SmallMarioState).ToString(), typeof(IdleSmallMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightIdleState).ToString() + typeof(SmallMarioState).ToString(), typeof(IdleSmallMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftJumpState).ToString() + typeof(SmallMarioState).ToString(), typeof(JumpSmallMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightJumpState).ToString() + typeof(SmallMarioState).ToString(), typeof(JumpSmallMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftRunState).ToString() + typeof(SmallMarioState).ToString(), typeof(WalkSmallMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightRunState).ToString() + typeof(SmallMarioState).ToString(), typeof(WalkSmallMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftCrouchState).ToString() + typeof(SmallMarioState).ToString(), typeof(IdleSmallMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightCrouchState).ToString() + typeof(SmallMarioState).ToString(), typeof(IdleSmallMarioRightSprite));
            marioDictionary.Add(typeof(MarioFlagState).ToString() + typeof(SmallMarioState).ToString(), typeof(FlagSmallMarioSprite));

            marioDictionary.Add(typeof(MarioLeftIdleState).ToString() + typeof(LargeMarioState).ToString(), typeof(IdleMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightIdleState).ToString() + typeof(LargeMarioState).ToString(), typeof(IdleMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftJumpState).ToString() + typeof(LargeMarioState).ToString(), typeof(JumpMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightJumpState).ToString() + typeof(LargeMarioState).ToString(), typeof(JumpMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftRunState).ToString() + typeof(LargeMarioState).ToString(), typeof(WalkMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightRunState).ToString() + typeof(LargeMarioState).ToString(), typeof(WalkMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftCrouchState).ToString() + typeof(LargeMarioState).ToString(), typeof(CrouchMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightCrouchState).ToString() + typeof(LargeMarioState).ToString(), typeof(CrouchMarioRightSprite));
            marioDictionary.Add(typeof(MarioFlagState).ToString() + typeof(LargeMarioState).ToString(), typeof(FlagMarioSprite));

            marioDictionary.Add(typeof(MarioLeftIdleState).ToString() + typeof(FireMarioState).ToString(), typeof(IdleFireMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightIdleState).ToString() + typeof(FireMarioState).ToString(), typeof(IdleFireMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftJumpState).ToString() + typeof(FireMarioState).ToString(), typeof(JumpFireMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightJumpState).ToString() + typeof(FireMarioState).ToString(), typeof(JumpFireMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftRunState).ToString() + typeof(FireMarioState).ToString(), typeof(WalkFireMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightRunState).ToString() + typeof(FireMarioState).ToString(), typeof(WalkFireMarioRightSprite));
            marioDictionary.Add(typeof(MarioLeftCrouchState).ToString() + typeof(FireMarioState).ToString(), typeof(CrouchFireMarioLeftSprite));
            marioDictionary.Add(typeof(MarioRightCrouchState).ToString() + typeof(FireMarioState).ToString(), typeof(CrouchFireMarioRightSprite));
            marioDictionary.Add(typeof(MarioFlagState).ToString() + typeof(FireMarioState).ToString(), typeof(FlagFireMarioSprite));
        }

        public ISprite CreateSprite(IMovementState movement, IConditionState condition)
        {
            ISprite sprite;
            Type spriteType;
            string code = "";
            if (movement != null && condition != null)
            {
                code = movement.GetType().ToString() + condition.GetType().ToString();
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
