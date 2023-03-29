//
// Character: this class is the parent of classes PacMan and Ghost
//

using System;

namespace Pac_Man
{
    class Character
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public char Symbol { get; protected set; }

        protected Character(int x, int y, char symbol)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }

        public void Move(Direction directionMove, Map mapPoints, Map map)
        {

            Console.SetCursorPosition(X, Y);
            Console.Write(mapPoints.map[X, Y]);
            map.map[X, Y] = ' ';
            switch (directionMove)
            {
                case Direction.Left:
                    if (map.map[X - 2, Y] == '#') break;
                    X -= 2;
                    break;
                case Direction.Right:
                    if (map.map[X + 2, Y] == '#') break;
                    X += 2;
                    break;
                case Direction.Up:
                    if (map.map[X, Y - 1] == '#') break;
                    Y -= 1;
                    break;
                case Direction.Down:
                    if (map.map[X, Y + 1] == '#') break;                   
                    Y += 1;
                    break;
            }
            FrameRendering.CharacterRendering(this);
            map.map[X, Y] = Symbol;

        }
    }
}
