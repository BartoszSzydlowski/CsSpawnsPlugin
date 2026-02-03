namespace CsSpawnsPlugin.Tests;

[TestClass]
public class PluginTest : BaseTest
{
    private MainMock Main = new MainMock();

    [TestMethod]
    public void TestMethod1()
    {
        Main.LoadMock(true);
    }
}

