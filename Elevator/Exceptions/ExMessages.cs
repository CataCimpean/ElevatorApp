namespace ElevatorApp.Exceptions
{
    public static class ExMessages
    {
        public const string SELECT_ANOTHER_FLOOR = "You are here.Please select different floor!";
        public const string OUT_OF_BOUND_FLOOR_NO = "Invalid total floors. The floors number should be 10 !";
        public const string INVALID_FLOOR_NO = "Invalid floor no.Number should be between 1 && 10!";
        public const string INVALID_SOURCE_FLOOR = "Invalid source floor.Number should be between 1 && 10!";
        public const string INVALID_DIRECTION = "Invalid direction. Should be 1 = (UP) | 2 = (DOWN)";
    }
}
