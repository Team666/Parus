using Windows.Media.Playback;

namespace Parus.Core.UwpEngine
{
    public class UwpEngine
    {
        private readonly MediaPlayer mediaPlayer;

        public UwpEngine()
        {
            NowPlayingList = new NowPlayingList();
            mediaPlayer = MediaPlayerFactory.Create(NowPlayingList);
        }

        public NowPlayingList NowPlayingList { get; }
    }
}