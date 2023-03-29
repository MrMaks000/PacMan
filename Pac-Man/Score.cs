//
// GameEngine: this class is responsible for displaying and scoring in the game.
//

using System;

namespace Pac_Man
{
    static class Score
    {
        static public int points { get; private set; } = 0;

        static public void Draw()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2 - 1);
            Console.Write($"o {points}");
        }

        static public void AddPoints(int amount)
        {
            points += amount;
        }

        static public bool Scoring(Map map, char symbol) //the method is responsible for checking the presence of points
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (map.map[x, y] == symbol) return true;
                }
            }
            return false;
        }

        static public void Zeroing() //reset points
        {
            points = 0;
        }
    }
}
