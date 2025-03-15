namespace BusShuttle;
public class ConsoleUI {
    FileSaver fileSaver;

    public ConsoleUI() {
        fileSaver = new FileSaver("passenger-data.txt");
    }

    public void Show() {
        string mode = AskForInput("Please select mode (driver OR manager): ");

        if(mode == "driver") {

            string command;

            do {
                string stopName = AskForInput("Enter stop name: ");

                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                fileSaver.AppendLine(stopName + ": " + boarded);
                
                command = AskForInput("Enter command (end OR continue): ");

            } while(command != "end");
        }
    }

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }
}