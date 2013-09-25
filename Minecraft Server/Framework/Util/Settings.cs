﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
public class ServerConf
{

    #region "ConfigStructure"
    public static struct Config
    {
        public static string generator_settings;
        public static string level_name;
        public static string server_port;
        public static string level_seed;
        public static string server_ip;
        public static string white_list;
        public static string gamemode;
        public static string max_players;
        public static string motd;
        public static string Salt;
    }
    #endregion

    public static string Start()
    {

        string[] Readtxt = null;
        if (File.Exists("Config.cgf"))
        {
            Readtxt = File.ReadAllLines("Config.cgf");
            Dictionary<string, string> vars = new Dictionary<string, string>();
            foreach (string len in Readtxt)
            {
                string[] sp = len.Split('=');
                vars.Add(sp[0].Replace(" ",""), sp[1]);
            }
            Config.generator_settings = vars["generator-settings"];
            Config.level_name = vars["level-name"];
            Config.server_port = vars["server-port"];
            Config.level_seed = vars["level-seed"];
            Config.server_ip = vars["server-ip"];
            Config.white_list = vars["white-list"];
            Config.gamemode = vars["gamemode"];
            Config.max_players = vars["max-players"];
            Config.motd = vars["motd"];
            Config.Salt = vars["salt"];
            return "Configuration file is loading";
        }
        else
        {
            string[] Writetxt = new string[10];
            Writetxt[0] = "generator-settings=Nothing";
            Writetxt[1] = "level-name=world";
            Writetxt[2] = "server-port=25565";
            Writetxt[3] = "level-seed=22";
            Writetxt[4] = "server-ip=127.0.0.1";
            Writetxt[5] = "white-list=false";
            Writetxt[6] = "gamemode=0";
            Writetxt[7] = "max-players=20";
            Writetxt[8] = "motd=A Minecraft Server";
            Writetxt[9] = "salt=fhddfhdfhdfhdfh";
            File.WriteAllLines("Config.cgf", Writetxt);
            return "Configuration file create";
        }
    }
}