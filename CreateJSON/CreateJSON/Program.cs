using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CreateJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            DeviceDataConfig.deviceData = args[0];
            Console.WriteLine("Starts here...........");
            publishData("Active", 900, 2000, DateTime.Now.ToString());
            Console.WriteLine("Press key to stop.");
            Console.Read();
        }
        public static void publishData(string status, int rate, int vtbi, string timestamp)
        {
            System.Collections.Generic.Dictionary<string, double[]> myDictionary = new Dictionary<string, double[]>();
            string deviceData = DeviceDataConfig.deviceData;

            Dictionary<string, object> sd1 = new Dictionary<string, object>();
            sd1.Add("Original Name", "VTBI");
            sd1.Add("CMName", "vtbi");
            sd1.Add("Value", vtbi);
            Dictionary<string, object> sd2 = new Dictionary<string, object>();
            sd2.Add("Original Name", "Rate");
            sd2.Add("CMName", "rate");
            sd2.Add("Value", rate);
            Dictionary<string, object> sd3 = new Dictionary<string, object>();
            sd3.Add("Original Name", "Status");
            sd3.Add("CMName", "status");
            sd3.Add("Value", status);


            var myJsonString1 = (new JavaScriptSerializer()).Serialize(sd1);//{"Original Name":"VTBI","CMName":"vtbi","Value":0}
            var myJsonString2 = (new JavaScriptSerializer()).Serialize(sd2);
            var myJsonString3 = (new JavaScriptSerializer()).Serialize(sd3);
            var javaScriptSerializer = new JavaScriptSerializer();

           

            object D1 = javaScriptSerializer.DeserializeObject(myJsonString1);
            object D2 = javaScriptSerializer.DeserializeObject(myJsonString2);
            object D3 = javaScriptSerializer.DeserializeObject(myJsonString3);

            object[] ob = { D1, D2, D3};
            string publishingJson = JsonConvert.SerializeObject(new MessageStructure { captureTime = timestamp, Data = ob, deviceData = javaScriptSerializer.DeserializeObject(deviceData) });

            Console.WriteLine(publishingJson);

        }

    }
}
