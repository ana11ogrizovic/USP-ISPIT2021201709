using Mentor.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

public class NotifyMentorsWorker : BackgroundService
{
    private readonly MongoDbService _mongoDbService;

    public NotifyMentorsWorker(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Worker je pokrenut."); // Dodaj ovo za dijagnostiku

        while (!stoppingToken.IsCancellationRequested)
        {
            await DoWorkAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }


    private async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        try
        {
            Console.WriteLine("Pokreće se rad sa mentorima...");

            var mentors = await _mongoDbService.Mentors.Find(_ => true).ToListAsync(stoppingToken);
        
            Console.WriteLine($"Pronađeno mentora: {mentors.Count}"); // Dodaj ovo za dijagnostiku

            foreach (var mentor in mentors)
            {
                Console.WriteLine($"Mentor: {mentor.FirstName} {mentor.LastName}");
            }

            Console.WriteLine("Rad sa mentorima završen.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Greška u workeru: {ex.Message}");
        }
    }


}