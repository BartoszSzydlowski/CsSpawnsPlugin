using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin.Handlers;
public interface ISpawnCommandHandler
{
	public Dictionary<int, Vector> TSpawnCoordinates { get; set; }
	public Dictionary<int, Vector> CTSpawnCoordinates { get; set; }

	void Handle(CCSPlayerController? player, CommandInfo command, ILogger logger);
}
