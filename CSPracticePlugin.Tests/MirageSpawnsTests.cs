using CounterStrikeSharp.API.Modules.Utils;
using CSPracticePlugin.MapProvider.Providers;

namespace CSPracticePlugin.Tests;

[TestClass]
public class MirageSpawnsTests : BaseSpawnsTest<MirageSpawnsProvider>
{
	public override string MapName => "de_mirage";

	//[TestMethod]
	//public void Load_ShouldNotThrow()
	//{
	//	//Mock.Load(true);
	//}

	[DataRow(".spawn 1", CsTeam.Terrorist, 1216.00f, -115.00f, -160.95f)]
	[DataRow(".spawn 2", CsTeam.Terrorist, 1216.00f, -211.00f, -158.60f)]
	[DataRow(".spawn 3", CsTeam.Terrorist, 1136.00f, 32.000f, -158.78f)]
	[DataRow(".spawn 4", CsTeam.Terrorist, 1136.00f, -64.00f, -158.69f)]
	[DataRow(".spawn 5", CsTeam.Terrorist, 1136.00f, -256.00f, -158.83f)]
	[DataRow(".spawn 6", CsTeam.Terrorist, 1296.00f, 32.000f, -161.96f)]
	[DataRow(".spawn 7", CsTeam.Terrorist, 1216.00f, -307.04f, -158.81f)]
	[DataRow(".spawn 8", CsTeam.Terrorist, 1136.00f, -160.00f, -158.66f)]
	[DataRow(".spawn 9", CsTeam.Terrorist, 1296.00f, -352.00f, -161.96f)]
	[DataRow(".spawn 10", CsTeam.Terrorist, 1216.00f, -16.00f, -160.95f)]
	[DataRow(".spawn 1", CsTeam.CounterTerrorist, -1776.00f, -1976.00f, -260.06f)]
	[DataRow(".spawn 2", CsTeam.CounterTerrorist, -1656.00f, -1976.00f, -261.90f)]
	[DataRow(".spawn 3", CsTeam.CounterTerrorist, -1720.00f, -1896.00f, -262.12f)]
	[DataRow(".spawn 4", CsTeam.CounterTerrorist, -1656.00f, -1800.00f, -261.80f)]
	[DataRow(".spawn 5", CsTeam.CounterTerrorist, -1776.00f, -1800.00f, -260.18f)]
	[TestMethod]
	public void SpawnCommand_ShouldNotReturnNull_ShouldBeEqual(string spawn, CsTeam team, float x, float y, float z)
	{
		var result = Mock.CommandSpawn(spawn, MapName, team);

		var expected = new Vector(x, y, z).ToString();

		Assert.IsNotNull(result);
		Assert.AreEqual(expected, result.ToString());
	}

	[DataRow(".spawn 22", CsTeam.Terrorist)]
	[DataRow(".spawn ddddddd", CsTeam.Terrorist)]
	[DataRow(".spawn 22 123", CsTeam.Terrorist)]
	[TestMethod]
	public void SpawnCommand_ShouldReturnNull(string spawn, CsTeam team)
	{
		var result = Mock.CommandSpawn(spawn, MapName, team);
		Assert.IsNull(result);
	}
}