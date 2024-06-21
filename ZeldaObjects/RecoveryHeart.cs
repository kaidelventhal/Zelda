

using Microsoft.Xna.Framework;

namespace Zelda.RoomRoomObjects
{
    public class RecoveryHeart : Iitem
    {
        private Rectangle[] sourceRectangle;
        private Rectangle targetRectangle;

        private int frame;
        Game1 game;
        public RecoveryHeart(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle[2];
            this.sourceRectangle[0] = new Rectangle(0, 0, 7, 8);
            this.sourceRectangle[1] = new Rectangle(0, 8, 7, 8);
            this.targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle[0].Width * 4, sourceRectangle[0].Height * 4);
            this.frame = 0;

            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, targetRectangle, sourceRectangle[frame/4%2], Color.White);
        }

        public void Update()
        {
            if (game.mainCharacter.location().Intersects(targetRectangle))
            {
                MainCharacterState.Health++;
                if (MainCharacterState.Health > MainCharacterState.MaxHealth)
                {
                    MainCharacterState.Health = MainCharacterState.MaxHealth;
                }
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
            if(frame == 800)
            {
                game.DungeonRooms.RemoveItem(this);
            }
        }
    }
}
