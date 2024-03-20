using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoder
{
    public class EmailService : ISubscriberService
    {
        public EmailService(VideoProcessor publisher)
        {
            publisher.VideoEncoded += this.OnVideoEncoded;
            publisher.VideoCompressed += this.OnVideoCompressed;
        }
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine($"Sending Email : You're video {args.Video.Title} Encoded and ready to download");
            
        }

        public void OnVideoCompressed(object source, VideoEventArgs args)
        {
            Console.WriteLine($"Sending Email : You're video {args.Video.Title} Compressed and ready to download");
        }
    }
}
