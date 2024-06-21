

using Microsoft.Xna.Framework;

namespace Zelda.RoomRoomObjects
{
    public class HeartContainer : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;


        Game1 game;
        public HeartContainer(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(25, 1, 13, 14);
            
            this.targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 3, sourceRectangle.Height * 3);


            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, targetRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            if (game.mainCharacter.location().Intersects(targetRectangle))
            {
                MainCharacterState.MaxHealth++;
                if (MainCharacterState.MaxHealth > 10)
                {
                    MainCharacterState.MaxHealth = 10;
                }
                MainCharacterState.Health = MainCharacterState.MaxHealth;
                
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
            
        }
    }
}
