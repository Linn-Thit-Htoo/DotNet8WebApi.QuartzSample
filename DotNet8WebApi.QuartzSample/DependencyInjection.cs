using Quartz;

namespace DotNet8WebApi.QuartzSample
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddQuartz(opt =>
            {
                var jobKey = JobKey.Create(nameof(SampleBackgroundJob));

                opt.AddJob<SampleBackgroundJob>(jobKey)
                    .AddTrigger(opt =>
                        opt.ForJob(jobKey)
                            .WithSimpleSchedule(opt => opt.WithIntervalInSeconds(5).RepeatForever())
                    );
            });

            services.AddQuartzHostedService(opt =>
            {
                opt.WaitForJobsToComplete = true;
            });

            return services;
        }
    }
}
