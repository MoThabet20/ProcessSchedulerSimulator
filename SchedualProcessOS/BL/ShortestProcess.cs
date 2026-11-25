using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedualProcessOS.BL
{
    public class ShortestProcess : ISchedualProcess
    {
        public List<Processes> MainProcesses { get ; set; }
        public List<Processes> WaitingProcesses { get; set; }
        public List<Processes> EndedProcesses { get; set; }

        public ShortestProcess()
        {
            WaitingProcesses = new List<Processes>();
            MainProcesses = new List<Processes>();
            EndedProcesses= new List<Processes>();
        }
        public ShortestProcess(List<Processes> mainProcesses)
        {
            MainProcesses = mainProcesses;
            WaitingProcesses = new List<Processes>();
            EndedProcesses = new List<Processes>();
        }
        public Processes IncomingProcesses(Processes currentProcess, int timeLineIndex)
        {
            //check for incoming process using the timelineIndex
            //use LINQ to get the process that her arrivalTime ==timelineIndex
            Processes myProcess = MainProcesses.Where(a=>a.ArivalTime==timeLineIndex).FirstOrDefault();
            if (myProcess == null)
                return currentProcess;
            else
            {
                if (currentProcess == null || currentProcess.RemainingBurstTime <= 0)
                    return myProcess;

                //case for each process myProcess or currentProcess
                if(myProcess.RemainingBurstTime < currentProcess.RemainingBurstTime)
                {
                    WaitingProcesses.Add(currentProcess);
                    return myProcess;
                }
                else
                {
                    WaitingProcesses.Add(myProcess);
                    return currentProcess;
                }
            }

        }

        public Processes IncomingProcesses()
        {
            //this is risk because i depend on the data in general in json accending input
            //but i want to be completely depend on the arrivalTime without control json objects
            //return MainProcesses.FirstOrDefault();

            return MainProcesses.Where(a => a.ArivalTime == 0)
                                 .OrderBy(a => a.ArivalTime)
                                 .FirstOrDefault();
        }

        public Processes IncomingQueue(Processes currentProcess)
        {
            //get the minimum burstTime process
            int minBurstTime = WaitingProcesses.Min(a => a.RemainingBurstTime);
            //get process
            Processes myProcess = WaitingProcesses.Where(a => a.RemainingBurstTime == minBurstTime).FirstOrDefault();

            //adding new check for null handling
            if (currentProcess == null || currentProcess.RemainingBurstTime==0)
            {
                WaitingProcesses.Remove(myProcess);
                return myProcess;
            }

            //check for each process
            if (currentProcess.RemainingBurstTime < myProcess.RemainingBurstTime)
                return currentProcess;
            else
            {
                WaitingProcesses.Remove(myProcess);
                WaitingProcesses.Add(currentProcess);
                return myProcess;
            }
        }
    }
}
