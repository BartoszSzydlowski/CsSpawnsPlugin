using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Services;

public sealed class SpawnsService : ISpawnsService
{
    private readonly IMapResolver _mapResolver;
    private readonly IBaseSpawnsProvider _baseSpawnsProvider;

    public string MapName { get; private set; }

    public SpawnsService(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
    {
        _mapResolver = mapResolver ?? throw new ArgumentNullException(nameof(mapResolver));
        _baseSpawnsProvider = baseSpawnsProvider ?? throw new ArgumentNullException(nameof(baseSpawnsProvider));
        MapName = _baseSpawnsProvider.MapName;
    }

    public IBaseSpawnsProvider ResolveMap(string? mapName = null)
    {
        var name = mapName ?? MapName;
        return _mapResolver.Resolve(name);
    }

    // Example extracted logic for the spawn command (pure logic only)
    public (bool ok, string message) ValidateSpawnArgs(string[] args)
    {
        if (args is null || args.Length < 1)
            return (false, "Usage: .spawn <number>");
        // additional validation can go here
        return (true, string.Empty);
    }
}