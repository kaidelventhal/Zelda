using Microsoft.Xna.Framework;
using System;
using System.Runtime.InteropServices;

namespace Zelda.RoomRoomObjects
{
    public class Door : ISprite
    {
        private Rectangle targetRectangle;

        private int room;
        private int transportRoom;
        private int transportX;
        private int transportY;
        private Boolean hit;
        private String location;
        Game1 game;
        //int xPosition, int yPosition, int Width, int Height, int transportX, int transportY,int room, int transportRoom,
        public Door(Game1 game, string doorside, int room, int transportRoom)
        {
            this.location = doorside;
            
            switch (doorside)
            {
                case "left":
                    this.targetRectangle = new Rectangle(92+Constants.dungeonLoaderOffsetX, 320+Constants.dungeonLoaderOffsetY, 15, 64);
                    this.transportX = 823 + Constants.dungeonLoaderOffsetX;
                    this.transportY = 300 + Constants.dungeonLoaderOffsetY;
                    break;
                case "right":
                    this.targetRectangle = new Rectangle(950 + Constants.dungeonLoaderOffsetX, 320 + Constants.dungeonLoaderOffsetY, 15, 64);
                    this.transportX = 128 + Constants.dungeonLoaderOffsetX;
                    this.transportY = 320 + Constants.dungeonLoaderOffsetY;
                    break;
                case "bottom":
                    this.targetRectangle = new Rectangle(476 + Constants.dungeonLoaderOffsetX, 593 + Constants.dungeonLoaderOffsetY, 64, 15);
                    this.transportX = 472 + Constants.dungeonLoaderOffsetX;
                    this.transportY = 118 + Constants.dungeonLoaderOffsetY;
                    break;
                case "top":
                    this.targetRectangle = new Rectangle(476 + Constants.dungeonLoaderOffsetX, 85 + Constants.dungeonLoaderOffsetY, 64, 15);
                    this.transportX = 472 + Constants.dungeonLoaderOffsetX;
                    this.transportY = 488 + Constants.dungeonLoaderOffsetY;
                    break;
                case "basement":
                    this.targetRectangle = new Rectangle(512 + Constants.dungeonLoaderOffsetX, 320 + Constants.dungeonLoaderOffsetY, 64, 64);
                    this.transportX = 200 +Constants .dungeonLoaderOffsetX;
                    this.transportY = 200 +Constants .dungeonLoaderOffsetY;
                    break;
                case "attic":
                    this.targetRectangle = new Rectangle(200 + Constants.dungeonLoaderOffsetX, 120 + Constants.dungeonLoaderOffsetY, 64, 64);
                    this.transportX = 320 + Constants.dungeonLoaderOffsetX;
                    this.transportY = 320 + Constants.dungeonLoaderOffsetY;
                    break;
                default:
                    
                    break;
            }
            this.transportRoom = transportRoom;
            this.room = room;
            this.game = game;
            hit = false;
        }
        public void Draw()
        {
           
        }

        public void Update()
        {
            if (MainCharacterState.InboundsRectangle.Intersects(targetRectangle)&&game.DungeonRooms.TransitionTime<-80)
            {
                Console.WriteLine("Touch door");
                if (location.Equals("basement") || location.Equals("attic"))
                {
                    game.DungeonRooms.changeRoom(transportRoom,0);
                }
                else
                {
                    game.DungeonRooms.changeRoom(transportRoom,Constants.roomTransitionTime);
                }
               
                hit = true;
                
                Console.WriteLine("Xpos: " + transportX + " Ypos: " + transportY);
            }
            if (hit && game.DungeonRooms.TransitionTime == 0)
            {
                MainCharacterState.XPos = transportX;
                MainCharacterState.YPos = transportY;
                
                hit = false;

            }
            
        }
    }
}
