using ElevatorApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ElevatorApp.BLL
{
    public abstract class ElevatorFloorController
    {
        private TimeSpan _secondsBetweenFloors;
        private List<int> _commands;

        public ElevatorFloorController()
        {
            _secondsBetweenFloors = new TimeSpan(0, 0, 0, 1);
        }

        public void SolveElevatorRequest(Elevator selectedElevator, Request request, bool outsideCommand = false)
        {

            if (outsideCommand)
                _commands = selectedElevator.OutsideCommands;
            else
                _commands = selectedElevator.InsideCommands;

            do
            {
                var nextFloor = request.SourceFloor <= selectedElevator.CurrentPosition
                                ? --selectedElevator.CurrentPosition
                                : ++selectedElevator.CurrentPosition;

                Console.WriteLine($"Go to next floor -> {nextFloor}");
                selectedElevator.State = State.MOVING;

                Thread.Sleep(_secondsBetweenFloors);
                selectedElevator.State = State.STOPPED;

                var currentFloor = nextFloor;
                var commandAtThisFloor = _commands.Count(c => c == currentFloor);

                if (commandAtThisFloor > 0)
                {
                    Console.WriteLine($"Open door at floor : {currentFloor}");
                    _commands = _commands.Where(c => c != currentFloor).ToList();
                }


            } while (_commands.Count > 0);

            ResetElevatorCommands(ref selectedElevator, outsideCommand);
        }

        public void AddNewCommand(ref Elevator elevator, int floorNumber, bool outsideCommand = false) 
        {
            if (outsideCommand)
                elevator.OutsideCommands.Add(floorNumber);
            else
                elevator.InsideCommands.Add(floorNumber);
        } 

        private void ResetElevatorCommands(ref Elevator elevator, bool outsideCommand = false)
        {
            if (outsideCommand)
                elevator.OutsideCommands = new List<int>();
            else
                elevator.InsideCommands = new List<int>();
        }
    }
}
