//
// FrameRendering: this class is responsible for drawing the game.
//

using System;

namespace Pac_Man
{
    static class FrameRendering
    {
        static public void CharacterRendering(Character[] character) //will render the many characters to the console
        {
            if (character[0].Symbol == '@') Console.ForegroundColor = ConsoleColor.DarkMagenta;
            else if (character[0].Symbol == '0') Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in character)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(Convert.ToChar(item.Symbol));
            }
            Console.ResetColor();
        }

        static public void CharacterRendering(Character character) //will render the character to the console
        {
            Character[] arrayCharacter = new Character[1];
            arrayCharacter[0] = character;
            CharacterRendering(arrayCharacter);
        }

        static public void MapRendering(Map map, int firstx = 0, int firsty = 0, int lastx = 0, int lasty = 0) //renders the map to the console
        {
            Console.SetCursorPosition(firstx, firsty);

            if (lasty > map.Height || lasty == 0) lasty = map.Height;
            if (lastx > map.Width || lastx == 0) lastx = map.Width;

            for (int y = firsty; y < lasty; y++)
            {
                for (int x = firstx; x < lastx; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (map.map[x, y] == ' ')
                    {
                        Console.SetCursorPosition(x + 1, y);
                    }
                    else
                    {
                        if (map.map[x, y] == '#') Console.ForegroundColor = ConsoleColor.Cyan;
                        else if (map.map[x, y] == '@') Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        else if (map.map[x, y] == '0') Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(map.map[x, y]);
                    }

                }

            }
            Console.ResetColor();
        }
    }
}
