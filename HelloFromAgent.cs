using System;

namespace HelloNordea{

    class HelloFromAgent { 
        static void Main(string [] args) {
            HttpWebRequest httpWebRequest22 = (HttpWebRequest)WebRequest.Create(url);

            // httpWebRequest22.Timeout = 600000;
            httpWebRequest22.Method = "POST";
            httpWebRequest22.ContentType = "application/xml";
            httpWebRequest22.Headers.Add("Authorization", "Basic " + Base64Encode($"{userName}:{password}"));

            //X509Certificate2Collection certificates = new X509Certificate2Collection();
            //certificates.Import(cert, certPWd, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);

            //httpWebRequest22.ClientCertificates = certificates;

            NordeaProxy.ProcessExecuteAsync documentIn = new NordeaProxy.ProcessExecuteAsync();

            documentIn.documentInput = CreateApplication(objSak, objSoknad, userName, password, true);

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest22.GetRequestStream(), Encoding.Default))
                streamWriter.Write(documentIn.documentInput);

            HttpWebResponse response = (HttpWebResponse)httpWebRequest22.GetResponse();
        }
    }
}
