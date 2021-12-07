using ElevatorApp.DTO;
using ElevatorApp.Exceptions;
using System;
using System.Linq;

namespace ElevatorApp.BLL
{
    /// <summary>
    /// Used for handle inside commands 
    /// Eg:When a person is inside an elevator and select a specific destination floor
    /// </summary>
    public class InsideRequestController : ElevatorFloorController, IInsideRequestController
    {
        private int _selectedFloor;

        public void SolveInsideRequest(Elevator selectedElevator, Request insideRequest)
        {
            int[] floors = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var floorsOptions = string.Join(",", floors.Where(val => val != selectedElevator.Floor).ToArray());
            var iteration = 0;
            
            do
            {
                if(++iteration > 1)
                    Console.WriteLine(ExMessages.SELECT_ANOTHER_FLOOR);

                SetDestination(floorsOptions);

            } while (_selectedFloor == selectedElevator.Floor);

            SolveElevatorRequest(selectedElevator, new Request(selectedElevator.Direction, _selectedFloor));

            Console.WriteLine("Have a nice day !");
        }

        public void SetDestination(string floorsOptions)
        {
            Console.WriteLine($"Please tap the floor number [{floorsOptions}]....");

            if (!int.TryParse(Console.ReadLine(), out _selectedFloor))
                throw new InvalidData(ExMessages.INVALID_FLOOR_NO);
        }
    }
}
