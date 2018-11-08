using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario;
using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.Xna.Framework.Media;

namespace SuperPixelBrosGame
{
    class SoundFactory
    {
        private IDictionary<string, Song> soundDictionary = new Dictionary<string, Song>();

        private static SoundFactory instance = new SoundFactory();

        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundFactory()
        {

        }

        public void LoadSounds(ContentManager contentManager)
        {
            Song smbTheme = contentManager.Load<Song>("Sounds/smb_theme");

            soundDictionary.Add("SONG_THEME", smbTheme);
        }

        public void PlaySong(string songName)
        {
            Song song;
            soundDictionary.TryGetValue(songName, out song);
            MediaPlayer.Play(song);
        }
    }
}
