using ElevatorApp.DTO;

namespace ElevatorApp.BLL
{
    public interface IInsideRequestController
    {
        void SolveInsideRequest(Elevator selectedElevator, Request insideRequest);
        void SetDestination(string floorsOptions);
    }
}
