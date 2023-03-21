using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ContactWindowsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:9091");
            config.Routes.MapHttpRoute(
                name: "API",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional}
                
                );
            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}