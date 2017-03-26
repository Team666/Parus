
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parus.Core.UwpEngine;
using Windows.Media.Playback;
using Windows.Media.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UwpTestground
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly IList<Uri> testFiles = new []
        {
            new Uri("ms-appx:///Assets/got_item.wma"),
            new Uri("ms-appx:///Assets/victory.wma")
        };

        [TestMethod]
        public void TestUwpTestRunner()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task TestMediaPlaylistAssumptions()
        {
            using (var engine = new UwpEngine())
            {
                var nowPlayingList = engine.NowPlayingList;

                var mediaSources = testFiles.Select(MediaSource.CreateFromUri);
                foreach (var source in mediaSources)
                {
                    nowPlayingList.MediaPlaybackList.Items.Add(new MediaPlaybackItem(source));
                }

                engine.Play();
                await Task.Delay(TimeSpan.FromSeconds(1));

                Assert.IsTrue(engine.IsPlaying, "State of engine must be 'Playing' after starting playback");

                await Task.Delay(TimeSpan.FromSeconds(15));
            }
        }

        [TestMethod]
        public async Task TestUwpMediaPlayback()
        {
            // var fileTask = Windows.Storage.StorageFile.GetFileFromPathAsync(@"Z:\Downloads\3 Music\Bayonetta Soundtrack\01-One of a Kind.mp3");
            var fileTask = Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(testFiles[0]);

            using (var mediaPlayer = new MediaPlayer())
            {
                mediaPlayer.Source = MediaSource.CreateFromStorageFile(await fileTask);
                mediaPlayer.RealTimePlayback = true;
                mediaPlayer.MediaFailed += (sender, e) =>
                {
                    Assert.Fail("{0} {1}: {2}", e.Error, e.ErrorMessage, e.ExtendedErrorCode);
                };
                //Assert.IsTrue();

                mediaPlayer.Play();

                await Task.Delay(TimeSpan.FromSeconds(2));
                Assert.AreEqual(MediaPlaybackState.Playing, mediaPlayer.PlaybackSession.PlaybackState);
            }
        }
    }
}
