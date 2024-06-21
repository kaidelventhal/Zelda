using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{

    public class SoundLoader
    {
        public static SoundEffect shootSound { get; private set; }
        public static SoundEffect monsterDy1;
        public static SoundEffect monsterDy2;
        public static SoundEffect heroMove;
        public static SoundEffect heroAttack;
        public static SoundEffect openDoor;
        public static SoundEffect pickItem;
        public static SoundEffect takeDamage;
        public static SoundEffect bossAttack;
        public static SoundEffect bossAttack2;
        public static SoundEffect bossDeath;
        private Song backgroundMusic;



        public Song BackgroundMusic { get { return backgroundMusic; } }


        public SoundLoader(ContentManager Content)
        {
            shootSound = Content.Load<SoundEffect>("shoot");
            monsterDy2 = Content.Load<SoundEffect>("monsterdy2");
            monsterDy1 = Content.Load<SoundEffect>("monsterdy1");
            heroMove = Content.Load<SoundEffect>("move");
            heroAttack = Content.Load<SoundEffect>("attack");
            openDoor = Content.Load<SoundEffect>("opendoor");
            pickItem = Content.Load<SoundEffect>("pick");
            takeDamage = Content.Load<SoundEffect>("takedamage");
            backgroundMusic = Content.Load<Song>("ZeldaMusic");

            bossAttack = Content.Load<SoundEffect>("Bossattack");
            bossAttack2 = Content.Load<SoundEffect>("Boss2attack");
            bossDeath = Content.Load<SoundEffect>("Bossdeathm");
        }


    }
}
