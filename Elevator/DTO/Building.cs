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

            //Generate Elevators with random values for Direction/Floor/State
            while (Elevators.Count < NumberOfElevators)
            {
                var elevatorObj = new Elevator()
                {
                    Tag = $"Elevator[{Elevators.Count}]",
                    Direction = (Direction)random.Next(1, Enum.GetNames(typeof(Direction)).Length),
                    Floor = random.Next(0, NumberOfFloors),
                    State = (State)random.Next(1, Enum.GetNames(typeof(State)).Length)
                };
                Elevators.Add(elevatorObj);
                Console.WriteLine(elevatorObj);
            }
        }
    }
}
