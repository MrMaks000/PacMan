//
// GameSplashScreen: this class responsible for the screen saver.
//

using System;
using System.Collections.Generic;

namespace Pac_Man
{
    class GameSplashScreen
    {
        static private Map map;
        static private Map mapPoints;
        static private List<Ghost> ghosts;
        static private List<Tuple<int, int>> list;
        static private int lastTicks;

        static public void SplashScreen()
        {
            lastTicks = Environment.TickCount & Int32.MaxValue;
            String @string = "Pac-Man";

            map = new Map(@"LevelDisigns\Menu\Map.txt");
            mapPoints = new Map(@"LevelDisigns\Menu\Points.txt");

            Console.SetWindowSize(map.Width + 1, map.Height);

            list = new List<Tuple<int, int>>();
            list = PositionOnMap.GetManyPosition(map, '@');
            ghosts = new List<Ghost>();
            foreach (var item in list)
            {
                ghosts.Add(new Ghost(item, GhostState.Scatter));
            }

            FrameRendering.MapRendering(map);
            FrameRendering.MapRendering(mapPoints);
            int i = 0;
            while (i < @string.Length + 10)
            {

                if (lastTicks + 300 <= (Environment.TickCount & Int32.MaxValue))
                {
                    lastTicks = Environment.TickCount & Int32.MaxValue;
                    if (i < @string.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(14 + 2 * i, 6);
                        Console.Write(@string[i]);
                        Console.ResetColor();
                    }

                    foreach (var item in ghosts)
                    {
                        item.GhostMoveLogic(mapPoints, map);
                    }
                    i++;
                }
            }
            Console.Clear();


        }
    }
}
