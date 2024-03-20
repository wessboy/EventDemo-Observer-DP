using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoder
{
     public interface ISubscriberService
    {
        void OnVideoEncoded(object source, VideoEventArgs args);
    }
}
