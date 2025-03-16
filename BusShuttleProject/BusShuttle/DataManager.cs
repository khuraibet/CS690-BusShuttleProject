namespace BusShuttle;

public class DataManager {
    FileSaver fileSaver;
    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> PassengerData { get; }

    public DataManager() {
        fileSaver = new FileSaver("passenger-data.txt");

        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));

        Stops = new List<Stop>();
        var stopsFileContent = File.ReadAllLines("stops.txt");
        
        foreach(var stopName in stopsFileContent) {
            Stops.Add(new Stop(stopName));
        }

        Loops[0].Stops.Add(Stops[0]);
        Loops[0].Stops.Add(Stops[1]);
        Loops[0].Stops.Add(Stops[2]);
        Loops[0].Stops.Add(Stops[3]);
        Loops[0].Stops.Add(Stops[4]);

        Drivers = new List<Driver>();
        Drivers.Add(new Driver("Michael Khuraibet"));
        Drivers.Add(new Driver("Heather Khuraibet"));

        PassengerData = new List<PassengerData>();
    }

    public void AddNewPassengerData(PassengerData data) {
        this.PassengerData.Add(data);
        this.fileSaver.AppendData(data);
    }

    public void SynchronizeStops() {
        File.Delete("stops.txt");

        foreach(var stop in Stops) {
            File.AppendAllText("stops.txt", stop.Name + Environment.NewLine);
        }
    }

    public void AddStop(Stop stop) {
        Stops.Add(stop);
        SynchronizeStops();
    }
    public void RemoveStop(Stop stop) {
        Stops.Remove(stop);
        SynchronizeStops();
    }
}