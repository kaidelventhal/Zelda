using Microsoft.Xna.Framework.Media;

namespace Zelda
{


    public class MusicController
    {
        private Game1 game;
        private Song backgroundMusic;
        private bool isMusicPaused = false; // Track the music state separately from game pause state
        public MusicController(Game1 game)
        {
            this.game = game;
            backgroundMusic = game.Sounds.BackgroundMusic;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
            
        }
        public void togleMusic()
        {
            if (isMusicPaused)
            {
                MediaPlayer.Resume();
            }
            else
            {
                MediaPlayer.Pause();
            }
            isMusicPaused = !isMusicPaused;
        }
    }
}
