using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Zelda.Enemies;


namespace Zelda
{

    public class TextureLoader
    {
        private Texture2D playerTexture;
        public Texture2D PlayerTexture { get { return playerTexture; } }

        private Texture2D gameBoardTexture;
        public Texture2D GameBoardTexture { get { return gameBoardTexture; } }

        private Texture2D items;
        public Texture2D Items { get { return items; } }

        private Texture2D dungeonEnemies;
        public Texture2D DungeonEnemies { get { return dungeonEnemies; } }

        private Texture2D level1;
        public Texture2D Level1 { get { return level1; } }
        private Texture2D zeldaBoses;
        public Texture2D ZeldaBoses { get { return zeldaBoses; } }
        private Texture2D startScreen;
        public Texture2D StartScreen { get { return startScreen; } }
        private Texture2D pauseScreen;
        public Texture2D PauseScreen { get { return pauseScreen; } }
        private Texture2D finalEndScreen;
        public Texture2D FinalEndScreen { get { return finalEndScreen; } }
        private Texture2D backgroundTexture;
        public Texture2D BackgroundTexture { get { return backgroundTexture; } }

        private SpriteFont countFont;
        public SpriteFont CountFont { get { return countFont; } }

        private Texture2D bOSS1;
        public Texture2D BOSS1 { get { return bOSS1; } }
        private Texture2D bOSS2;
        public Texture2D BOSS2 { get { return bOSS2; } }
        private Texture2D bOSSSword1;
        public Texture2D BOSSSword1 { get { return bOSSSword1; } }
        private Texture2D bossTree;
        public Texture2D BossTree { get { return bossTree; } }

        private Texture2D bOSSSword2;
        public Texture2D BOSSSword2 { get { return bOSSSword2; } }
        private Texture2D bossDeath;
        public Texture2D BossDeath { get { return bossDeath; } }


        public TextureLoader(ContentManager Content)
        {
            playerTexture = Content.Load<Texture2D>("ZeldaSprites");
            gameBoardTexture = Content.Load<Texture2D>("Obstacles");
            items = Content.Load<Texture2D>("Items");
            dungeonEnemies = Content.Load<Texture2D>("DungeonEnemies");
            zeldaBoses = Content.Load<Texture2D>("ZeldaBoses");
            level1 = Content.Load<Texture2D>("Level1");
            startScreen = Content.Load<Texture2D>("StartScreen");
            pauseScreen = Content.Load<Texture2D>("PauseScreen");
            finalEndScreen = Content.Load<Texture2D>("FinalEndScreen");
            countFont = Content.Load<SpriteFont>("Score");

            backgroundTexture = Content.Load<Texture2D>("startscreen");
            bOSS1 = Content.Load<Texture2D>("BOSS1");
            bOSS2 = Content.Load<Texture2D>("BOSS2");
            bOSSSword1 = Content.Load<Texture2D>("BOSSSword1");
            bossTree = Content.Load<Texture2D>("BossTree");
            bOSSSword2 = Content.Load<Texture2D>("BOSSSword2");
            bossDeath = Content.Load<Texture2D>("BossDeath");
        }
    }
}

