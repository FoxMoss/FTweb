using System;
using System.IO;
using System.Text;

namespace FTweb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            WebInteractions browser = new WebInteractions();

            browser.Get("mediaology.com/testing/index.fw");
            while (true)
            {
                Console.Write("Page Ended; Where Next?: ");
                string holdRead = Console.ReadLine();
                if (holdRead != "")
                {
                    browser.Get(holdRead);
                }else
                {
                    return;
                }
                Console.Clear();
            }
        }
    }
}
