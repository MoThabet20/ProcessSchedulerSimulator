using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedualProcessOS.BL
{
    public class Processes
    {

        public string processName { get; set; }
        public int ArivalTime { get; set; }
        private int _burstTime;
        public int BurstTime
        {
            get => _burstTime;
            set
            {
                _burstTime = value;
                RemainingBurstTime = value;
            }
        }
        public int RemainingBurstTime { get; set; }
    }
}
