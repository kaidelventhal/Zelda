using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.RoomRoomObjects
{
    public class RoomObjects : ISprite
    {


        private Game1 game;

        private List<ISprite> Objects;
        public List<ISprite> GetRoomObjects {  get { return Objects; } set { Objects = value; } }


        public RoomObjects(Game1 game, List<ISprite> RoomObjects)
        {
            this.game = game;
            this.Objects = RoomObjects;       
            
        }

        public void Draw()
        {
            
            foreach(ISprite item in Objects)
            {
                item.Draw();
            }
        }

        public void Update()
        {
            for(int i = 0; i < Objects.Count; i++)
            {
                Objects[i].Update();
            }
                
            

        }
        public void AddItem(ISprite Item)
        {
            Objects.Add(Item);
        }
        public void RemoveItem(ISprite Item)
        {
            Objects.Remove(Item);
        }
    }
}
