using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using UnityEngine;
using System.Threading;
using SDG.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Core;

namespace TpsAutomaticCommands
{
    class TpsAutoRunCommands : RocketPlugin<TpsCommandConfig>
    {
        public static TpsAutoRunCommands Instance;

        public Thread RunningThread;

        public bool RunningCountdown = false;

        public static float TPS;
        private float updateInterval = 0.005f;
        private float accum;
        private int frames;
        private float timeleft;
        public static DateTime Started = DateTime.UtcNow;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("TpsAutoCommands has loaded!");
            RunningThread = startThread();
        }

        protected override void Unload()
        {
            Logger.Log("TpsAutoCommands has Unloaded!");
            RunningThread.Abort();
        }

        // This code is from the FPScap plugin on https://dev.rocketmod.net/?rplugin=fps-cap
        // Original can be found here https://github.com/cartman-2000/FPSCap/blob/master/FPSCap.cs
        public void Update()
        {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            frames++;
            if (timeleft <= 0.0)
            {
                TPS = accum / frames;
                timeleft = updateInterval;
                accum = 0f;
                frames = 0;
            }
        }

        Thread startThread()
        {
            Thread t = null;    
            t = new Thread(() => checkTpsThread(t, DateTime.Now));
            t.Start();
            return t;
        }

        void checkTpsThread(Thread t, DateTime dt)
        {
            int TimeToShowWarnings = Instance.Configuration.Instance.SecondsToBroadcastWarnings;
            bool countDownDone = false;

            while (true)
            {
                if (!RunningCountdown)
                {
                    countDownDone = false;
                }

                if ((DateTime.Now - dt).TotalSeconds >= (double)2 || RunningCountdown)
                {
                    if (!RunningCountdown)
                    {
                        dt = DateTime.Now; 
                    }

                    //Logger.Log("TotalSeconds is less then 2!");
                    if (TpsAutoRunCommands.TPS <= Instance.Configuration.Instance.TpsToTriggerCommands && !RunningCountdown)
                    {
                        //Logger.Log("Low Tps Found!");
                        if (Instance.Configuration.Instance.showWarningsBeforeCommands)
                        {
                            //Logger.Log("starting cooldown!");
                            RunningCountdown = true; 
                        }
                        else
                        {
                            //Logger.Log("warning msgs disabled. running commands");
                            foreach (string s in Instance.Configuration.Instance.commands)
                            {
                                Commander.execute(new Steamworks.CSteamID(0), s);
                            }
                        }
                    }
                    else if (RunningCountdown)
                    {
                       // Logger.Log("countdown started!");
                        if (!countDownDone)
                        {
                            //Logger.Log("countdown isnt done!");
                            if (!countDownDone && TimeToShowWarnings > 0)
                            {
                                //Logger.Log("timetoshowwarning is greater than zero!");
                                if (TimeToShowWarnings == 0)
                                {
                                    //Logger.Log("warnings are at 0!");
                                    countDownDone = true;
                                    TimeToShowWarnings = Instance.Configuration.Instance.SecondsToBroadcastWarnings;
                                }
                                else
                                {
                                    while (TimeToShowWarnings > 0)
                                    {
                                        UnturnedChat.Say("Server tps is low. Running commands to clear lag in " + TimeToShowWarnings.ToString() + " seconds", UnityEngine.Color.red);
                                        Thread.Sleep(1000);
                                        TimeToShowWarnings--;
                                    }
                                }
                            }
                            else if (TimeToShowWarnings == 0 && RunningCountdown)
                            {
                                //Logger.Log("executing commands!");
                                foreach (string s in Instance.Configuration.Instance.commands)
                                {
                                    if (!R.Commands.Execute(new ConsolePlayer(), s))
                                    {
                                        if (Commander.execute(new Steamworks.CSteamID(0), s))
                                        {
                                            Logger.LogError(s + " ran!");
                                        }
                                        else
                                        {
                                            Logger.LogError(s + " didnt run!");
                                        }
                                    }
                                }
                                countDownDone = true;
                                RunningCountdown = false;
                                TimeToShowWarnings = Instance.Configuration.Instance.SecondsToBroadcastWarnings;
                            }
                        }
                    }
                }

                Thread.Sleep(10);  
            }
        }
    }
}
