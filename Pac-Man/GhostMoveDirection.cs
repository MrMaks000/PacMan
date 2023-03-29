//
// GhostMoveDirection: this class is responsible for determining the direction of movement of the ghost.
//

using System;
using System.Collections.Generic;

namespace Pac_Man
{
    static class GhostMoveDirection
    {
        static public Direction RandomDirection(List<Direction> availableDirection, Direction moveDirection) // this class is responsible for choosing a random possible direction
        {
            Direction direction = Direction.None;
            Random randomDirection = new Random(DateTime.Now.Millisecond);
            bool flag = false;

            if (availableDirection.Count != 0)
            {
                direction = availableDirection[randomDirection.Next(0, availableDirection.Count)];
            }

            switch (direction)
            {
                case Direction.Left:
                    if (moveDirection == Direction.Right) flag = true;
                    break;
                case Direction.Right:
                    if (moveDirection == Direction.Left) flag = true;
                    break;
                case Direction.Up:
                    if (moveDirection == Direction.Down) flag = true;
                    break;
                case Direction.Down:
                    if (moveDirection == Direction.Up) flag = true;
                    break;
            }

            if (flag == true && availableDirection.Count > 1)
            {
                for (int i = 0; i < availableDirection.Count; i++)
                {
                    if (direction == availableDirection[i])
                    {
                        availableDirection.RemoveAt(i);
                        break;
                    }


                }
                direction = availableDirection[randomDirection.Next(0, availableDirection.Count - 1)];
            }
            return direction;
        }
        static public List<Direction> AvailableDirection(Map map, Ghost ghost) //this class is responsible for finding possible paths for the ghost
        {
            List<Direction> directions = new List<Direction>();

            if (map.map[ghost.X - 2, ghost.Y] != '#' && map.map[ghost.X - 2, ghost.Y] != '@') directions.Add(Direction.Left);
            if (map.map[ghost.X + 2, ghost.Y] != '#' && map.map[ghost.X + 2, ghost.Y] != '@') directions.Add(Direction.Right);
            if (map.map[ghost.X, ghost.Y - 1] != '#' && map.map[ghost.X, ghost.Y - 1] != '@') directions.Add(Direction.Up);
            if (map.map[ghost.X, ghost.Y + 1] != '#' && map.map[ghost.X, ghost.Y + 1] != '@') directions.Add(Direction.Down);
            return directions;
        }
    }
}
