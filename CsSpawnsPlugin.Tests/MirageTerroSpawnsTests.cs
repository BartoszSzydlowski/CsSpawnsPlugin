using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class MirageTerroSpawnsTests : BaseSpawnsTest<MirageSpawnsProvider>
{
	[TestMethod]
	public void Load_ShouldNotThrow()
	{
		Mock.Load();
	}

	[DataRow(".spawn 1", "de_mirage", CsTeam.Terrorist, 1216.00f, -115.00f, -160.95f)]
	//[DataRow(".spawn 2", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 3", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 4", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 5", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 6", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 7", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 8", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 9", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	//[DataRow(".spawn 10", "de_mirage", CsTeam.Terrorist, 0f, 0f, 0f)]
	[TestMethod]
	public void SpawnCommand_ShouldNotThrow(string spawn, string mapName, CsTeam team, float x, float y, float z)
	{
		Mock.Load();
		var result = Mock.CommandSpawn(spawn, mapName, team);

		var expected = new Vector(x, y, z).ToString();

		Assert.IsNotNull(result);
		Assert.AreEqual(expected, result.ToString());
	}

	[DataRow(".spawn 22", "de_mirage", CsTeam.Terrorist)]
	[TestMethod]
	public void SpawnCommand_ShouldReturnNull(string spawn, string mapName, CsTeam team)
	{
		Mock.Load();
		var result = Mock.CommandSpawn(spawn, mapName, team);
		Assert.IsNull(result);
	}
}

