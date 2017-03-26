using System;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace Parus.Core.UwpEngine
{
    public class UwpEngine : IEngine
    {
        private readonly MediaPlayer mediaPlayer;

        public UwpEngine()
        {
            NowPlayingList = new NowPlayingList();
            mediaPlayer = MediaPlayerFactory.Create(NowPlayingList);
        }

        public NowPlayingList NowPlayingList { get; }

        public bool IsPlaying
        {
            get { return mediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Playing; }
        }

        public void Play()
        {
            mediaPlayer.Play();
        }

        public void Pause()
        {
            mediaPlayer.Pause();
        }

        public void Next()
        {
            NowPlayingList.MediaPlaybackList.MoveNext();
        }

        public void Dispose()
        {
            mediaPlayer?.Dispose();
        }
    }
}