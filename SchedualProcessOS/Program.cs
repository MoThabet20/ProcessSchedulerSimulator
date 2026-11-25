using System.IO;
using System.Collections.Generic;
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
            string newJson =JsonConvert.SerializeObject(lstprocesses);
            Console.ReadKey();
        }
    }
}
