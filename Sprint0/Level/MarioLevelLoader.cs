using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SuperPixelBrosGame.Level
{
    class MarioLevelLoader : ILevelLoader
    {
        private static MarioLevelLoader instance = new MarioLevelLoader();

        public static MarioLevelLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadLevelFromFile(string filename)
        {
            XmlReader fileReader = XmlReader.Create(filename);
            LoadLevel(fileReader);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private static void LoadLevel(XmlReader reader)
        {
            string objectType = "";
            string objectName = "";
            string location = "";
            bool typeFlag = false;
            bool nameFlag = false;
            bool locationFlag = false;
            IList<IBlock> blockList = new List<IBlock>();
            IList<IEnemy> enemyList = new List<IEnemy>();
            IList<IItem> itemList = new List<IItem>();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                        case "ObjectType":
                            objectType = reader.ReadString();
                            typeFlag = true;
                            break;
                        case "ObjectName":
                            objectName = reader.ReadString();
                            nameFlag = true;
                            break;
                        case "Location":
                            location = reader.ReadString();
                            locationFlag = true;
                            break;
                    }

                    if (typeFlag && nameFlag && locationFlag)
                    {
                        switch (objectType) {
                            case "Player":
                                string[] coordinates = location.Split(' ');
                                Mario.Instance.ConditionState = new SmallMarioState(Mario.Instance);
                                Mario.Instance.Location = new Vector2(Int32.Parse(coordinates[0]),Int32.Parse(coordinates[1]));
                                break;
                            case "Block":
                                switch (objectName)
                                {
                                    case "HiddenBlock":
                                        string[] blockCoordinates = location.Split(' ');
                                        IBlock block = new HiddenBlock();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "HiddenBlockEmpty":
                                        blockCoordinates = location.Split(' ');
                                        block = new HiddenBlockEmpty();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "HiddenBlockCoin":
                                        blockCoordinates = location.Split(' ');
                                        block = new HiddenBlockCoin();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "HiddenBlockStar":
                                        blockCoordinates = location.Split(' ');
                                        block = new HiddenBlockStar();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "BrickBlock":
                                        blockCoordinates = location.Split(' ');
                                        block = new BrickBlock();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "BrickBlockEmpty":
                                        blockCoordinates = location.Split(' ');
                                        block = new BrickBlockEmpty();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "ItemBrick":
                                        blockCoordinates = location.Split(' ');
                                        block = new BrickBlockWithItem();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "ItemBrickCoin":
                                        blockCoordinates = location.Split(' ');
                                        block = new BrickBlockWithCoin();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "ItemBrickStar":
                                        blockCoordinates = location.Split(' ');
                                        block = new BrickBlockWithStar();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "QuestionBlock":
                                        blockCoordinates = location.Split(' ');
                                        block = new QuestionBlock();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "QuestionBlockEmpty":
                                        blockCoordinates = location.Split(' ');
                                        block = new QuestionBlockEmpty();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "QuestionBlockStar":
                                        blockCoordinates = location.Split(' ');
                                        block = new QuestionBlockStar();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "QuestionBlockCoin":
                                        blockCoordinates = location.Split(' ');
                                        block = new QuestionBlockCoin();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "UnbreakableBlock":
                                        blockCoordinates = location.Split(' ');
                                        block = new UnbreakableBlock();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "UsedBlock":
                                        blockCoordinates = location.Split(' ');
                                        block = new UsedBlock();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "GroundBlock":
                                        blockCoordinates = location.Split(' ');
                                        block = new GroundBlock();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                    case "Pipe":
                                        blockCoordinates = location.Split(' ');
                                        block = new Pipe();
                                        block.Location = new Vector2(Int32.Parse(blockCoordinates[0]), Int32.Parse(blockCoordinates[1]));
                                        blockList.Add(block);
                                        break;
                                }
                                break;

                            case "Enemy":
                                switch (objectName)
                                {
                                    case "Goomba":
                                        string[] enemyCoordinates = location.Split(' ');
                                        IEnemy enemy = new Goomba();
                                        enemy.Location = new Vector2(Int32.Parse(enemyCoordinates[0]), Int32.Parse(enemyCoordinates[1]));
                                        enemyList.Add(enemy);
                                        break;
                                    case "Koopa":
                                        enemyCoordinates = location.Split(' ');
                                        enemy = new Koopa();
                                        enemy.Location = new Vector2(Int32.Parse(enemyCoordinates[0]), Int32.Parse(enemyCoordinates[1]));
                                        enemyList.Add(enemy);
                                        break;
                                }
                                break;
                            case "Item":
                                switch (objectName)
                                {
                                    case "Coin":
                                        string[] itemCoordinates = location.Split(' ');
                                        IItem item = new Coin();
                                        item.Location = new Vector2(Int32.Parse(itemCoordinates[0]), Int32.Parse(itemCoordinates[1]));
                                        itemList.Add(item);
                                        break;

                                    case "FireFlower":
                                        itemCoordinates = location.Split(' ');
                                        item = new FireFlower();
                                        item.Location = new Vector2(Int32.Parse(itemCoordinates[0]), Int32.Parse(itemCoordinates[1]));
                                        itemList.Add(item);
                                        break;
                                    case "OneUpMush":
                                        itemCoordinates = location.Split(' ');
                                        item = new OneUpMushroom();
                                        item.Location = new Vector2(Int32.Parse(itemCoordinates[0]), Int32.Parse(itemCoordinates[1]));
                                        itemList.Add(item);
                                        break;
                                    case "SuperMush":
                                        itemCoordinates = location.Split(' ');
                                        item = new SuperMushroom();
                                        item.Location = new Vector2(Int32.Parse(itemCoordinates[0]), Int32.Parse(itemCoordinates[1]));
                                        itemList.Add(item);
                                        break;
                                    case "Star":
                                        itemCoordinates = location.Split(' ');
                                        item = new Star();
                                        item.Location = new Vector2(Int32.Parse(itemCoordinates[0]), Int32.Parse(itemCoordinates[1]));
                                        itemList.Add(item);
                                        break;


                                }
                                break;
                        }
                        typeFlag = false;
                        nameFlag = false;
                        locationFlag = false;
                    }

                }
                
            }
            PlayerLevel.Instance.BlockArray = blockList;
            PlayerLevel.Instance.EnemyArray = enemyList;
            PlayerLevel.Instance.ItemArray = itemList;
        }
    }
}
