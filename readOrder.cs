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
                string url = "https://api.zibal.ir/merchant/readOrder"; // url
                zibal.requesttype2 Request = new zibal.requesttype2(); // define Request
                Request.merchantId = "5a9988dcf92ea15d658232d4"; // String
                Request.secretKey = "EgSmgBsvoQgWsKDKsJfc"; // String
                Request.orderId = "1000"; // String
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
