using ElevatorApp.BLL;
using ElevatorApp.DTO;
using System;

namespace ElevatorApp
{
    public class Program
    {   
        static void Main(string[] args)
        {
            if (args != null && args.Length == 2)
            {
                Enum.TryParse(args[0], out Direction direction);
                int.TryParse(args[1], out var sourceFloor);
                
                new ElevatorController().DoElevatorJob(new Request(direction, sourceFloor));

                Console.ReadKey();
            }
        }
    }
}
