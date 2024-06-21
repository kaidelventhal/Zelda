

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.RoomRoomObjects
{
    public class Triforce : Iitem
    {
        private Rectangle[] sourceRectangle;
        private Rectangle targetRectangle;
        private int frame;
        ICommand endGame;
        Game1 game;
        public Triforce(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle[2];
            this.sourceRectangle[0] = new Rectangle(275, 3, 12, 12);
            this.sourceRectangle[1] = new Rectangle(275, 19, 12, 12);
            this.targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle[0].Width * 4, sourceRectangle[0].Height * 4);
            endGame = new CommandEndGame(game);
            frame = 0;
            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, targetRectangle, sourceRectangle[frame/8%2], Color.White);
        }

        public void Update()
        {
            if (game.mainCharacter.location().Intersects(targetRectangle))
            {


                endGame.Execute();
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
            frame++;
        }
    }
}
