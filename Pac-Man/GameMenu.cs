//
// GameMenu: this class control the game menu.
//

using System;
using System.Collections.Generic;

namespace Pac_Man
{
    class GameMenu
    {
        static private int delay = 400;
        static private int lastTicks;

        static void Main() 
        {
            Console.CursorVisible = false;
            GameSplashScreen.SplashScreen();
            LevelsMenu();
        }
        
        static private void LevelsMenu()
        {
            char LevelKey;
            while (true)
            {
                LevelKey = MenuController("MenuMap");
                if (LevelKey == 'o')
                {
                    delay = MenuOptions();
                }
                else if (LevelKey == 'i')
                {
                    return;
                }
                else
                {
                    Game.Start("Level_" + LevelKey, delay);                    
                }
            }
        }

        static private int MenuOptions()
        {
            switch (MenuController("MenuOptions"))
            {
                case 's':
                    return 400;
                case 'i':
                    return 300;
                case 'r':
                    return 250;
                case 'm':
                    return 200;
                case 'c':
                    return delay;
            }
            return delay;
        }

        static private char MenuController(string str)
        {
            Map map = new Map(@"LevelDisigns\Menu\" + str + ".txt");
            Direction direction;
            lastTicks = Environment.TickCount & Int32.MaxValue;
            bool flag = true;
            int firstx = 0, firsty = 0, lastx = 7, lasty = 4;
            

            Console.SetWindowSize(map.Width + 1, map.Height);

            FrameRendering.MapRendering(map);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else
                    {
                        direction = Input.KeyHandler(key);
                    }
                }
                else direction = Direction.None;

                if (direction != Direction.None || flag == true)
                {
                    flag = false;
                    switch (direction)
                    {
                        case Direction.Up:
                            if (firsty - 4 < 0) break;
                            lasty = firsty;
                            firsty -= 4;
                            break;
                        case Direction.Down:
                            if (lasty + 4 > map.Height) break;
                            firsty = lasty;
                            lasty += 4;
                            break;
                        case Direction.Left:
                            if (firstx - 7 < 0) break;
                            lastx = firstx;
                            firstx -= 7;
                            break;
                        case Direction.Right:
                            if (lastx + 7 > map.Width) break;
                            firstx = lastx;
                            lastx += 7;
                            break;
                    }

                    if (map.map[lastx - 1, firsty + 2] != '|')
                    {
                        for (int x = firstx + 1; x < map.Width; x++)
                        {
                            if (map.map[x, firsty + 2] == '|')
                            {
                                lastx = x + 1;
                                break;
                            }
                        }
                    }
                    else if (map.map[firstx, firsty + 2] != '|')
                    {
                        for (int x = lastx - 2; x >= 0; x--)
                        {
                            if (map.map[x, firsty + 2] == '|')
                            {
                                firstx = x;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int x = firstx + 1; x < lastx - 1; x++)
                        {
                            if (map.map[x, firsty + 2] == '|')
                            {
                                lastx = x + 1;
                                break;
                            }
                        }
                    }
                }

                if (lastTicks + 300 <= (Environment.TickCount & Int32.MaxValue))
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    FrameRendering.MapRendering(map, firstx, firsty, lastx, lasty);

                    System.Threading.Thread.Sleep(300);

                    Console.ResetColor();
                    FrameRendering.MapRendering(map, firstx, firsty, lastx, lasty);
                    lastTicks = Environment.TickCount & Int32.MaxValue;

                }
            }
            Console.Clear();
            return map.map[(lastx + firstx) / 2, firsty + 2];
        }
    }
}

