using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    internal class ISP
    {
        //Interface Segregation Principle
        public interface IAudioPlayer
        {
            void PlayAudio();
        }
        public interface IVideoPlayer
        {
            void PlayVideo();
        }
        public interface ISubtitleDisplay
        {
            void DisplaySubtitles();
        }
        public interface IMediaLoader
        {
            void LoadMedia(string filePath);
        }
        public class AudioPlayer : IAudioPlayer, IMediaLoader
        {
            public void PlayAudio()
            {
                Console.WriteLine("Play Audio");
            }

            public void LoadMedia(string filePath)
            {
                Console.WriteLine("load media");
            }
        }
        public class VideoPlayer : IVideoPlayer, IMediaLoader,ISubtitleDisplay
        {
            public void PlayVideo()
            {
                Console.WriteLine("play video");
            }

            public void LoadMedia(string filePath)
            {
                Console.WriteLine("load media");
            }

            public void DisplaySubtitles()
            {
                Console.WriteLine("display subtitles");
            }
        }

    }
}
