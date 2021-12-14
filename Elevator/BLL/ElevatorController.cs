using ElevatorApp.DTO;
using ElevatorApp.Exceptions;
using System;

namespace ElevatorApp.BLL
{
    public class ElevatorController : IElevatorController
    {
        private int _selectedFloor;
        private Elevator _selectedElevator;
        private Building _building;
        private OutsideRequestController _outsideRequestController;
        private InsideRequestController _insideRequestController;

        public ElevatorController()
        {
            _outsideRequestController = new OutsideRequestController();
            _building = new Building();
        }

        public void DoElevatorJob(Request outSideRequest)
        {
            try
            {
                if (_building.NumberOfFloors != 10)
                    throw new InvalidData(ExMessages.OUT_OF_BOUND_FLOOR_NO);

                //Processing outside command
                _outsideRequestController.SolveOutsideRequest(outSideRequest, _building);

                //Processing inside command
                _selectedElevator = _outsideRequestController.Elevator;
                _insideRequestController = new InsideRequestController();
                _insideRequestController.SolveInsideRequest(_selectedElevator, new Request(_selectedElevator.CurrentPosition < _selectedFloor ? Direction.UP : Direction.DOWN, _selectedFloor));
                
                //Reset elevator state
                ResetElevatorState(_selectedElevator);

            }
            catch (InvalidData dataException)
            {
                Console.WriteLine($"InvalidDataException:{dataException.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception:{exception.Message}");
            }
        }

        public void ResetElevatorState(Elevator elevator) => elevator.State = State.IDLE;
    }
}
