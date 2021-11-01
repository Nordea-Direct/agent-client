using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace HelloNordea
{

    class HelloFromAgent
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
        
            string uri = "https://test.direct.nordea.no/creditflow-agent/CFProxyWS";
            string documentInput = System.IO.File.ReadAllText(@"request.xml");

            var stringContent = new StringContent(documentInput);

            var response = await client.PostAsync(uri, stringContent);
            string content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
            File.WriteAllText("out", content);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
                
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
