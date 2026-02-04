using CounterStrikeSharp.API.Modules.Utils;
using CsSpawnsPlugin.MapProvider;

namespace CsSpawnsPlugin.Tests;

[TestClass]
public class MirageCtSpawnsTests : BaseSpawnsTest<MirageCtSpawnsProvider>
{
	[TestMethod]
	public void Load_ShouldNotThrow()
	{
		Mock.Load();
	}

	[DataRow(".spawn 2", "de_mirage", CsTeam.CounterTerrorist)]
	[TestMethod]
	public void SpawnCommand_ShouldNotThrow(string spawn, string mapName, CsTeam team)
	{
		Mock.Load();
		var result = Mock.CommandSpawn(spawn, mapName, team);

		var expected = new Vector(1216.00f, -211.00f, -158.60f).ToString();

		Assert.IsNotNull(result);
		Assert.AreEqual(expected, result.ToString());
	}

	[DataRow(".spawn 22", "de_mirage", CsTeam.CounterTerrorist)]
	[TestMethod]
	public void SpawnCommand_ShouldReturnNull(string spawn, string mapName, CsTeam team)
	{
		Mock.Load();
		var result = Mock.CommandSpawn(spawn, mapName, team);

		Assert.IsNull(result);
	}
}
