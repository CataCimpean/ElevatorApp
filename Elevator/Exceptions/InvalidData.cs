using System;
namespace ElevatorApp.Exceptions
{
    public class InvalidData : Exception
    {
        public InvalidData(string message)
            : base(message)
        {

        }
    }
}
