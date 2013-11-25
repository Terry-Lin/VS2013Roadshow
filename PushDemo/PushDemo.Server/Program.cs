using System;
using PushSharp;
using PushSharp.Apple;
using System.IO;
using PushSharp.Android;
using System.Collections.Generic;

namespace PushDemo.Server
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//APNS
            var push = new PushBroker();
            var cert = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                        "PushDemo.p12"));
            string ipadtoken = "6f22cc6eaff02281125092987dd6b9dc1242722bb455253ff308f71dab296169";
            string iphoneToken = "5477ac3de431bcf89982c569cb33846285565b7f62b235ad10d8737754b8b81a";

            var settings = new ApplePushChannelSettings(cert, "pushdemo");

			push.RegisterAppleService(settings);

            var Notification = new AppleNotification()
				.ForDeviceToken(iphoneToken)
					.WithAlert("欢迎来到Visual Studio 2013新功能会议!")
                    .WithSound("sound.caf")
                    .WithBadge(4);

			push.QueueNotification(Notification);
            Console.WriteLine("Waiting for Queue to Finish...");



            Console.WriteLine("Queue Finished.....");
		
			//GCM


			var RegID_phone = "APA91bEHi1O4JzS3tmtAY5zycJCTcUZyxvDgwKRjHdvvp02DfEGsC433d5xN0Naf8BF1-l1Q9kQra_GpslhXuB-D_lyiJdLWlCKehwgAsNdVhUcLIeHp7-aElC_kol62yBZ1ZJtInwq7";
			var RegID_emulator = "APA91bFj1aE5r6TjypnfvAKzTBK19eYGLfuBpKldIhMCwn5YiubfmUFLJg54Pw2tFvvZnC0w4QIR35Wlrf6phzuKS1L8r0YfVHbYfo8tNlQNmQ9WjMHUgam5rC2HrApQDQrLJyhXAcwj";

			push.RegisterGcmService(new GcmPushChannelSettings("AIzaSyARS7ie-GIeCSGAx_bxq9yQk6l9xgl_2IM"));

			push.QueueNotification (new GcmNotification ().ForDeviceRegistrationId (RegID_emulator)
			                        .WithJson("{\"alert\":\"欢迎来到Visual Studio 2013新功能会议!\",\"badge\":7,\"sound\":\"sound.caf\"}"));


			push.StopAllServices();

           
		}
	}
}
