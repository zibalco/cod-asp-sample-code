using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace ZibalApiRequest
{
    public class zibal
    {
        public static HttpWebResponse HttpRequestToZibal(string url, string data)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url); // make request
            httpWebRequest.ContentType = "application/json; charset=utf-8"; // content of request -> must be JSON
            httpWebRequest.Method = "POST"; // method of request -> must be POST
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(data); // send request
                streamWriter.Flush(); // flush stream
            }
            return (HttpWebResponse)httpWebRequest.GetResponse(); // get Response
        }

        public class requesttype1
        {
            public string merchantId { get; set; }
            public string secretKey { get; set; }
            public string orderId { get; set; }
            public int amount { get; set; }
            public string callbackUrl { get; set; }
            public string description { get; set; }
            public int percentMode { get; set; }
            public int feeMode { get; set; }
            public List<Multi> multiplexingInfos { get; set; }
        }

        public class requesttype2
        {
            public string merchantId { get; set; }
            public string secretKey { get; set; }
            public string orderId { get; set; }
            public int zibalId { get; set; }
        }


        public class responsetype1
        {
            public string orderId { get; set; }
            public int result { get; set; }
            public string refNumber { get; set; }
            public string createdAt { get; set; }
            public string paidAt { get; set; }
            public int amount { get; set; }
            public int zibalFee { get; set; }
            public int status { get; set; }
            public int zibalId { get; set; }
            public string description { get; set; }
            public string canceledAt { get; set; }
            public string message { get; set; }
            public List<Multi> multiplexingInfos { get; set; }
        }

        public class responsetype2
        {
            public int zibalId { get; set; }
            public int zibalFee { get; set; }
            public int result { get; set; }
            public string message { get; set; }
        }

        public class Multi
        {
            public string id { get; set; }
            public int amount { get; set; }
        }
    }
}
