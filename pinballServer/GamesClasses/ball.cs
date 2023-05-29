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
        public Point ballLocation { get; set; }
        public float ballRadius { get; set; }
        public float ballSpeedY { get; set; }
        public float ballSpeedX { get; set; }


        public bool goalToRightPlayer(int screenWidth)
        {
            return (ballLocation.X + 2 * ballRadius == screenWidth);
            
        }
        public bool goalToLeftPlayer()
        {
            return (ballLocation.X == 0);
            
        }
        public bool collisionUpperWall()
        {
           
            return (ballLocation.Y == 0);

        }
        public bool collisionLowerWall(int screenHeight)
        {
            return (ballLocation.Y + (2 * ballRadius) == screenHeight);
            
        }
        public bool checkCollisionWithRightPlayer(Point player1Location, int playerHeight,int playerWidth)
        {
            int playerTop = player1Location.Y;
            int playerBottom = player1Location.Y + playerHeight;

            if (ballLocation.X + (2 * ballRadius) == player1Location.X &&
                ballLocation.Y + (2 * ballRadius)  > playerTop &&
                ballLocation.Y  < playerBottom )
            {
                return true;
            }

            return false;

        }
        public bool checkCollisionWithLeftPlayer(Point player2Location, int playerHeight, int playerWidth)
        {
            int playerTop = player2Location.Y;
            int playerBottom = player2Location.Y + playerHeight;

            if (ballLocation.X == player2Location.X + playerWidth &&
                ballLocation.Y + (2 * ballRadius) > playerTop &&
                ballLocation.Y < playerBottom)
            {
                return true;
            }
            return false;

        }
    }
}
