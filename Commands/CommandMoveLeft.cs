using Microsoft.Xna.Framework;

namespace Zelda
{
    public class CommandMoveLeft : ICommand
    {
        Game1 game;
        MainCharacterSprite sprite;
        Vector2 direction;
        Vector2 stationary;
        public double footstepTime;
        public CommandMoveLeft(Game1 game)
        {
            this.game = game;
            sprite = new SpriteMoveLeft(game);
            stationary = new Vector2(0, 0);
            direction = new Vector2(-1, 0);
        }

        public void Execute()
        {
            if ((!MainCharacterState.Attack&&MainCharacterState.Direction == direction || MainCharacterState.Direction == stationary))
            {
                MainCharacterState.LDir = new Vector2(-1, 0);
                MainCharacterState.XPos = MainCharacterState.XPos - Constants.linkSpeed;
                MainCharacterState.LastChange = MainCharacterState.Frame;
                MainCharacterState.Direction = new Vector2(-1, 0);
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