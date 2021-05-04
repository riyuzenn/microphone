using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Events;
using DiscordRPC.Message;
using DiscordRPC.Logging;

namespace Serum_Microphone
{
    class DiscordRP
    {
        public DiscordRpcClient client;

        public void Initialize()
        {
            client = new DiscordRpcClient("839001022071963689");

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            // == Subscribe to some events
            client.OnReady += (sender, msg) =>
            {
                //Create some events so we know things are happening
                Console.WriteLine("Connected to discord with user {0}", msg.User.Username);
            };


            client.OnPresenceUpdate += (sender, msg) =>
            {
                //The presence has updated
                Console.WriteLine("Presence has been updated! ");
            };
            
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Serum Microphone",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "large_image",
                    LargeImageText = "Serum Microphone"
                },
                Buttons = new Button[]
                {
                    new Button() { Label = "Download", Url = "https://www.serummicrophone.ml" }
                }
            });

        }

        public void DeInitialize()
        {
            client.Dispose();
        }
    }
}
