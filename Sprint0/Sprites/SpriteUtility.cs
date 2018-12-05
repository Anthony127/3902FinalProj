using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SuperPixelBrosGame.Sprites
{
    public class SpriteUtility
    {
        private static readonly SpriteUtility instance = new SpriteUtility();
        private int BLOCKUNIT = 32;
        private int MATRIXUNIT = 24;

        public int BLOCK_UNIT { get => BLOCKUNIT; private set => BLOCKUNIT = value; }
        public int MATRIX_UNIT { get => MATRIXUNIT; private set => MATRIXUNIT = value; }
        private Dictionary<Type, Color> colorDictionary;
        private Dictionary<string, int> passwordDictionary;

        private SpriteUtility(){
            BLOCK_UNIT = 32;
            MATRIX_UNIT = 24;
            colorDictionary = new Dictionary<Type, Color>
            {
                { typeof(DeadMarioState), Color.White },
                { typeof(SmallMarioState), Color.Blue },
                { typeof(LargeMarioState), Color.White },
                { typeof(FireMarioState), Color.Red },
            };

            passwordDictionary = new Dictionary<string, int>
            {
                {"PixelMario",0},
                {"PixelPeach",1 },
                {"PixelLuigi",2 },
                {"PixelBowser",3 },
                {"Goomba",4 },
                {"QuestionBlock",5 },
                {"RecQuestionBlock", 6 },
                {"SpringPad",7 },
                {"PixelToad", 8 },
                {"PixelBowserJr",9 },
                {"MetalMario", 10 },
                {"GoldMario", 11 },
                {"BuilderMario", 12 },
                {"PixelYoshi" , 13},
                {"ShyGuy", 14 },        
                {"PixelRosalina", 15 },
                {"PixelWario", 16 },
                {"Jumpman",17 },
                {"Koopa", 18 },
                {"HuckitCrab", 19 },
                {"Dr.Mario", 20 },
                {"MarioKart", 21 },
                {"Waluigi", 22 },
                {"GreenYoshi", 23 },
                {"PinkYoshi", 24 },
                {"BlueYoshi", 25 },
                {"BigYoshi", 26 },
                {"DKJr", 27 },
                {"DK", 28 },
                {"DiddyKong", 29 },
                {"Kirby", 30 },
                {"Dedede", 31 },
                {"MetaKnight", 32 },
                {"Pit", 33 },
                {"Palutena", 34 },
                {"Pitoo", 35 },
                {"Rockman", 36 },
                {"Samus", 37 },
                {"ZeroSuit", 38 },
                {"ROB", 39 },
                {"ROBFamicom", 40 },
                {"Marth", 41 },
                {"Ike" , 42},
                {"Lucina", 43 },
                {"Robin", 44 },
                {"Pikachu", 45 },
                {"Charizard", 46 },
                {"Jigglypuff", 47 },
                {"Mewtwo", 48 },
                {"Lucario", 49 },
                {"Greninja", 50 },
                {"Olimar", 51 },
                {"Pikmin", 52 },
                {"Link", 53 },
                {"Zelda", 54 },
                {"Ganondorf", 55 },
                {"Sheik", 56 },
                {"Tingle", 57 },
                {"LinkWW", 58 },
                {"Shulk", 59 },
                {"Ness", 60 },
                {"Lucas", 61 },
                {"GreenSquid", 62 },
                {"BlueInkling", 63 },
                {"BlueSquid", 64 },
                {"OrangeInkling", 65 },
                {"OrangeSquid", 66 },
                {"WiiFitBoard", 67 },
                {"WiiFitTrainer", 68 },
                {"ChibiRobo", 69 },
                {"Villager", 70 },
                {"TomNook" , 71},
                {"KKSlider", 72 },
                {"Mabel", 73 },
                {"Resetti", 74 },
                {"Rover", 75 },
                {"Blathers", 76 },
                {"TimmyTommy", 77 },
                {"Kappn", 78 },
                {"Celeste", 79 },
                {"Kicks", 80 },
                {"Isabelle", 81 },
                {"IsabelleAlt", 82 },
                {"Digby", 83 },
                { "Cyrus", 84},
                {"Reese", 85 },
                {"Lottie", 86 },
                {"CFalcon", 87 },
                {"G&W", 88 },
                {"Sonic", 89 },
                {"DuckHunt", 90 },
                {"PacMan", 91 },
                {"Foreman", 92 },
                {"LittleMac", 93 },
                {"Fox", 94 },
                {"Falco", 95 },
                {"Slippy ", 96 },
                {"Peppy", 97 },
                {"Arwing", 98 },
                {"Mahjong", 99 },
                {"DrLobe", 100 },
                {"Ashley", 101 },
                {"Nikki", 102 },
                {"FighterFly", 103 },
                {"TotemLink", 104 },
                {"Arino", 105 },
                {"MarioKun", 106 },
                {"CatMario", 107 },
                {"CatPeach", 108 },
                {"Necky", 109 },
                {"FrogMario", 110 },
                {"MarioTrio", 111 },
                {"GLA", 112 },
                {"Felyne", 113 },
                {"SkyPop", 114 },
                {"ArcadeBunny", 115 },
                {"MasterBelch", 116 },
                {"MrSaturn", 117 },
                {"CptToad", 118 },
                {"Excitebike", 119 },
                {"Brido", 120 },
                {"Yamamura", 121 },
                {"Daisy", 122 },
                {"Egadd", 123 },
                {"Bulbasaur", 124 },
                {"Charmander", 125 },
                {"Squirtle", 126 },
                {"Chitoge", 127 },
                {"Barbara", 128 },
                {"StatueMario", 129 },
                {"MaryO", 130 },
                {"CptToadette", 131 },
                {"Yu", 132 },
                {"Starfy", 133 },
                {"Midna", 134 },
                {"Balloon", 135 },
                {"Nabbit", 136 },
                {"Tetra", 137 },
                {"Donbe", 138 },
                {"Hikari", 139 },
                {"BabyMario", 140 },
                {"Iris", 141 },
                {"Mallo", 142 },
                {"Bubble", 143 },
                {"Diskun", 144 },
                {"Volleyball", 145 },
                {"BABYMETAL", 146 },
                {"Popo&Nana", 147 },
                {"HelloKitty", 148 },
                {"HelloKittyAlt", 149 },
                {"Melody", 150 },
                {"MelodyAlt", 151 },
                {"ShaunSheep", 152 },
                {"Undodog", 153 },
                {"BrainAge", 154 },
                {"Callie", 155 },
                {"PinkSquid", 156 },
                {"Marie", 157 },
                {"GreenSquidAlt", 158 }



            };
        }

        public static SpriteUtility Instance
        {
            get
            {
                return instance;
            }
        }

        public Color ColorFromState (IConditionState conditionState)
        {
            Color color = Color.White;
            colorDictionary.TryGetValue(conditionState.GetType(), out color);
            return color;
        }

        public void parsePassword(string password)
        {
            int rowId = -1;
            passwordDictionary.TryGetValue(password, out rowId);
            Mario.Instance.RowId = rowId;
            Mario.Instance.UpdateSprite();
            Debug.Print("SPRITE UPDATED TO: " + password + ", " + rowId.ToString());
        }
    }
}
