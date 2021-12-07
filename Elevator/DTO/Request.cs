namespace ElevatorApp.DTO
{
    public class Request
    {
        public Direction Direction { get; set; }
        public int SourceFloor { get; set; }

        public Request(Direction direction, int sourceFloor)
        {
            Direction = direction;
            SourceFloor = sourceFloor;
        }
    }
}
