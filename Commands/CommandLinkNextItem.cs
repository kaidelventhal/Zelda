namespace Zelda
{
    public class CommandLinkNextItem : ICommand
    {
        Game1 game;
        public CommandLinkNextItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.mainCharacter.nextItem();
        }
    }
}