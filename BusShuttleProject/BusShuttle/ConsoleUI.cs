namespace BusShuttle;

using Spectre.Console;
public class ConsoleUI {
    FileSaver fileSaver;

    public ConsoleUI() {
        fileSaver = new FileSaver("passenger-data.txt");
    }

    public void Show() {

        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    "driver", "manager"
            }));

        if(mode == "driver") {

            string command;

            do {
                string stopName = AskForInput("Enter stop name: ");

                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                fileSaver.AppendLine(stopName + ": " + boarded);
                
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