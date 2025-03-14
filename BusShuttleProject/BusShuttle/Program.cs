namespace BusShuttle;

using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please select mode (driver OR manager): ");
        string mode = Console.ReadLine();

        if(mode == "driver") {

            string command;

            do {
            Console.Write("Enter stop name: ");
            string stopName = Console.ReadLine();

            Console.Write("Enter number of boarded passengers: ");
            int boarded = int.Parse(Console.ReadLine());

            File.AppendAllText("passenger-data.txt", stopName + ": " + boarded + Environment.NewLine);
            
            Console.Write("Enter command (end OR continue): ");
            command = Console.ReadLine();

            } while(command != "end");
        }
    }
}
