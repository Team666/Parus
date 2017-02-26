using Parus.Core.Model;
using System.Collections.Generic;
using Windows.Media.Playback;

namespace Parus.Core.UwpEngine
{
    public class NowPlayingList
    {
        public MediaPlaybackList MediaPlaybackList { get; }

        public NowPlayingList()
        {
            MediaPlaybackList = new MediaPlaybackList();
        }
    }
}