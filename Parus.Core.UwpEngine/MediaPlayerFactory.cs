using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace Parus.Core.UwpEngine
{
    internal class MediaPlayerFactory
    {
        public static MediaPlayer Create(NowPlayingList nowPlayingList)
        {
            return new MediaPlayer
            {
                Source = nowPlayingList.MediaPlaybackList
            };
        }
    }
}
