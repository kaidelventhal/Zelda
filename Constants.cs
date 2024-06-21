using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace Zelda
{
    public static class Constants
    {
        //GAME
        public static readonly int gameWindowHeight = 704;
        public static readonly int gameWindowWidth = 1024;
        

        public static readonly int screenHeight = gameWindowHeight + 258; //962
        public static readonly int screenWidth = gameWindowWidth + 200;  //1224

        public static readonly int roomTransitionTime = 120;

        public static readonly int dungeonLoaderOffsetX = 100;
        public static readonly int dungeonLoaderOffsetY = 208;
        public static readonly int wallWidth = 128;
        public static readonly int edgewidth = 60;

        public static readonly Random random = new Random();

        //LINK
        public static readonly int linkSpeed = 3;
        public static readonly int linkStartingPosX = 590;
        public static readonly int linkStartingPosY = 680;
        public static readonly int linkStartingHealth = 12;
        public static readonly int linkMaxHealth = 20;
        public static readonly int linkStartingBombs = 10;
        public static readonly int linkStartingKeys = 0;
        public static readonly int linkStartingRupees = 0;
        public static readonly Vector2 linkStartingDirection = new Vector2(0, -1);
        public static readonly Vector2 linkStartingLDir = new Vector2(0, -1);

        //FILE NAMES
        public static readonly string ghostFileName = "../../../GhostCharacter/savedata.txt";
        public static readonly string cheatCodeFileName = "../../../CheatCodeData.txt";


        //PROJECTILES
        public static readonly int ShootOffsetX = 38;
        public static readonly int ShootOffsetY = 20;

        public static readonly int mFireballSpeed = 4;
        public static readonly int mFireballDeleteTime = 200;

        public static readonly int boomerangSpeed = 4;
        public static readonly int boomerangDeleteTime = 120;
        public static readonly int boomerangReverseTime = boomerangDeleteTime/2;
        public static readonly float boomerangRotationSpeed = .2F;

        public static readonly int arrowSpeed = 6;

        public static readonly int bombSpeed = 4;
        public static readonly int bombExplodeTime = 25;
        public static readonly int bombDeleteTime = 70;

        //ENEMIES
        public static readonly float wizzrobeSpeed = 100f;
        public static readonly int wizzrobeShootTime = 2; //Seconds
        public static readonly int wizzrobeChangeDirectionTime = 2; //Seconds
        public static readonly int wizzrobeWaitTime = 1; //Seconds
        public static readonly int wizzrobeHealth = 2;

        public static readonly float goriyaSpeed = 100f;
        public static readonly int goriyaShootTime = 2; //Seconds
        public static readonly int goriyaChangeDirectionTime = 2; //Seconds
        public static readonly int goriyaWaitTime = 1; //Seconds
        public static readonly int goriyaHealth = 2;

        public static readonly float skeletonSpeed = 100f;
        public static readonly int skeletonHealth = 1;
        public static readonly int skeletonChangeDirectionTime = 2; //Seconds

        public static readonly float wallmasterSpeed = 1f;
        public static readonly int wallmasterHealth = 1;
        public static readonly int wallmasterChangeDirectionTime = 80; //Frames


        public static readonly float gelSpeed = 500f;
        public static readonly int gelHealth = 1;
        public static readonly int gelChangeDirectionTime = 80; //Frames


        public static readonly int trapSpeedForward = 6;
        public static readonly int trapSpeedRetreat = 3;
        public static readonly int trapHealth = 3;

        public static readonly double batSpeed = 1;
        public static readonly int batHealth = 1;

        public static readonly float darknutSpeed = 100f;
        public static readonly int darknutHealth = 2;
        public static readonly int darknutChangeDirectionTime = 2; //Seconds

        public static readonly int dragonHealth = 3;


       


        public enum items
        {
            Boomerang,
            Bow,
            Bomb,
            Candle,
            Potion,
            Map,
            Compass,
            Ring,
            Rupee,
            Key
        }
        public enum GameMode
        {
            Normal,
            Gladiator,
            Ghost,
            Boss
        }





    }
}