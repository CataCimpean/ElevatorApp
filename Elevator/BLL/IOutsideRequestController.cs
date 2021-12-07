using ElevatorApp.DTO;

namespace ElevatorApp.BLL
{
    interface IOutsideRequestController
    {
        void CallTheCloseElevator(Request outSideRequest, Building building);
        void SolveOutsideRequest(Request insideRequest, Building building);
    }
}
