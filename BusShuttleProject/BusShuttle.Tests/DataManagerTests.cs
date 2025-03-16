namespace BusShuttle.Tests;

using BusShuttle;

public class DataManagerTests {
    DataManager dataManager;

    public DataManagerTests() {
        File.WriteAllText("stops.txt", "One" + Environment.NewLine + "Two" + Environment.NewLine + "Three" + Environment.NewLine + "Four" + Environment.NewLine + "Five" + Environment.NewLine);
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddStop() {
        Assert.Equal(5, dataManager.Stops.Count);
        dataManager.AddStop(new Stop("new stop"));
        Assert.Equal(6, dataManager.Stops.Count);
    }
}