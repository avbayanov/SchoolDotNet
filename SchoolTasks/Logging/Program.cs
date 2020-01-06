using System;
using System.IO;
using NLog;

namespace Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.Info("Program launched");

            logger.Debug("Trying to read secrets");
            try
            {
                using (var reader = new StreamReader("secrets.txt"))
                {
                    var secrets = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }
    }
}
