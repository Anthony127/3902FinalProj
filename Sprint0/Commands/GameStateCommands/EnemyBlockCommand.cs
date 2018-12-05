using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class EnemyBlockCommand : ICommand
    {

        public EnemyBlockCommand()
        {
        }

        public void Execute()
        {
            Debug.Print("EnemyBlocks spawned.");
            List<IBlock> removedBlocks = new List<IBlock>();
            List<IBlock> addedBlocks = new List<IBlock>();
            Random rnd = new Random();
            foreach (IBlock block in PlayerLevel.Instance.BlockArray)
            {
                if (block is QuestionBlock)
                {
                    Debug.Print("Question Block found");
                    if (rnd.Next(0, 100) % 2 == 0)
                    {
                        Debug.Print("Question Block Replaced");
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
