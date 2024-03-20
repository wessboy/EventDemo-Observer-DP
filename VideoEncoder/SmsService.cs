using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoder
{
    public class SmsService : ISubscriberService
    {
     
        public SmsService(VideoProcessor publisher)
        {
            publisher.VideoEncoded += this.OnVideoEncoded;
            publisher.VideoCompressed += this.OnVideoCompressed;
            
            
        }

        
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine($"Sending sms : Hey,C it'looks there is an new updates on your latest video project {args.Video.Title}");
        }

        public void OnVideoCompressed(object source, VideoEventArgs args)
        {
            Console.WriteLine($"Sending sms : Hey, C it'looks that the compressing operation ends for the video project {args.Video.Title} !!");
        }

        
    }
}
