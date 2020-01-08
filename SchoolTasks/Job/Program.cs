using Quartz;
using Topshelf;
using Topshelf.Ninject;
using Topshelf.Quartz;
using Topshelf.Quartz.Ninject;

namespace Job
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                c.UseNinject(new JobModule());
                
                c.UseQuartzNinject();

                c.ScheduleQuartzJobAsService(q =>
                    q.WithJob(() =>
                            JobBuilder.Create<PrintJob>().Build())
                        .AddTrigger(() =>
                            TriggerBuilder.Create()
                                .WithSimpleSchedule(builder => builder
                                    .WithIntervalInSeconds(3)
                                    .RepeatForever())
                                .Build())
                );
            });

        }
    }
}
