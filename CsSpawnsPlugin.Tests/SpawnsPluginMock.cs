using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;
using CsSpawnsPlugin.Resolvers;

namespace CsSpawnsPlugin.Tests;

public class SpawnsPluginMock(IMapResolver mapResolver, IBaseSpawnsProvider baseSpawnsProvider)
{
	public static string ModuleName => "Main";

	public static string ModuleVersion => "1.0";

	public string MapName { get; set; } = string.Empty;
	private Dictionary<int, Vector> tSpawnCoordinates = [];
	private Dictionary<int, Vector> ctSpawnCoordinates = [];

	public void Load(bool hotReload)
	{
		InitMapSpawns(MapName);
		Console.WriteLine("Plugin loaded successfully!");
	}

	public Vector? CommandSpawn(string command, string mapName, CsTeam team)
	{
		//var selectedSpawn = Convert.ToInt32(command.Split(' ')[1]);
		//return mapResolver?.GetSpawn(mapName, team, selectedSpawn);
		return null;
	}

	private Vector? GetSpawnVector(CsTeam team, int selectedSpawn)
	{
		Vector? vector;
		if (team == CsTeam.Terrorist)
			vector = GetSpawnCoordinates(selectedSpawn, tSpawnCoordinates);
		else if (team == CsTeam.Terrorist)
			vector = GetSpawnCoordinates(selectedSpawn, ctSpawnCoordinates);
		else
			vector = null;
		return vector;
	}

	private Vector? GetSpawnCoordinates(int selectedSpawn, Dictionary<int, Vector> spawns)
	{
		if (!spawns.TryGetValue(selectedSpawn, out var vector))
			return null;

		return vector;
	}

	private void InitMapSpawns(string mapName)
	{
		var mapSpawns = mapResolver.Resolve(mapName);
		tSpawnCoordinates = mapSpawns.TSpawnCoordinates;
		ctSpawnCoordinates = mapSpawns.CTSpawnCoordinates;
	}

	private int GetSpawnInserted(string command)
	{
		var spawnFromCommand = command.Split(' ')[1];

		if (!int.TryParse(spawnFromCommand, out int spawnPosition))
		{
			Console.WriteLine("Usage: .spawn <number>");
			return 0;
		}

		return spawnPosition;
	}

	private bool CheckCommandArgCount(string command)
	{
		if (command.Split(' ').Length != 2)
		{
			Console.WriteLine("Usage: .spawn <number>");
			return false;
		}
		return true;
	}
}
