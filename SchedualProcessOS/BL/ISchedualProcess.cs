using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedualProcessOS.BL
{
    public interface ISchedualProcess
    {
        //2properties
        public List<Processes> MainProcesses { get; set; }
        //queue 
        public List<Processes> WaitingProcesses { get; set; }

        //endedProcess
        public List<Processes> EndedProcesses { get; set; }

        //Methods
        //Method1---> treat with incoming process and compare it with the process
        // in the queue and it returns Process.
        public Processes IncomingProcesses(Processes incomingProcess, int timeLineIndex);
        //this option for the first process in the program
        public Processes IncomingProcesses();
        //Method2----> treat with an Queue to get from it a Process
        // that i dont have process to compare
        public Processes IncomingQueue(Processes incomingProcess);

    }
}
