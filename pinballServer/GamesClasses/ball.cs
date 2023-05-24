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
        public int ballSpeedY { get; set; }
        public int ballSpeedX { get; set; }
        public int ballRadius { get; set; }

        public bool goalToRightPlayer(int screenWidth)
        {
            if (ballLocation.X + 2 * ballRadius == screenWidth)
            {
                return true;
            }
            return false;
        }
        public bool goalToLeftPlayer()
        {
            if (ballLocation.X == 0)
            {
                return true;
            }
            return false;
        }
        public bool collisionUpperWall()
        {
            if (ballLocation.Y == 0)
            {
                return true;
            }
            return false;

        }
        public bool collisionLowerWall(int screenHeight)
        {
            if (ballLocation.Y + 2 * ballRadius == screenHeight)
            {
                return true;
            }
            return false;
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
