using ElevatorApp.DTO;
using System;
using System.Threading;

namespace ElevatorApp.BLL
{
    public abstract class ElevatorFloorController
    {
        private TimeSpan _secondsBetweenFloors;

        public ElevatorFloorController()
        {
            _secondsBetweenFloors = new TimeSpan(0, 0, 0, 1);
        }

        public void SolveElevatorRequest(Elevator selectedElevator, Request request)
        {
            do
            {
                var nextFloor = request.Direction == Direction.UP
                                ? ++selectedElevator.Floor
                                : --selectedElevator.Floor;

                Console.WriteLine($"Go to next floor -> {nextFloor}");
                selectedElevator.State = State.MOVING;

                Thread.Sleep(_secondsBetweenFloors);
                selectedElevator.State = State.STOPPED;

            } while (selectedElevator.Floor != request.SourceFloor);
        }
    }
}
