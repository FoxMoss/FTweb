using System;
using System.IO;
using System.Net;
using BasicSharp;

namespace FTweb
{
    public class WebInteractions
    {
        public static string Get(string url)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(
              url);
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

            return responseFromServer;
        }
        public static void RunFT(string fwFile)
        {
            string code = fwFile;
            Interpreter basic = new Interpreter(code);
            basic.printHandler += Console.WriteLine;
            basic.inputHandler += Console.ReadLine;
            basic.getHandler += Get;
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