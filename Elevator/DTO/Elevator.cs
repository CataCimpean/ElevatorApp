using System;

namespace ElevatorApp.DTO
{
    public class Elevator
    {
        public string Tag { get; set; }
        public int Floor { get; set; }
        public Direction Direction { get; set; }
        public State State { get; set; }
        public override string ToString() => $"Initialized: {Tag}. Floor: {Floor}. Direction: {Enum.GetName(typeof(Direction), Direction)}. State:{Enum.GetName(typeof(State), State)}";
    }

    public enum State
    {
        MOVING = 1,
        STOPPED = 2,
        IDLE = 3
    }

    public enum Direction
    {
        UP = 1,
        DOWN = 2
    }
}
