using System.IO;
using System.Net;
using System.Text;

namespace HelloNordea
{

    class HelloFromAgent
    {
        static void Main(string[] args)
        {
            HttpWebRequest httpWebRequest22 = (HttpWebRequest)WebRequest.Create("https://test.direct.nordea.no/creditflow-agent/CFProxyWS");

            httpWebRequest22.Method = "POST";
            httpWebRequest22.ContentType = "application/xml";
            httpWebRequest22.Headers.Add("Authorization", "Basic " + Base64Encode("gbunofinans_a2a:D+AsH2DFr?#y+rdw"));
            
            string documentInput = System.IO.File.ReadAllText(@"request.xml");


            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest22.GetRequestStream(), Encoding.Default))
                streamWriter.Write(documentInput);

            HttpWebResponse response = (HttpWebResponse)httpWebRequest22.GetResponse();

            using(var reader = new StreamReader(response.GetResponseStream()))
                File.WriteAllText("out", reader.ReadToEnd());
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
