using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zelda.Enemies;
using Zelda.Projectiles;
using Zelda.RoomRoomObjects;
using Zelda.ZeldaItems;

namespace Zelda.Rooms
{
    public class DungeonLoader
    {
        private Game1 game;
        public DungeonLoader(Game1 game) {
            this.game = game;
        }
        private int Xoffset = Constants.dungeonLoaderOffsetX;
        private int Yoffset = Constants.dungeonLoaderOffsetY;
        public  List<Room> LoadDungeon(String source)
        {
            XmlTextReader reader = new XmlTextReader(source);
            
            
            List<Room> rooms = new List<Room>();
            List<Rectangle> rectangleList = new List<Rectangle>();
            List<ISprite> enemies = new List<ISprite>();
            List<ISprite> RoomObjects = new List<ISprite>();
            Rectangle sourceRectangle = new Rectangle();
            string lastTag = "";
            string lastText = "";
            string[] value = new string[0];
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        lastTag = reader.Name;
                        switch (reader.Name)
                        {
                            case "Room":
                                rectangleList = new List<Rectangle>();
                                enemies = new List<ISprite>();
                                RoomObjects = new List<ISprite>();
                                break;
                            default:
                                break;
                        }
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        lastText = reader.Value;
                        switch (lastTag)
                        {
                            case "Rectangle":
                                var rectangleInts = reader.Value.Split(" ");
                                rectangleList.Add(new Rectangle(Convert.ToInt32(rectangleInts[0])+Xoffset, Convert.ToInt32(rectangleInts[1])+Yoffset, Convert.ToInt32(rectangleInts[2]), Convert.ToInt32(rectangleInts[3])));
                                break;
                            case "SourceRectangle":
                                var rectangleInts2 = reader.Value.Split(" ");
                                sourceRectangle = new Rectangle(Convert.ToInt32(rectangleInts2[0]), Convert.ToInt32(rectangleInts2[1]), Convert.ToInt32(rectangleInts2[2]), Convert.ToInt32(rectangleInts2[3]));
                                break;
                            default:
                                value = reader.Value.Split(" ");
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        switch (reader.Name)
                        {
                            case "Item":
                                switch (value[0])
                                {
                                    case "Key":
                                        RoomObjects.Add(new Key(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2])+Yoffset, Convert.ToBoolean(value[3])));
                                        break;
                                    case "Boomerang":
                                        RoomObjects.Add(new BoomerangItem(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset, Convert.ToBoolean(value[3])));
                                        break;
                                    case "Ring":
                                        RoomObjects.Add(new Ring(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2])+Yoffset));
                                        break;
                                    case "Rupee":
                                        RoomObjects.Add(new Rupee(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    case "Candle":
                                        RoomObjects.Add(new Candle(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;

                                    case "Map":
                                        RoomObjects.Add(new Map(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    case "Compass":
                                        RoomObjects.Add(new Compass(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    case "Bow":
                                        RoomObjects.Add(new Bow(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    case "Triforce":
                                        RoomObjects.Add(new Triforce(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    case "Door":
                                        RoomObjects.Add(new Door(game, value[1] ,rooms.Count, Convert.ToInt32(value[2])));
                                        break;
                                    case "ExplodedDoor":
                                        RoomObjects.Add(new ExplodedDoor(game, value[1],rooms.Count));
                                        break;
                                    case "KeyDoor":
                                        RoomObjects.Add(new KeyDoor(game, value[1], rooms.Count));
                                        break;
                                    case "ClearRoomDoor":
                                        RoomObjects.Add(new ClearRoomDoor(game, value[1], rooms.Count, Convert.ToBoolean(value[2])));
                                        break;
                                    case "DecoyBlock":
                                        
                                        RoomObjects.Add(new MovingBlock(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                }
                                break;
                            case "Enemy":
                                Console.WriteLine(lastText);
                                switch (value[0])
                                {
                                    case "Dragon":
                                        enemies.Add(new Dragon(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2])+Yoffset));
                                        break;
                                    case "Bat":
                                        enemies.Add(new Bat(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2])+Yoffset));
                                        break;
                                    case "Darknut":
                                        enemies.Add(new Darknut(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2])+Yoffset));
                                        break;
                                    case "Goriya":
                                        enemies.Add(new Goriya(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2])+Yoffset));
                                        break;
                                    case "Wizzrobe":
                                        enemies.Add(new Wizzrobe(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2])+Yoffset));
                                        break;
                                    case "Skeleton":
                                        enemies.Add(new Skeleton(game, Convert.ToInt32(value[1])+Xoffset, Convert.ToInt32(value[2]) + Yoffset, Convert.ToBoolean(value[3])));
                                        break;
                                    case "NPC":
                                        enemies.Add(new NPC(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    case "Gel":
                                        enemies.Add(new Gel(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    case "Wallmaster":
                                        enemies.Add(new Wallmaster(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset, Convert.ToInt32(value[3])));
                                        break;
                                    case "Trap":
                                        enemies.Add(new Trap(game, Convert.ToInt32(value[1]) + Xoffset, Convert.ToInt32(value[2]) + Yoffset));
                                        break;
                                    default: break;
                                }
                                break;
                            case "Room":
                                EnemyFactory enemyFactory = new EnemyFactory(game, enemies);
                                RoomObjects itemCollection = new RoomObjects(game, RoomObjects);
                                rooms.Add(new Room(game, sourceRectangle,new Rectangle(Xoffset,Yoffset,Constants.gameWindowWidth,Constants.gameWindowHeight), rectangleList, enemyFactory, itemCollection));
                                break;
                            default:
                                break;
                        }
                        break;
                }

            }
            Console.WriteLine("Number of rooms " + rooms.Count);
            return rooms;
        }
    }
}
