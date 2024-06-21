namespace Zelda
{
    public class CommandLinkSwordAttack : ICommand
    {
        Game1 game;
        public CommandLinkSwordAttack(Game1 game)
        {
            this.game = game;

        }

        public void Execute()
        {
            
            
            if (MainCharacterState.LDir.X == -1)
            {
                game.mainCharacter = new SpriteAttackLeft(game);
                SoundLoader.heroAttack.Play();
            }
            else if (MainCharacterState.LDir.X == 1)
            {
                game.mainCharacter = new SpriteAttackRight(game);
                SoundLoader.heroAttack.Play();
            }
            else if (MainCharacterState.LDir.Y == -1)
            {
                game.mainCharacter = new SpriteAttackUp(game);
                SoundLoader.heroAttack.Play();
            }
            else if (MainCharacterState.LDir.Y == 1)
            {
                game.mainCharacter = new SpriteAttackDown(game);
                SoundLoader.heroAttack.Play();
            }
        }
    }
}
