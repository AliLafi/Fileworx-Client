using FileworxObjects;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects.Contact;
using WorkerService1.Utilities;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ApiRequests apiRequests = new();

            while (!stoppingToken.IsCancellationRequested)
            {
                List<Contact> receiveContacts = await apiRequests.GetAll<Contact>("Contacts/receive");
                foreach (Contact contact in receiveContacts)
                {
                    await Reception.CheckAndSaveNew(apiRequests, contact);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}