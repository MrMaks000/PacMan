//
// Dot: this class represent the player's check for hitting the dot.
//

namespace Pac_Man
{
    static class Dot
    {
        static public bool Eat(PacMan player, Map mapPoints) // logic for eating points on the map
        {
            if (mapPoints.map[player.X,player.Y] == '.')
            {
                Score.AddPoints(1);
            }
            else if (mapPoints.map[player.X, player.Y] == 'o')
            {
                Score.AddPoints(10);
            }
            else
            {
                return false;
            }
            mapPoints.map[player.X, player.Y] = ' ';
            return true;
        }
    }
}
