using Newtonsoft.Json;
using SchedualProcessOS.BL;
namespace SchedualProcessOS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //open the File to read data 
            string jsonContent = File.ReadAllText("processes.json");
            //convert from string to (object) - List<Processes> (Deserialization process)
            List<Processes> lstprocesses = JsonConvert.DeserializeObject<List<Processes>>(jsonContent);
            // convert object to string file (Serialization process)
            //string newJson =JsonConvert.SerializeObject(lstprocesses);

            ISchedualProcess processAlgorithm = new ShortestProcess(lstprocesses);
            //declare the firstprocess to be currentProcess
            Processes cureentProcess = processAlgorithm.IncomingProcesses();
            int nTimeLineIndex = 0;
            while (cureentProcess!=null)
            {
                if(processAlgorithm.MainProcesses==null)
                {
                    if (processAlgorithm.MainProcesses.Count >processAlgorithm.EndedProcesses.Count)
                    {
                        Console.WriteLine("Ideal state process empty");
                        continue;
                    }
                    else
                        break;
                }

                Console.WriteLine($"Process Name {cureentProcess.processName} , " +
                    $"Remaining BurstTime {cureentProcess.RemainingBurstTime}");
                cureentProcess.RemainingBurstTime--;
                if (cureentProcess.RemainingBurstTime == 0)
                {
                    processAlgorithm.EndedProcesses.Add(cureentProcess);
                    if (processAlgorithm.WaitingProcesses.Count > 0)
                        cureentProcess = processAlgorithm.IncomingQueue(cureentProcess);
                    else
                        cureentProcess = null;
                }

                nTimeLineIndex++;
                cureentProcess = processAlgorithm.IncomingProcesses(cureentProcess, nTimeLineIndex);
                if (processAlgorithm.WaitingProcesses.Count > 0)
                {
                    cureentProcess = processAlgorithm.IncomingQueue(cureentProcess);
                }
            }
            Console.WriteLine("=====================================================");
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
