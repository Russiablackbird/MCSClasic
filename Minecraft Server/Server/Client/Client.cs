﻿using Minecraft_Server.Framework.Network;
using Minecraft_Server.Server.Network.Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft_Server.Server.Client
{
    class Client : Framework.Client.Client
    {

        private Network.TcpClientm Net;
        public string username;
        public string verfikey;
        public Client(Network.TcpClientm Net)
            : base(Net)
        {
            this.Net = Net;
        }

        public void onConnect()
        {
            //Net.SendPacket(254);
            //Network.MessageQueue.Enqueue(packet);
        }

        public void onClientInfo(string s, byte dis, int chvs, bool ccol, byte dif, bool shc)
        {
        }

        public void onCommand(byte c)
        {
        }

        public void onSharedKey(byte[] s, byte[] v)
        {
        }

        public void onPing(byte s, string name)
        {
        }

        public void onJoin(byte protocolVersion, string name, string vk)
        {
            if (protocolVersion != 7)
                new PacketKick(this.Net, "Bad protocol version").Write();
            this.username = name;
            this.verfikey = vk;

            new Packet0Indentification(this.Net, protocolVersion, 0);//0x64 будет оп
            Thread.Sleep(10);
            new Packet2Level(this.Net).Write();
            Thread.Sleep(10);
                byte[] da = new byte[1024];
                Array.Copy(Main.Main.olda, 0, da, 0, Main.Main.olda.Length);
                new Packet3Chunk(this.Net, da, 100).Write();
                Thread.Sleep(10);
            new Packet4LevelFin(this.Net, 64, 64, 64).Write();
            Thread.Sleep(10);
            new Packet7Spawn(this.Net, (sbyte)-1, "wroud", 5, 5, 5, 0, 0).Write();
        }

        public void onKick()
        {
            //Net.SendPacket(254);
        }
    }
}
