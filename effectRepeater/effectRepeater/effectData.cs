using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Rocket.API;

namespace effectRepeater
{
    public class effectData
    {
        //public ushort Id { get; set; }
        //public double Delay { get; set; }
        //public int TimesToPlay { get; set; }
        //public Thread thread { get; set; }
        //public IRocketPlayer IRocketPlayer { get; set; }
        //public DateTime InitialRun { get; set; }

        public ushort Id;
        public double Delay;
        public int TimeToPlay;
        public Thread Thread;
        public IRocketPlayer IRocketPlayer;
        public DateTime InitialRun;
    }
}
