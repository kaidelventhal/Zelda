using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Projectiles;
using Zelda;
namespace Zelda
{
    public static class GhostCharacterState
    {
        private static int xPos = Constants.linkStartingPosX;
        public static int XPos
        {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
            }
        }
        private static int yPos = Constants.linkStartingPosY;
        public static int YPos
        {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
            }
        }

        private static Rectangle destinationRectangle;
        public static Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }

        private static Rectangle inboundsRectangle;
        public static Rectangle InboundsRectangle
        {
            get { return inboundsRectangle; }
            set { inboundsRectangle = value; }
        }

        private static Vector2 lDir = Constants.linkStartingLDir;
        public static Vector2 LDir
        {
            get
            {
                return lDir;
            }
            set
            {
                lDir = value;
            }
        }

        public static void ResetState()
        {
            xPos = Constants.linkStartingPosX;
            yPos = Constants.linkStartingPosY;
            lDir = Constants.linkStartingLDir;

        }
    }
}