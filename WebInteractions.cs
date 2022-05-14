using System;
using System.IO;
using System.Net;
using BasicSharp;
using System.Text;

namespace FTweb
{
    public class WebInteractions
    {
        public string pagestr;
        public void Get(string url)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(
              "https://"+url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            string responseFromServer;

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
            }

            // Close the response.
            response.Close();
            pagestr = responseFromServer;
            RunFT();
        }
        public void RunFT()
        {
            string code = pagestr;
            Interpreter basic = new Interpreter(code);
            basic.printHandler += Console.Write;
            basic.inputHandler += Console.ReadLine;
            basic.getHandler += this.Get;
            try
            {
                basic.Exec();
            }
            catch (BasicException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.line);
            }
        }
        
    }
}