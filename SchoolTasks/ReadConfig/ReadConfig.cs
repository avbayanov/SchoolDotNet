using System;
using System.Configuration;

namespace ReadConfig
{
    class ReadConfig
    {
        static void Main(string[] args)
        {
            string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];

            Console.WriteLine("SiteUrl: " + siteUrl);
        }
    }
}
