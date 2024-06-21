using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Projectiles;
using Zelda;
namespace Zelda
{
    public static class MainCharacterState
    {
        private static Dictionary<Constants.items,int> inventoryItems = new Dictionary<Constants.items, int>();
        public static Dictionary<Constants.items, int> InventoryItems
        {
            get
            {
                return inventoryItems;
            }
            set
            {
                inventoryItems = value;
            }
        }
        private static Vector2 direction = Constants.linkStartingDirection;
        public static Vector2 Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        }
        private static Rectangle destinationRectangle;
        public static Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }

        private static Constants.items currentItem = Constants.items.Candle;
        public static Constants.items CurrentItem
        {
            get
            {
                return currentItem;
            }
            set
            {
                currentItem = value;
            }
        }
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
        private static int frame = 0;
        public static int Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
            }
        }
        private static int lastChange;
        public static int LastChange
        {
            get
            {
                return lastChange;
            }
            set
            {
                lastChange = value;
            }
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
        
        
        private static Boolean attack = false;
        public static Boolean Attack
        {
            get{return attack;}
            set{attack = value;}
        }
        
        private static int health = Constants.linkStartingHealth;
        public static int Health
        {
            get { return health; }
            set { health = value; }
        }
        private static int maxhealth = Constants.linkStartingHealth;
        public static int MaxHealth
        {
            get { return maxhealth; }
            set { maxhealth = value; }
        }
        
        private static Rectangle inboundsRectangle;
        public static Rectangle InboundsRectangle
        {
            get { return inboundsRectangle; }
            set { inboundsRectangle = value; }
        }
        public static bool invincible = false;
        public static bool Invincible
        {
            get { return invincible; }
            set { invincible = value; }
        }
        public static void ResetState()
        {
            currentItem = Constants.items.Candle;
            inventoryItems = new Dictionary<Constants.items, int>
            {
                { currentItem, 1 },
                { Constants.items.Key, 0 },
                { Constants.items.Rupee, 0 }
            };
            xPos = Constants.linkStartingPosX;
            yPos = Constants.linkStartingPosY;
            health = Constants.linkStartingHealth;
            frame = 0;
            lDir = Constants.linkStartingLDir;
            direction = Constants.linkStartingDirection;
            attack = false;
            invincible = false;
            
        }
    }
}