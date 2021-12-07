using ElevatorApp.DTO;

namespace ElevatorApp.BLL
{
    interface IElevatorController
    {
        void DoElevatorJob(Request outSideRequest);
        void ResetElevatorState(Elevator elevator);
    }
}
