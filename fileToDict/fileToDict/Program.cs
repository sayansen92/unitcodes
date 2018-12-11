using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileToDict
{
    class Program
    {
        private static Dictionary<byte, string> unitsDict = new Dictionary<byte, string>();
        private static Dictionary<byte, string> labelsDict = new Dictionary<byte, string>();

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"units.txt");
            foreach (string line in lines)
            {
             
                unitsDict.Add(Convert.ToByte(line.Split(',')[0], 16), line.Split(',')[1]);
               
            }
            foreach (KeyValuePair<byte, string> unit in unitsDict)
            {
                Console.WriteLine(unit.Key+","+ unit.Value);
            }
            Console.WriteLine("----------------------------------------");
            lines = System.IO.File.ReadAllLines(@"labels.txt");
            foreach (string line in lines)
            {

                labelsDict.Add(Convert.ToByte(line.Split(',')[0], 16), line.Split(',')[1]);

            }
            foreach (KeyValuePair<byte, string> unit in labelsDict)
            {
                Console.WriteLine(unit.Key + "," + unit.Value);
            }

            Console.Read();
        }
    }
}
