using Quartz;

namespace DotNet8WebApi.QuartzSample
{
    public class SampleBackgroundJob : IJob
    {
        private readonly ILogger<SampleBackgroundJob> _logger;

        public SampleBackgroundJob(ILogger<SampleBackgroundJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello world!");
            return Task.CompletedTask;
        }
    }
}
