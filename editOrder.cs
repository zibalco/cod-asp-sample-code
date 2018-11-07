using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace ZibalApiRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "https://api.zibal.ir/merchant/editOrder"; // url
                zibal.requesttype1 Request = new zibal.requesttype1(); // define Request
                Request.merchantId = "5a9988dcf92ea15d658232d4"; // String
                Request.secretKey = "EgSmgBsvoQgWsKDKsJfc"; // String
                Request.orderId = "1000"; // String
                Request.amount = 100000; //Integer
                Request.callbackUrl = "http://callback.com/api"; //String
                Request.description = "Haj mehdi"; // String
                Request.percentMode = 0; // 0 or 1
                Request.feeMode = 0; // 0 or 1
                Request.multiplexingInfos = new List<zibal.Multi>(){new zibal.Multi{ id = "self", amount = 50000 },new zibal.Multi{ id = "LK4pF7", amount = 50000 }}; // Multiplexing between 2 bank acount 
                var httpResponse = zibal.HttpRequestToZibal(url, JsonConvert.SerializeObject(Request));  // get Response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) // make stream reader
                {
                    var responseText = streamReader.ReadToEnd(); // read Response
                    zibal.responsetype2 item = JsonConvert.DeserializeObject<zibal.responsetype2>(responseText); // Deserilize as response class object
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message); // print exception error
            }
        }
    }


}
