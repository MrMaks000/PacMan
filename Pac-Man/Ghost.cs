//
// Ghost: this class represent ghosts that haunt the player.
//

using System;
using System.Collections.Generic;

namespace Pac_Man
{
    class Ghost : Character
    {
        public GhostState GostState { get; protected set; }
        private Direction MoveDirection = Direction.None;

        public Ghost(Tuple<int, int> tuple, GhostState gostState) : base(tuple.Item1, tuple.Item2, '@') { this.GostState = gostState; }

        public void GhostMoveLogic(Map mapPoints, Map map) //this method is responsible for the logic of the ghost's movement
        {
            Tuple<int, int> PositionOfPacMan = PositionOnMap.GetPosition(map, '0') ?? null;
            if (GhostSeesPacMan(map, PositionOfPacMan)) GostState = GhostState.Chase;
            else GostState = GhostState.Scatter;

            switch (GostState)
            {
                case GhostState.Chase:
                    ChaseLogic(mapPoints, map);
                    break;
                //case GhostState.Frightened:
                //    break;
                //case GhostState.Retreat:
                //    break;
                case GhostState.Scatter:
                    ScatterLogic(mapPoints, map);
                    break;
            }            
        }

        private void ChaseLogic(Map mapPoints, Map map) //this method is responsible for the logic of the ghost's movement in persecution state 
        {
            Move(MoveDirection, mapPoints, map);
        }

        private void ScatterLogic(Map mapPoints, Map map) //this method is responsible for the logic of the ghost's movement in scatter state 
        {
            Direction direction = GhostMoveDirection.RandomDirection(GhostMoveDirection.AvailableDirection(map, this), MoveDirection);

            if (direction != Direction.None)
            {
                Move(direction, mapPoints, map);            
                MoveDirection = direction;
            }                                      
        }

        

        private bool GhostSeesPacMan(Map map, Tuple<int, int> PositionOfPacMan) //this method is responsible for ghost vision
        {
            if (PositionOfPacMan == null)
            {
                
            }
            else if (Y == PositionOfPacMan.Item2)
            {
                for (int x = X; map.map[x, Y] != '0';)
                {
                    if (map.map[x, Y] == '#') return false;
                    x = X < PositionOfPacMan.Item1 ? x + 2 : x - 2;
                }

                GostState = GhostState.Chase;

                if (X < PositionOfPacMan.Item1) MoveDirection = Direction.Right;
                else MoveDirection = Direction.Left;

                return true;
            }
            else if (X == PositionOfPacMan.Item1)
            {
                for (int y = Y ; map.map[X, y] != '0'; )
                {
                    if (map.map[X, y] == '#') return false;
                    y = Y < PositionOfPacMan.Item2 ? ++y : --y;
                }

                GostState = GhostState.Chase;

                if (Y < PositionOfPacMan.Item2) MoveDirection = Direction.Down;
                else MoveDirection = Direction.Up;

                return true;
            }

            return false;
        }
    }
}
