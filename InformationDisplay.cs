using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Zelda
{
    public class InformationDisplay : ISprite
    {
        private Game1 game;
        private Texture2D texture;
        private Rectangle HUDSource;
        private Rectangle HUDDestination;
        private Rectangle InventorySource;
        private Rectangle InventoryDestination;
        private Rectangle DungeonSource;
        private Rectangle DungeonDestination;
        private Rectangle bottomInfoSource;
        private Rectangle bottomInfoDestination;
        private Rectangle swordSource;
        private Rectangle swordDestination;

        private Rectangle heart;
        private Rectangle[] heartDestination;
        private Rectangle[] locationMap;
        private Dictionary<int,Rectangle> visitedMap;
        private Rectangle visitedSource;
        private Rectangle locationSource;
        private Dictionary<Constants.items,Rectangle> currentItemSource;
        private Dictionary<Constants.items, Rectangle> itemInventroyDestinations;
        private Rectangle weaponDestination;
        private Rectangle weaponInventoryDestination;
        private Rectangle hideMapInventoryDestination;
        private Rectangle hideCompassInventoryDestination;
        private Rectangle hidemapSource;
        private Rectangle hidemapDestination;
        private Rectangle[] selectionSource;
        private Rectangle[] compassSource;
        private int frame;
        public InformationDisplay(Game1 game)
        {
            this.game = game;
            this.texture = game.Textures.PauseScreen;
            HUDSource = new Rectangle(259, 12, 254, 52);
            InventorySource = new Rectangle(2, 12, 254, 86);
            DungeonSource = new Rectangle(259, 113, 254, 86);
            HUDDestination = new Rectangle(0, 0, Constants.screenWidth, Constants.screenWidth / HUDSource.Width * HUDSource.Height);
            DungeonDestination = new Rectangle(0, HUDDestination.Height, Constants.screenWidth, Constants.screenWidth / DungeonSource.Width * DungeonSource.Height);
            InventoryDestination = new Rectangle(0, HUDDestination.Height+DungeonDestination.Height, Constants.screenWidth, Constants.screenWidth / InventorySource.Width * InventorySource.Height);
            bottomInfoSource = new Rectangle(218, 136, 4, 4);
            bottomInfoDestination = new Rectangle(0, InventoryDestination.Y + InventoryDestination.Height, Constants.screenWidth, InventorySource.Height);
            
            heart = new Rectangle(645, 117, 7, 8);
            heartDestination = new Rectangle[10];
            heartDestination[0] = new Rectangle(875, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[1] = new Rectangle(900, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[2] = new Rectangle(925, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[3] = new Rectangle(950, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[4] = new Rectangle(975, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[5] = new Rectangle(1000, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[6] = new Rectangle(1025, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[7] = new Rectangle(1050, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[8] = new Rectangle(1075, 130, heart.Width * 3, heart.Height * 3);
            heartDestination[9] = new Rectangle(1100, 130, heart.Width * 3, heart.Height * 3);
            swordSource = new Rectangle(555, 137, 7, 16);
            swordDestination = new Rectangle(727,88,swordSource.Width*5,swordSource.Height*5);
            locationMap = new Rectangle[18];
            locationMap[0] = new Rectangle(148,182,14,10);
            locationMap[1] = new Rectangle(191, 182, 14, 10);
            locationMap[2] = new Rectangle(225, 182, 14, 10);
            locationMap[3] = new Rectangle(191, 166, 14, 10);
            locationMap[4] = new Rectangle(148, 150, 14, 10);
            locationMap[5] = new Rectangle(191, 150, 14, 10);
            locationMap[6] = new Rectangle(225, 150, 14, 10);
            locationMap[7] = new Rectangle(104, 134, 14, 10);
            locationMap[8] = new Rectangle(148, 134, 14, 10);
            locationMap[9] = new Rectangle(191, 134, 14, 10);
            locationMap[10] = new Rectangle(225, 134, 14, 10);
            locationMap[11] = new Rectangle(268, 134, 14, 10);
            locationMap[12] = new Rectangle(191, 118, 14, 10);
            locationMap[13] = new Rectangle(268, 118, 14, 10);
            locationMap[14] = new Rectangle(306, 118, 14, 10);
            locationMap[15] = new Rectangle(148, 102, 14, 10);
            locationMap[16] = new Rectangle(191, 102, 14, 10);
            locationSource = new Rectangle(113, 149, 14, 10);

            currentItemSource = new Dictionary<Constants.items, Rectangle>
            {
                {Constants.items.Bow, new Rectangle(615, 137, 8, 16) },
                {Constants.items.Bomb, new Rectangle(604, 137, 8, 16) },
                {Constants.items.Boomerang,new Rectangle(584, 137, 8, 16) },
                {Constants.items.Candle, new Rectangle(644,137,8,16) },
                {Constants.items.Ring, new Rectangle(549, 158, 8, 11) }
            };
            itemInventroyDestinations = new Dictionary<Constants.items, Rectangle>
            {
                {Constants.items.Bow, new Rectangle(650, 750, swordSource.Width*5, swordSource.Height*5) },
                {Constants.items.Bomb, new Rectangle(725, 750, swordSource.Width*5, swordSource.Height*5) },
                {Constants.items.Boomerang,new Rectangle(800, 750, swordSource.Width*5, swordSource.Height*5) },
                {Constants.items.Candle, new Rectangle(875,750,swordSource.Width * 5, swordSource.Height * 5) },
                {Constants.items.Ring, new Rectangle(950,750,swordSource.Width * 5, swordSource.Height * 5) }
            };

            weaponDestination = new Rectangle(612, 88, swordSource.Width * 5, swordSource.Height * 5);
            hidemapSource = new Rectangle(160,20,20,20);
            hidemapDestination = new Rectangle(90,90,240,115);
            compassSource = new Rectangle[2];
            compassSource[0] = new Rectangle(586, 11, 5, 5);
            compassSource[1] = new Rectangle(592, 11, 5, 5);
            visitedMap = new Dictionary<int, Rectangle>
            {
                { 0, new Rectangle(668, 453, 45, 33) },
                { 1, new Rectangle(720, 453, 45, 33) },
                { 2, new Rectangle(770, 453, 55, 33) },
                { 3, new Rectangle(720, 407, 45, 40) },
                { 4, new Rectangle(668, 374, 55, 33) },
                { 5, new Rectangle(720, 367, 45, 45) },
                { 6, new Rectangle(765, 367, 53, 45) },
                { 7, new Rectangle(600, 330, 55, 45) },
                { 8, new Rectangle(655, 333, 67, 33) },
                { 9, new Rectangle(720, 324, 45, 45) },
                { 10, new Rectangle(765, 330, 55, 45) },
                { 11, new Rectangle(820, 330, 50, 45) },
                { 12, new Rectangle(720, 280, 45, 45) },
                { 13, new Rectangle(820, 284, 60, 48) },
                { 14, new Rectangle(880, 284, 50, 45) },
                { 15, new Rectangle(668, 253, 55, 45) },
                { 16, new Rectangle(720, 253, 45, 45) },
            };
            visitedSource = new Rectangle(360, 131, 10, 10);
            weaponInventoryDestination = new Rectangle(325, 730, swordSource.Width * 5, swordSource.Height * 5);
            hideMapInventoryDestination = new Rectangle(190,290,100,100);
            hideCompassInventoryDestination = new Rectangle(190, 430, 100, 100);
            selectionSource = new Rectangle[2];
            selectionSource[0] = new Rectangle(519,137,16,16);
            selectionSource[1] = new Rectangle(536, 137, 16, 16);
        }

        public void Draw()
        {
            if (game.IsPaused)
            {
                game.SpriteBatch.Draw(texture, InventoryDestination, InventorySource, Color.White);
                game.SpriteBatch.Draw(texture, DungeonDestination, DungeonSource, Color.White);
                game.SpriteBatch.Draw(texture, bottomInfoDestination, bottomInfoSource, Color.White);
                foreach (KeyValuePair<int,Rectangle> entry in visitedMap)
                {
                    game.SpriteBatch.Draw(texture, entry.Value , visitedSource, Color.White);
                }
                game.SpriteBatch.Draw(texture, weaponInventoryDestination, currentItemSource[MainCharacterState.CurrentItem], Color.White);
                if (!MainCharacterState.InventoryItems.ContainsKey(Constants.items.Map))game.SpriteBatch.Draw(texture, hideMapInventoryDestination, hidemapSource, Color.White);
                if (!MainCharacterState.InventoryItems.ContainsKey(Constants.items.Compass)) game.SpriteBatch.Draw(texture, hideCompassInventoryDestination, hidemapSource, Color.White);
                foreach (var r in MainCharacterState.InventoryItems)
                {
                    if (currentItemSource.ContainsKey(r.Key))
                    {
                        game.SpriteBatch.Draw(texture, itemInventroyDestinations[r.Key], currentItemSource[r.Key], Color.White);
                    }
                    
                }
                game.SpriteBatch.Draw(texture, itemInventroyDestinations[MainCharacterState.CurrentItem], selectionSource[frame / 10 % 2],Color.White);

            }
            game.SpriteBatch.Draw(texture,HUDDestination,HUDSource,Color.White);
            //draw hearts
            for(int i= 0; i < MainCharacterState.Health/2; i++)
            {
                game.SpriteBatch.Draw(texture, heartDestination[i], heart, Color.White);
            }
            //draw bomb count
            int bombcount = 0;
            if (MainCharacterState.InventoryItems.ContainsKey(Constants.items.Bomb)){
                bombcount = MainCharacterState.InventoryItems[Constants.items.Bomb];
            }
            game.SpriteBatch.DrawString(game.Textures.CountFont, "X" +bombcount, new Vector2(465, 155), Color.White);
            //draw key count
            game.SpriteBatch.DrawString(game.Textures.CountFont, "X" + MainCharacterState.InventoryItems[Constants.items.Key], new Vector2(465, 122), Color.White);
            //draw Ruppee count
            game.SpriteBatch.DrawString(game.Textures.CountFont, "X" + MainCharacterState.InventoryItems[Constants.items.Rupee], new Vector2(465, 60), Color.White);
            //draw sword
            game.SpriteBatch.Draw(texture, swordDestination, swordSource, Color.White);
            //draw if link has map
            if(!MainCharacterState.InventoryItems.ContainsKey(Constants.items.Map)) game.SpriteBatch.Draw(texture, hidemapDestination, hidemapSource, Color.White);
            if (MainCharacterState.InventoryItems.ContainsKey(Constants.items.Compass)) game.SpriteBatch.Draw(texture, locationMap[14], compassSource[frame/40%2], Color.White);
            //draw map location
            game.SpriteBatch.Draw(texture, locationMap[game.DungeonRooms.CurrentRoom], locationSource, Color.White);
            //draw current weapon
            game.SpriteBatch.Draw(texture, weaponDestination, currentItemSource[MainCharacterState.CurrentItem], Color.White);
        }

        public void Update()
        {
            if (visitedMap.ContainsKey(game.DungeonRooms.CurrentRoom))
            {
                visitedMap.Remove(game.DungeonRooms.CurrentRoom);
            }
            frame++;
        }
    }
}
