using Microsoft.Extensions.Hosting;
using Serilog;

namespace RecipeBook.Repository.Services;

public class SeederService : IHostedService
{
    private readonly IRepositoryManager _repoManager;
    private readonly ILogger? _logger;

    public SeederService(IRepositoryManager categoryRepo,
        ILogger? logger)
    {
        _logger = logger?.ForContext<SeederService>();
        _repoManager = categoryRepo;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger?.Information("Start seeding categories...");
        await _repoManager.CategoryRepository.InitCategories();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}