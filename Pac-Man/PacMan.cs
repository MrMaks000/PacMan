//
// PacMan: This class represents the player - the main character of the PacMan game.
//

using System;

namespace Pac_Man 
{
    class PacMan : Character
    {
        public PacMan(Tuple<int, int> tuple) : base(tuple.Item1, tuple.Item2, '0') { }     

        public bool Die(Map map, Direction moveDirection, char symbol) //checking for player death.
        {
            if (map.map[X, Y] == symbol)
            {
                return true;
            }

            switch (moveDirection)
            {
                case Direction.Left:
                    if (map.map[X + 2, Y] == symbol) return true;
                    break;
                case Direction.Right:
                    if (map.map[X - 2, Y] == symbol) return true;
                    break;
                case Direction.Up:
                    if (map.map[X, Y + 1] == symbol) return true;
                    break;
                case Direction.Down:
                    if (map.map[X, Y - 1] == symbol) return true;
                    break;
            }
            return false;
        }

        public void Eat(PacMan player, Map mapPoints) //allows the player to eat a point on the map.
        {
            if (Dot.Eat(player, mapPoints))
            {
                Score.Draw();
            }
        }
    }
}
