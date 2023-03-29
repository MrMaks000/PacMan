//
// Game: this class control the game in general.
//

using System;
using System.Collections.Generic;

namespace Pac_Man
{  
    static class Game
    {        
        static private Map map;
        static private Map mapPoints;
        static private PacMan player;
        static private List<Ghost> ghosts;

        static private List<Tuple<int, int>> list;
        static private Direction direction;
        static private bool stateOfGame;

        static private int delay;
        static private int lastTicks;


        static public void Start(string levelNamber, int _delay)  //start the game.
        {
            delay = _delay;
            map = new Map(@"LevelDisigns\" + levelNamber + "\\Map.txt");
            mapPoints = new Map(@"LevelDisigns\" + levelNamber + "\\Points.txt");
            player = new PacMan(PositionOnMap.GetPosition(map, '0'));

            Console.SetWindowSize(map.Width + 1, map.Height);

            direction = new Direction();                       
            list = new List<Tuple<int, int>>();
            list = PositionOnMap.GetManyPosition(map, '@');
            ghosts = new List<Ghost>();
            foreach (var item in list)
            {
                ghosts.Add(new Ghost(item, GhostState.Scatter));
            }

            FrameRendering.MapRendering(map);
            FrameRendering.MapRendering(mapPoints);
            stateOfGame = true;
            lastTicks = Environment.TickCount & Int32.MaxValue;

            Update();
            Console.Clear();
            EndGame();
        }

        static public void Update()  //updates the state of the game.
        {                                                        
            while ((Score.Scoring(mapPoints, '.')))
            {
                direction = Input.ReadInput();

                if (lastTicks + delay <= (Environment.TickCount & Int32.MaxValue))
                {
                    lastTicks = Environment.TickCount & Int32.MaxValue;

                    player.Move(direction, mapPoints, map);
                    player.Eat(player, mapPoints);

                    foreach (var item in ghosts)
                    {
                        item.GhostMoveLogic(mapPoints, map);
                    }

                    if (player.Die(map, direction, '@'))
                    {
                        stateOfGame = false;
                        break;
                    }
                }
            }           
        }

        

        static private void EndGame() //ends the game
        {
            Score.Zeroing();
            String @string;
            if (!stateOfGame)
            {
                mapPoints = new Map(@"LevelDisigns\End\Points.txt");

                @string = "Game Over";
                for (int i = 0; i < @string.Length + 10; i++)
                {
                    System.Threading.Thread.Sleep(300);
                    if (i < @string.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(12 + 2 * i, 6);
                        Console.Write(@string[i]);
                        Console.ResetColor();
                    }

                    foreach (var item in ghosts)
                    {
                        item.GhostMoveLogic(mapPoints, map);
                    }
                }
            }
            else
            {
                @string = "Good game";
                map = new Map(@"LevelDisigns\Menu\Map.txt");
                mapPoints = new Map(@"LevelDisigns\Menu\Points.txt");
                Console.SetWindowSize(map.Width, map.Height);
                FrameRendering.MapRendering(map);
                FrameRendering.MapRendering(mapPoints);   
                
                for (int i = 0; i < @string.Length + 10; i++)
                {
                    System.Threading.Thread.Sleep(300);
                    if (i < @string.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(12 + 2 * i, 6);
                        Console.Write(@string[i]);
                    }
                }
                Console.ResetColor();
            }
            Console.Clear();
        }
    }
}
