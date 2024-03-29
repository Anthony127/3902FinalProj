﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario;
using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using SuperPixelBrosGame.HUDComponents;

namespace SuperPixelBrosGame
{
    class SoundFactory
    {
        private IDictionary<string, Song> songDictionary = new Dictionary<string, Song>();
        private IDictionary<string, SoundEffect> soundEffectDictionary = new Dictionary<string, SoundEffect>();
        private readonly int HURRY_UP_THRESHOLD = 93;
        private Song backgroundSong;

        private static SoundFactory instance = new SoundFactory();

        public Song BackgroundSong { set => backgroundSong = value; }

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

        public void LoadSongs(ContentManager contentManager)
        {
            Song stageClear = contentManager.Load<Song>("Sounds/smb_stage_clear");
            Song starman = contentManager.Load<Song>("Sounds/smb_starman");
            Song theme = contentManager.Load<Song>("Sounds/smb_theme");
            Song warning = contentManager.Load<Song>("Sounds/smb_warning");
            Song worldClear = contentManager.Load<Song>("Sounds/smb_world_clear");
            Song miles1000 = contentManager.Load<Song>("1000Miles");
            Song skyrim = contentManager.Load<Song>("Skyrim");
            Song numaNuma = contentManager.Load<Song>("NumaNuma");
            Song kansaiDorifto = contentManager.Load<Song>("90s");
            Song ninja = contentManager.Load<Song>("UnbreakableDetermination");
            Song hurryUp = contentManager.Load<Song>("Sounds/smb_hurry-up-theme-fast");
            Song fastTheme = contentManager.Load<Song>("Sounds/smb_theme-fast");

            songDictionary.Add("BACKGROUND_MUSIC_THEME", theme);
            songDictionary.Add("MUSIC_WARNING", warning);
            songDictionary.Add("MUSIC_WORLD_CLEAR", worldClear);
            songDictionary.Add("MUSIC_STAGE_CLEAR", stageClear);
            songDictionary.Add("MUSIC_STARMAN", starman);
            songDictionary.Add("MUSIC_HURRY_UP", hurryUp);
            songDictionary.Add("MUSIC_THEME_FAST", fastTheme);

            songDictionary.Add("ALT_MUSIC_1000_MILES", miles1000);
            songDictionary.Add("ALT_MUSIC_SKYRIM", skyrim);
            songDictionary.Add("ALT_MUSIC_NUMA", numaNuma);
            songDictionary.Add("ALT_MUSIC_KANSAI_DORIFTO", kansaiDorifto);
            songDictionary.Add("ALT_MUSIC_NINJA", ninja);

            backgroundSong = theme;
        }

        public void LoadSoundEffects(ContentManager contentManager)
        {
            SoundEffect oneUp = contentManager.Load<SoundEffect>("Sounds/smb_1-up");
            SoundEffect bowserFire = contentManager.Load<SoundEffect>("Sounds/smb_bowserfire");
            SoundEffect breakBlock = contentManager.Load<SoundEffect>("Sounds/smb_breakblock");
            SoundEffect bump = contentManager.Load<SoundEffect>("Sounds/smb_bump");
            SoundEffect coin = contentManager.Load<SoundEffect>("Sounds/smb_coin");
            SoundEffect fireball = contentManager.Load<SoundEffect>("Sounds/smb_fireball");
            SoundEffect fireworks = contentManager.Load<SoundEffect>("Sounds/smb_fireworks");
            SoundEffect flagpole = contentManager.Load<SoundEffect>("Sounds/smb_flagpole");
            SoundEffect gameOver = contentManager.Load<SoundEffect>("Sounds/smb_gameover");
            SoundEffect jumpSmall = contentManager.Load<SoundEffect>("Sounds/smb_jump-small");
            SoundEffect jumpSuper = contentManager.Load<SoundEffect>("Sounds/smb_jump-super");
            SoundEffect kick = contentManager.Load<SoundEffect>("Sounds/smb_kick");
            SoundEffect marioDie = contentManager.Load<SoundEffect>("Sounds/smb_mariodie");
            SoundEffect pause = contentManager.Load<SoundEffect>("Sounds/smb_pause");
            SoundEffect pipe = contentManager.Load<SoundEffect>("Sounds/smb_pipe");
            SoundEffect powerUp = contentManager.Load<SoundEffect>("Sounds/smb_powerup");
            SoundEffect powerUpAppears = contentManager.Load<SoundEffect>("Sounds/smb_powerup_appears");
            SoundEffect stomp = contentManager.Load<SoundEffect>("Sounds/smb_stomp");
            SoundEffect vine = contentManager.Load<SoundEffect>("Sounds/smb_vine");

            soundEffectDictionary.Add("SOUND_1UP", oneUp);
            soundEffectDictionary.Add("SOUND_BOWSER_FIRE", bowserFire);
            soundEffectDictionary.Add("SOUND_BLOCK_BREAK", breakBlock);
            soundEffectDictionary.Add("SOUND_BUMP", bump);
            soundEffectDictionary.Add("SOUND_COIN", coin);
            soundEffectDictionary.Add("SOUND_FIREBALL", fireball);
            soundEffectDictionary.Add("SOUND_FIREWORKS", fireworks);
            soundEffectDictionary.Add("SOUND_FLAGPOLE", flagpole);
            soundEffectDictionary.Add("SOUND_GAMEOVER", gameOver);
            soundEffectDictionary.Add("SOUND_JUMP_SMALL", jumpSmall);
            soundEffectDictionary.Add("SOUND_JUMP_SUPER", jumpSuper);
            soundEffectDictionary.Add("SOUND_KICK", kick);
            soundEffectDictionary.Add("SOUND_DEATH", marioDie);
            soundEffectDictionary.Add("SOUND_PAUSE", pause);
            soundEffectDictionary.Add("SOUND_PIPE", pipe);
            soundEffectDictionary.Add("SOUND_POWERUP", powerUp);
            soundEffectDictionary.Add("SOUND_POWERUP_APPEARS", powerUpAppears);
            soundEffectDictionary.Add("SOUND_STOMP", stomp);
            soundEffectDictionary.Add("SOUND_VINE", vine);
        }

        public void PlaySong(string songName)
        {
            Song song;
            songDictionary.TryGetValue(songName, out song);
            MediaPlayer.Play(song);
        }

        public void PlaySoundEffect(string soundEffectName)
        {
            SoundEffect soundEffect;
            soundEffectDictionary.TryGetValue(soundEffectName, out soundEffect);
            if (soundEffect != null)
            {
                soundEffect.Play();
            }

        }

        public Song GetSong(string str)
        {
            Song song;
            songDictionary.TryGetValue(str, out song);
            return song;
        }

        public void PlayBackgroundMusic()
        {
            Song song;
            if (ScoreKeeper.Instance.Time < HURRY_UP_THRESHOLD)
            {
                songDictionary.TryGetValue("MUSIC_THEME_FAST", out song);
                MediaPlayer.Play(song);
            }
            else
            {
                MediaPlayer.Play(backgroundSong);
            }


        }
    }
}
