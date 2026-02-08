using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;

namespace CsSpawnsPlugin.Handlers;
public interface ISpawnCommandHandler
{
	Dictionary<int, Vector> TSpawnCoordinates { get; set; }
	Dictionary<int, Vector> CTSpawnCoordinates { get; set; }
	string MapName { get; set; }

	void Handle(CCSPlayerController? player, CommandInfo command, ILogger logger);
}
