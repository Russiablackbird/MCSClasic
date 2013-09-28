﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using Minecraft_Server.Framework.Util;
using Minecraft_Server.Server.Util;

namespace Minecraft_Server.Server.Network
{
    class HeartBeats
    {
        public static WebClient http;
        public static Thread thread;
        public static void Start()
        {
            thread = new Thread(Thr);
            http = new WebClient();
            thread.Start();
            Log.Info("HeartBeat запущен");
        }
        private static void Thr()
        {
            while (true)
            {
                http.DownloadData("https://minecraft.net/heartbeat.jsp" 
                    + "?port=" + Config.server_port 
                    + "&max=" + Config.max_players 
                    + "&name=" + Config.server_name 
                    + "&public=" + Config.white_list 
                    + "&version=7" 
                    + "&salt=" + Config.Salt
                    + "&users=" + Framework.Network.Network.net.connects.Count);
                Thread.Sleep(45000);
            }
        }
    }
}
