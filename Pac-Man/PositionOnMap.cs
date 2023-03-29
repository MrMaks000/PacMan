//
// PositionOnMap: this class is responsible for finding a position on the map.
//

using System;
using System.Collections.Generic;

namespace Pac_Man
{
    static class PositionOnMap
    {
        static public Tuple<int, int> GetPosition(Map map, char symbol)
        {
            List<Tuple<int, int>> list = GetManyPosition(map, symbol);
            return list.Count == 1 ? list[0] : null;
        }

        static public List<Tuple<int, int>> GetManyPosition(Map map, char symbol)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (map.map[x, y] == symbol)
                    {
                        list.Add(Tuple.Create(x, y));
                    }
                }

            }
            return list;
        }
    }
}
