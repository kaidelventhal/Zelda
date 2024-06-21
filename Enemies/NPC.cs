using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.RoomRoomObjects;
namespace Zelda.Enemies;

public class NPC : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    private int currentFrame = 0;
    private int xPosition;
    private int yPosition;
    private bool showDialogue = false;
    private string dialogueText = string.Empty;
    public NPC(Game1 game, int xPosition, int yPosition)
    {
        this.game = game;
        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle(240, 60, 15, 17);
        position.X = positionRectangle.X;
        position.X = positionRectangle.Y;

    }

    public void ShowDialogue(string text)
    {
        showDialogue = true;
        dialogueText = text;
    }
    public void HideDialogue()
    {
        showDialogue = false;
    }
    public virtual void Update()
    {
        GameTime gameTime = Game1.GlobalGameTime;

        if (MainCharacterState.DestinationRectangle.Intersects(positionRectangle))
        {

            ShowDialogue("Hello Hero Please Save Us");
        }
        if (!MainCharacterState.DestinationRectangle.Intersects(positionRectangle))
        {
            HideDialogue();
        }
        CheckBounds();
        //UpdateAnimation();


    }

    private void UpdateAnimation()
    {
        yPosition = 271;
        if (currentFrame % 60 > 30)
        {
            xPosition = 232;
        }
        else if (currentFrame % 60 < 30)
        {
            xPosition = 258;
        }
        currentFrame++;
        sourceRectangle = new Rectangle(xPosition, yPosition, 20, 12);
    }
    private void CheckBounds()
    {
        if (CollisionHandler.hitsBoundry(game, positionRectangle))
        {
            direction = -direction;
        }
    }


    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.DungeonEnemies, positionRectangle, sourceRectangle, Color.White);
        if (showDialogue)
        {
            Vector2 dialoguePosition = new Vector2(100, game.GraphicsDevice.Viewport.Height - 50);
            game.SpriteBatch.DrawString(game.DialogueFont, dialogueText, dialoguePosition, Color.White);
        }
    }

   }
