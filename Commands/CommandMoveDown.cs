using Microsoft.Xna.Framework;

namespace Zelda
{
    public class CommandMoveDown : ICommand
    {
        Game1 game;
        MainCharacterSprite sprite;
        Vector2 direction;
        Vector2 stationary;
        public double footstepTime;
        public CommandMoveDown(Game1 game)
        {
            this.game = game;
            sprite = new SpriteMoveDown(game);
            stationary = new Vector2(0, 0);
            direction = new Vector2(0, 1);
        }

        public void Execute()
        {
            if((!MainCharacterState.Attack&&MainCharacterState.Direction == direction||MainCharacterState.Direction == stationary))
            {
                MainCharacterState.LDir = new Vector2(0, 1);
                MainCharacterState.YPos = MainCharacterState.YPos + Constants.linkSpeed;
                MainCharacterState.LastChange = MainCharacterState.Frame;
                MainCharacterState.Direction = new Vector2(0, 1);
                game.mainCharacter = sprite;
                footstepTime -= 0.03;

                if (footstepTime <0)
                {
                    SoundLoader.heroMove.Play();
                    footstepTime = 0.5;
                }
            }
           
        }
    }
}