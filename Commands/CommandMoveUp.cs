using Microsoft.Xna.Framework;

namespace Zelda
{
    public class CommandMoveUp : ICommand
    {
        Game1 game;
        MainCharacterSprite sprite;
        Vector2 direction;
        Vector2 stationary;
        public double footstepTime;
        public CommandMoveUp(Game1 game)
        {
            this.game = game;
            sprite = new SpriteMoveUp(game);
            direction = new Vector2(0, -1);
            stationary = new Vector2(0, 0);
        }

        public void Execute()
        {
            if ((!MainCharacterState.Attack&&MainCharacterState.Direction == direction || MainCharacterState.Direction == stationary))
            {
                MainCharacterState.LDir = new Vector2(0, -1);
                MainCharacterState.YPos = MainCharacterState.YPos - Constants.linkSpeed;
                MainCharacterState.LastChange = MainCharacterState.Frame;
                MainCharacterState.Direction = new Vector2(0, -1);
                game.mainCharacter = sprite;
                footstepTime -= 0.03;

                if (footstepTime < 0)
                {
                    SoundLoader.heroMove.Play();
                    footstepTime = 0.5;
                }
            }
        }
    }
}