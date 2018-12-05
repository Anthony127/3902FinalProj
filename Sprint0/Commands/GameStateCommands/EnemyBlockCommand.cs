using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class EnemyBlockCommand : ICommand
    {
        private SuperPixelBrosGame SuperPixelBrosGame;
        private PasswordInputController controller;

        public EnemyBlockCommand(SuperPixelBrosGame SuperPixelBrosGame, PasswordInputController controller)
        {
            this.SuperPixelBrosGame = SuperPixelBrosGame;
            this.controller = controller;
        }

        public void Execute()
        {
            List<IBlock> removedBlocks = new List<IBlock>();
            List<IBlock> addedBlocks = new List<IBlock>();
            Random rnd = new Random();
            foreach (IBlock block in PlayerLevel.Instance.BlockArray)
            {
                if (block is QuestionBlock)
                {
                    if (rnd.Next(0, 1) == 1)
                    {
                        removedBlocks.Add(block);
                        IBlock newBlock = new EnemyBlock();
                        newBlock.Location = block.Location;
                        addedBlocks.Add(newBlock);
                    }
                }
            }
            foreach (IBlock rblock in removedBlocks) {
                PlayerLevel.Instance.BlockArray.Remove(rblock);
            }
            foreach(IBlock ablock in addedBlocks)
            {
                PlayerLevel.Instance.BlockArray.Add(ablock);
            }
        }

    }
}
