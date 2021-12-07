using ElevatorApp.DTO;
using ElevatorApp.Exceptions;
using System;

namespace ElevatorApp.BLL
{
    /// <summary>
    /// Used for handle outside commands 
    /// Eg:When a person is outside the elevator and push button UP|DOWN
    /// </summary>
    public class OutsideRequestController : ElevatorFloorController, IOutsideRequestController
    {
        public Elevator Elevator;
        
        public void SolveOutsideRequest(Request outsideRequest, Building building)
        {
            CallTheCloseElevator(outsideRequest, building);
            Console.WriteLine($"Selected {Elevator.Tag}.. Waiting for it");

            if (Elevator.Floor != outsideRequest.SourceFloor)
                SolveElevatorRequest(Elevator, new Request(Elevator.Floor < outsideRequest.SourceFloor ? Direction.UP : Direction.DOWN,outsideRequest.SourceFloor));
        }

        public void CallTheCloseElevator(Request outsideRequest, Building building)
        {

            if (outsideRequest.SourceFloor > 10 || outsideRequest.SourceFloor < 0)
                throw new InvalidData(ExMessages.INVALID_SOURCE_FLOOR);

            if (outsideRequest.Direction != Direction.DOWN && outsideRequest.Direction != Direction.UP)
                throw new InvalidData(ExMessages.INVALID_DIRECTION);

            var elevatorA = building.Elevators[0];
            var elevatorB = building.Elevators[1];

            var distA = Math.Abs(outsideRequest.SourceFloor - elevatorA.Floor);
            var distB = Math.Abs(outsideRequest.SourceFloor - elevatorB.Floor);

            if (distA < distB)
                Elevator = elevatorA;
            else if (distA == distB)
            {
                if (elevatorA.Direction == outsideRequest.Direction)
                    Elevator = elevatorA;
                else if (elevatorB.Direction == outsideRequest.Direction)
                    Elevator = elevatorB;
                else
                    Elevator = elevatorA.Direction < elevatorB.Direction ? elevatorA : elevatorB;
            }
            else
                Elevator = elevatorB;
        }
    }
}
