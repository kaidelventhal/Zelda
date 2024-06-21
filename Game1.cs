using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.RoomRoomObjects;
using Zelda.Projectiles;
using Zelda.Enemies;
using Zelda.Rooms;
using System.Collections.Generic;
using Zelda;
using System;



namespace Zelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch { get { return _spriteBatch; } }
        private TextureLoader textures;
        public TextureLoader Textures { get { return textures; } }
        private bool isPaused;
        public bool IsPaused { get { return isPaused; } set { isPaused = value; } }
        private bool isStart;
        public bool IsStart { get { return isStart; } set { isStart = value; } }
        private bool isOver;
        public bool IsOver{ get { return isOver; } set { isOver = value; } }
       
        
        private IController KeyboardControls;
        private IController MouseControls;
        private IController GhostControls;
        public CheatCodeController CheatControls;
        public static GameTime GlobalGameTime { get; private set; }
        public MainCharacterSprite mainCharacter;
        public GhostCharacterSprite ghostCharacter;
        public EnemyFactory enemyFactory;
        private DungeonRooms dungeonRooms;
        private StartScreen startScreen;
        private EndScreen endScreen;
        private Gladiator gladiator;
        private BossLoader boss;
        public Constants.GameMode gameMode = Constants.GameMode.Normal;
        public Constants.GameMode GameMode
        {
            get { return gameMode; }
            set { gameMode = value; }
        }

        public DungeonRooms DungeonRooms
        {
            get { return dungeonRooms; }
        }
        private MusicController musicController;
        public MusicController MusicController
        {
            get { return musicController; }
        }
        private InformationDisplay info;
        private SoundLoader sounds;
        public SoundLoader Sounds { get { return sounds; } set { sounds = value; } }
        public SpriteFont DialogueFont { get; private set; }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Constants.screenWidth;
            _graphics.PreferredBackBufferHeight = Constants.screenHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
          
        }
        
        public void initializeDetails()
        {

            MainCharacterState.ResetState();

            isPaused = true;
            IsStart = true;
            IsOver = false;
            GameMode = Constants.GameMode.Normal;
            
            KeyboardControls = new KeyboardController(this);
            MouseControls = new MouseController(this);
            GhostControls = new GhostController(this);
            mainCharacter = new SpriteStationaryRight(this);

            ghostCharacter = new GhostSpriteStationaryRight(this);

            CheatControls = new CheatCodeController(this);
            mainCharacter = new SpriteStationaryUp(this);
            
            dungeonRooms = new DungeonRooms(this);
            gladiator = new Gladiator(this);
            boss = new BossLoader(this);
            LoadContent();
            Console.WriteLine("paused : " + isPaused + " start : " + isStart + "isOver : " + isOver);


        }
        protected override void Initialize()
        {
            
            initializeDetails();   
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            sounds = new SoundLoader(Content);
            textures = new TextureLoader(Content);
            musicController = new MusicController(this);
            info = new InformationDisplay(this);
            
            mainCharacter.Update();//initialize maincharacter- could be removed at at later date.
            startScreen = new StartScreen(this);
            endScreen = new EndScreen(this);
            DialogueFont = Content.Load<SpriteFont>("File");
            

        }

        protected override void Update(GameTime gameTime)
        {
            GlobalGameTime = gameTime;

            if (!isPaused & !IsOver)
            {
                mainCharacter.Update();
                dungeonRooms.Update();
                if (gameMode == Constants.GameMode.Ghost)
                {
                    ghostCharacter.Update();
                    GhostControls.Update();
                }
                if(GameMode == Constants.GameMode.Boss) 
                {
                    boss.Update();
                }
                if(gameMode == Constants.GameMode.Gladiator) gladiator.Update();
            }


            CheatControls.Update();
            KeyboardControls.Update();
            MouseControls.Update();
            startScreen.Update();
            info.Update();
            base.Update(gameTime);

        }
             
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
           
            dungeonRooms.Draw();
            if (gameMode == Constants.GameMode.Gladiator) gladiator.Draw();
            if (gameMode == Constants.GameMode.Ghost) boss.Draw();
            mainCharacter.Draw();
            info.Draw();
            startScreen.Draw();
            endScreen.Draw();

            if (gameMode == Constants.GameMode.Ghost) ghostCharacter.Draw();
            


            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
