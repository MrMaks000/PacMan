//
// Map: this class is responsible for the map.
//

using System.IO;

namespace Pac_Man
{       
    class Map
    {
        public char[,] map { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(string fileName)
        {
            LoadMapFromFile(fileName);
        }

        public Map(string fileName, int firstx, int firsty, int lastx, int lasty)
        {
            LoadMapFromFile(fileName, firstx, firsty, lastx, lasty);
        }

        private void LoadMapFromFile(string fileName, int firstx = 0, int firsty = 0, int lastx = 0, int lasty = 0)
        {
            string[] lines = File.ReadAllLines(fileName);
            if (lastx == 0) Width = lines[0].Length;
            else Width = lastx;

            if (lastx == 0) Height = lines.Length;
            else Height = lasty;
            
            map = new char[Width, Height];



            for (int y = firsty; y < Height; y++)
            {
                for (int x = firstx; x < Width; x++)
                {
                    map[x, y] = lines[y][x];
                }
            }
        }
    }
}
