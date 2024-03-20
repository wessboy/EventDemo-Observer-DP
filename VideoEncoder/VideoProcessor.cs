using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoder
{
    
     public class VideoProcessor
    {
        private Video _video;

        protected EventHandlerList listEventDelegates = new EventHandlerList();

        public VideoProcessor(Video video)
        {
            _video = video;
        }

        #region event pblishers

        static readonly object videoEncodedKey = new object();
        static readonly object videoCompressedKey = new object();
        static readonly object videoUploadedKey = new object();

        public event EventHandler<VideoEventArgs>? VideoEncoded
        {
            add
            {
                listEventDelegates.AddHandler(videoEncodedKey,value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(videoCompressedKey,value);
            }
        }
        private Video OnVideoEncoded(Video video)
        {
            EventHandler<VideoEventArgs> videoEncodedDelegate = (EventHandler<VideoEventArgs>)listEventDelegates[videoEncodedKey];  
            videoEncodedDelegate(this,new VideoEventArgs { Video = video });

            return video;

        }

        public event EventHandler<VideoEventArgs>? VideoCompressed
        {
            add {
                listEventDelegates.AddHandler(videoCompressedKey,value);
                }
            remove {
                listEventDelegates.RemoveHandler(videoCompressedKey, value);  
                   }
        }
         private void OnVideoCompressed(Video video)
        {
            EventHandler<VideoEventArgs> videoCompressedDelegate = (EventHandler<VideoEventArgs>)listEventDelegates[videoCompressedKey];
            videoCompressedDelegate(this,new VideoEventArgs { Video = video });
        }

        public event EventHandler VideoUploaded
        {
            add
            {
                listEventDelegates.AddHandler(videoUploadedKey,value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(videoUploadedKey,value);

            }
        }
        
     

        #endregion


        private void EncodeVideo(Video video) 
        {
            Console.WriteLine("Encoding video please wait...");

            Thread.Sleep(5000);

            OnVideoEncoded(video);
            
        }

        private void CompressVideo(Video video)
        {
            Console.WriteLine("Compressing Video please wait ....");
            Thread.Sleep(5000);
            OnVideoCompressed(video);
        }

      

        public void ProcessVideo()
        {
            this.EncodeVideo(_video);
            this.CompressVideo(_video);
        }


    }
}
