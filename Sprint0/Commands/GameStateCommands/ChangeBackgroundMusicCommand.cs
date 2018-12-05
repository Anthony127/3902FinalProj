using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class ChangeBackgroundMusicCommand : ICommand
    {

        private string songKey;

        public ChangeBackgroundMusicCommand(string str)
        {
            this.songKey = str;
        }

        public void Execute()
        {
            SoundFactory.Instance.BackgroundSong = SoundFactory.Instance.GetSong(songKey);
        }

    }
}
