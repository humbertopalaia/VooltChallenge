using VooltChallenge.Domain.Entities.Blocks;
using VooltChallenge.Infra.Repository;
using VooltChallenge.Service;
using VooltChallenge.Service.Interfaces;

namespace VooltChallenge.API.Extensions;

public static class DependencyInjectionExtension
{
    public static void AddDependencies(this IServiceCollection services)
    {
        AddServices(services);
        AddRepositories(services);
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddSingleton<IRepository<PartitionBlocks>, Repository<PartitionBlocks>>();
    }
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IPartitionBlocksService, PartitionBlocksService>();
    }
}
