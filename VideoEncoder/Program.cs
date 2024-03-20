

using VideoEncoder;

Video video = new Video() { Title = "dockerDemo.mp4"};
VideoProcessor processor = new VideoProcessor();
EmailService emailService = new(processor);
SmsService smsService = new(processor);



//subscribing to an event 
processor.VideoEncoded += emailService.OnVideoEncoded;
processor.VideoEncoded += smsService.OnVideoEncoded;

