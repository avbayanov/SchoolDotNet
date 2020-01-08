using System;
using Quartz;

namespace Job
{
    public class PrintJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello world!");
        }
    }
}