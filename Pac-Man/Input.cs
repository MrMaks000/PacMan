//
// Input: This class is responsible for processing user input.
//

using System;

namespace Pac_Man
{
    public static class Input
    {
        static private Direction directionMove = new Direction();
        public static Direction ReadInput() //performs user input
        {           

            if (Console.KeyAvailable)
            {
                directionMove = KeyHandler(Console.ReadKey(true).Key);
            }

            return directionMove;
        }

        public static Direction KeyHandler(ConsoleKey key) //handles user input
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.DownArrow:
                    return Direction.Down;
            }
            return Direction.None;
        }
    }
}
