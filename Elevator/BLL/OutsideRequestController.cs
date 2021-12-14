using ElevatorApp.DTO;
using ElevatorApp.Exceptions;
using System;
using System.Linq;

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

            AddNewCommand(ref Elevator, outsideRequest.SourceFloor, true);

            Console.WriteLine($"Selected {Elevator.Tag}.. Waiting for it");

            Elevator.OutsideCommands = Elevator.Direction == Direction.UP ?
                                       Elevator.OutsideCommands.OrderBy(c => c).ToList() :
                                       Elevator.OutsideCommands.OrderByDescending(c => c).ToList();

            if (Elevator.CurrentPosition != outsideRequest.SourceFloor)
                SolveElevatorRequest(selectedElevator: Elevator,
                                     request: new Request(Elevator.CurrentPosition < outsideRequest.SourceFloor ? Direction.UP : Direction.DOWN, outsideRequest.SourceFloor),
                                     outsideCommand: true);
        }

        public void CallTheCloseElevator(Request outsideRequest, Building building)
        {

            if (outsideRequest.SourceFloor > 10 || outsideRequest.SourceFloor < 0)
                throw new InvalidData(ExMessages.INVALID_SOURCE_FLOOR);

            if (outsideRequest.Direction != Direction.DOWN && outsideRequest.Direction != Direction.UP)
                throw new InvalidData(ExMessages.INVALID_DIRECTION);

            var elevatorA = building.Elevators[0];
            var elevatorB = building.Elevators[1];


            var requestDirection = outsideRequest.Direction;
            var elevatorADirection = elevatorA.Direction;
            var elevatorBDirection = elevatorB.Direction;

            Elevator = elevatorA;

            if ((elevatorADirection == requestDirection)
                && (((elevatorA.Direction == Direction.DOWN && elevatorA.CurrentPosition >= outsideRequest.SourceFloor)
                    || (elevatorA.Direction == Direction.UP && elevatorA.CurrentPosition <= outsideRequest.SourceFloor))))

                Elevator = elevatorA;

            else if ((elevatorBDirection == requestDirection)
                && ((elevatorB.Direction == Direction.DOWN && elevatorB.CurrentPosition >= outsideRequest.SourceFloor)
                    || (elevatorB.Direction == Direction.UP && elevatorB.CurrentPosition <= outsideRequest.SourceFloor)))

                Elevator = elevatorB;
        }
    }
}
