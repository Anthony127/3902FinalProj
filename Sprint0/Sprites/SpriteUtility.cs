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
                {"Reset", -1 },
                {"Pixelmario",0},
                {"Pixelpeach",1 },
                {"Pixelluigi",2 },
                {"Pixelbowser",3 },
                {"Goomba",4 },
                {"Questionblock",5 },
                {"Recquestionblock", 6 },
                {"Springpad",7 },
                {"Pixeltoad", 8 },
                {"Pixelbowserjr",9 },
                {"Metalmario", 10 },
                {"Goldmario", 11 },
                {"Buildermario", 12 },
                {"Pixelyoshi" , 13},
                {"Shyguy", 14 },
                {"Pixelrosalina", 15 },
                {"Pixelwario", 16 },
                {"Jumpman",17 },
                {"Koopa", 18 },
                {"Huckitcrab", 19 },
                {"Dr.mario", 20 },
                {"Mariokart", 21 },
                {"Waluigi", 22 },
                {"Greenyoshi", 23 },
                {"Pinkyoshi", 24 },
                {"Blueyoshi", 25 },
                {"Bigyoshi", 26 },
                {"Dkjr", 27 },
                {"DK", 28 },
                {"Diddykong", 29 },
                {"Kirby", 30 },
                {"Dedede", 31 },
                {"Metaknight", 32 },
                {"Pit", 33 },
                {"Palutena", 34 },
                {"Pitoo", 35 },
                {"Rockman", 36 },
                {"Samus", 37 },
                {"Zerosuit", 38 },
                {"Rob", 39 },
                {"Robfamicom", 40 },
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
                {"Linkww", 58 },
                {"Shulk", 59 },
                {"Ness", 60 },
                {"Lucas", 61 },
                {"Greensquid", 62 },
                {"Blueinkling", 63 },
                {"Bluesquid", 64 },
                {"Orangeinkling", 65 },
                {"Orangesquid", 66 },
                {"Wiifitboard", 67 },
                {"Wiifittrainer", 68 },
                {"Chibirobo", 69 },
                {"Villager", 70 },
                {"Tomnook" , 71},
                {"Kkslider", 72 },
                {"Mabel", 73 },
                {"Resetti", 74 },
                {"Rover", 75 },
                {"Blathers", 76 },
                {"Timmytommy", 77 },
                {"Kappn", 78 },
                {"Celeste", 79 },
                {"Kicks", 80 },
                {"Isabelle", 81 },
                {"Isabellealt", 82 },
                {"Digby", 83 },
                { "Cyrus", 84},
                {"Reese", 85 },
                {"Lottie", 86 },
                {"Cfalcon", 87 },
                {"G&w", 88 },
                {"Sonic", 89 },
                {"Duckhunt", 90 },
                {"Pacman", 91 },
                {"Foreman", 92 },
                {"Littlemac", 93 },
                {"Fox", 94 },
                {"Falco", 95 },
                {"Slippy ", 96 },
                {"Peppy", 97 },
                {"Arwing", 98 },
                {"Mahjong", 99 },
                {"Drlobe", 100 },
                {"Ashley", 101 },
                {"Nikki", 102 },
                {"Fighterfly", 103 },
                {"Totemlink", 104 },
                {"Arino", 105 },
                {"Mariokun", 106 },
                {"Catmario", 107 },
                {"Catpeach", 108 },
                {"Necky", 109 },
                {"Frogmario", 110 },
                {"Mariotrio", 111 },
                {"Gla", 112 },
                {"Felyne", 113 },
                {"Skypop", 114 },
                {"Arcadebunny", 115 },
                {"Masterbelch", 116 },
                {"Mrsaturn", 117 },
                {"Cpttoad", 118 },
                {"Excitebike", 119 },
                {"Birdo", 120 },
                {"Yamamura", 121 },
                {"Daisy", 122 },
                {"Egadd", 123 },
                {"Bulbasaur", 124 },
                {"Charmander", 125 },
                {"Squirtle", 126 },
                {"Chitoge", 127 },
                {"Barbara", 128 },
                {"Statuemario", 129 },
                {"Maryo", 130 },
                {"Cpttoadette", 131 },
                {"Yu", 132 },
                {"Starfy", 133 },
                {"Midna", 134 },
                {"Balloon", 135 },
                {"Nabbit", 136 },
                {"Tetra", 137 },
                {"Donbe", 138 },
                {"Hikari", 139 },
                {"Babymario", 140 },
                {"Iris", 141 },
                {"Mallo", 142 },
                {"Bubble", 143 },
                {"Diskun", 144 },
                {"Volleyball", 145 },
                {"Babymetal", 146 },
                {"Popo&nana", 147 },
                {"Hellokitty", 148 },
                {"Hellokittyalt", 149 },
                {"Melody", 150 },
                {"Melodyalt", 151 },
                {"Shaunsheep", 152 },
                {"Undodog", 153 },
                {"Brainage", 154 },
                {"Callie", 155 },
                {"Pinksquid", 156 },
                {"Marie", 157 },
                {"Greensquidalt", 158 }



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
        }
    }
}
