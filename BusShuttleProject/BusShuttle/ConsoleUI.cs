namespace BusShuttle;

using Spectre.Console;
public class ConsoleUI {
    FileSaver fileSaver;

    List<Loop> loops;
    List<Stop> stops;
    List<Driver> drivers;

    public ConsoleUI() {
        fileSaver = new FileSaver("passenger-data.txt");

        loops = new List<Loop>();
        loops.Add(new Loop("Red"));
        loops.Add(new Loop("Green"));
        loops.Add(new Loop("Blue"));

        stops = new List<Stop>();
        stops.Add(new Stop("Music"));
        stops.Add(new Stop("Tower"));
        stops.Add(new Stop("Oakwood"));
        stops.Add(new Stop("Anthony"));
        stops.Add(new Stop("Letterman"));

        loops[0].Stops.Add(stops[0]);
        loops[0].Stops.Add(stops[1]);
        loops[0].Stops.Add(stops[2]);
        loops[0].Stops.Add(stops[3]);
        loops[0].Stops.Add(stops[4]);

        drivers = new List<Driver>();
        drivers.Add(new Driver("Michael Khuraibet"));
        drivers.Add(new Driver("Heather Khuraibet"));
    }

    public void Show() {

        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    "driver", "manager"
            }));

        if(mode == "driver") {

            Driver selectedDriver = AnsiConsole.Prompt(
                new SelectionPrompt<Driver>()
                    .Title("Please select a driver")
                    .AddChoices(drivers));
            Console.WriteLine("Hello, " + selectedDriver.Name);

            Loop selectedLoop = AnsiConsole.Prompt(
                new SelectionPrompt<Loop>()
                    .Title("Please select a loop")
                    .AddChoices(loops));
            Console.WriteLine("You selected " + selectedLoop.Name + " loop");

            string command;

            do {
                Stop selectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                        .Title("Please select a stop")
                        .AddChoices(selectedLoop.Stops));
                Console.WriteLine("You selected " + selectedStop.Name + " stop");

                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);

                fileSaver.AppendData(data);
                
                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] {
                            "continue", "end"
                    }));

            } while(command != "end");
        }
    }

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }
}