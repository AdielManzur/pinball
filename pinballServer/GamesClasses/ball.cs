using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pinballServer.GamesClasses
{
    public class Ball
    {
        public Vector2 vector { get; set; }
        public Point ballPosition { get; set; }
        public int ballSpeed;
        public int ballRadius;
        /*
        public bool checkCollisionWithWalls(int ScreenWidth, int ScreenHeight)
        {
            
            if (ballPosition.Y == ScreenHeight) //Collision with the lower wall
            {
                return true;
            }
            if (ballPosition.Y == 0) //Collision with the upper wall
            {
                return true;
            }
            if (ballPosition.X == ScreenWidth)//Collision with the right wall
            {
                return true;
            }
            if (ballPosition.X == 0)//Collision with the left wall
            {
                return true;
            }
            return false;
        }
            */
        public bool checkCollisionWithPlayers()
        {
            return true;
        }

    }
}
