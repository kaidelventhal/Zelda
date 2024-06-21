namespace Zelda
{
    public class CommandLinkShoot : ICommand
    {
        Game1 game;
        public CommandLinkShoot(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.mainCharacter.Shoot();
            SoundLoader.shootSound.Play();
        }
    }
}