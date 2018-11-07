﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.GameStates;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class VictoryGameState : AbstractGameState, IGameState
    {
        private int levelTimeOut;
        private FlagPole flagPole;
        private IMario mario;
        private Vector2 location;
        public VictoryGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera, IMario mario, FlagPole flagPole) : base(game, controllerList, camera)
        {
            levelTimeOut = 220;
            this.flagPole = flagPole;
            this.mario = mario;
            location = mario.Location;
        }

        public override void Update()
        {
            if (levelTimeOut > 0)
            {
                IPhysics marioPhysics = (IPhysics)mario;
                PlayerLevel.Instance.LevelUpdate(camera);
                PlayerLevel.Instance.BackgroundDestination = new Rectangle((int)location.X-391, 0, 800, 480);
                if (mario.Location.Y < (flagPole.Location.Y + flagPole.Hitbox.Height - flagPole.Flag.Hitbox.Height) && !(mario.MovementState is MarioRightJumpState))
                {
                    marioPhysics.Velocity = new Vector2(0, 2);
                }
                if (flagPole.Flag.Location.Y < (flagPole.Location.Y + flagPole.Hitbox.Height - flagPole.Flag.Hitbox.Height))
                {
                    flagPole.Flag.Location = new Vector2(flagPole.Flag.Location.X, flagPole.Flag.Location.Y + 2);
                }
                else if (flagPole.Flag.Location.Y >= (flagPole.Location.Y + flagPole.Hitbox.Height - flagPole.Flag.Hitbox.Height) && mario.Location.Y >= (flagPole.Location.Y + flagPole.Hitbox.Height - flagPole.Flag.Hitbox.Height))
                {
                    mario.RunRight();
                    if (mario.MovementState is MarioFlagState)
                    {
                        mario.Jump();
                    }

                }
                //flagPole.Flag.Location = new Vector2(flagPole.Flag.Location.X, flagPole.Location.Y + flagPole.Hitbox.Height - flagPole.Flag.Hitbox.Height);
                levelTimeOut--;
                Console.WriteLine("Timeout: " + levelTimeOut);

            }
            else
            {
                Console.WriteLine("Timeout: " + levelTimeOut);
                Console.WriteLine("Resetting...");
                SuperPixelBrosGame.ResetLevel();
                game.GameState = new NormalGameState(game, controllerList, camera);
            }
        }
    }
}