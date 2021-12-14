using System;
using System.Collections.Generic;

namespace ElevatorApp.DTO
{
    public class Building
    {
        public int NumberOfElevators { get; set; } = 2;
        public int NumberOfFloors { get; set; } = 10;
        public List<Elevator> Elevators { get; set; }
        
        public Building()
        {
            var random = new Random();
            Elevators = new List<Elevator>();

            int idx = 0;
            //Generate Elevators with random values for Direction/Floor/State
            while (Elevators.Count < NumberOfElevators)
            {
                var elevatorObj = new Elevator()
                {
                    Tag = $"Elevator[{Elevators.Count}]",
                    CurrentPosition = idx++ == 0 ? 1 : 10,
                    Direction = (Direction)random.Next(1, Enum.GetNames(typeof(Direction)).Length),
                    State = (State)random.Next(1, Enum.GetNames(typeof(State)).Length),
                    OutsideCommands = new List<int> { },
                    InsideCommands = new List<int> { }
                };
                Elevators.Add(elevatorObj);
                Console.WriteLine(elevatorObj);
            }
        }
    }
}
