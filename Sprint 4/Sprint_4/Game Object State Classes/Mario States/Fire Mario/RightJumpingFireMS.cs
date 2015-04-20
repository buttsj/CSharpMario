﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightJumpingFireMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
       

        public RightJumpingFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightJumpingMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightJumpingSmallMS(mario));
        }
        public void Up()
        {
            mario.position.Y--;
        }
        public void Down()
        {
            mario.state = new RightIdleFireMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftJumpingFireMS(mario);
        }
        public void GoRight()
        {
            mario.position.X++;
        }
        public void Idle()
        {
            mario.state = new RightIdleFireMS(mario);
        }
        public void Land()
        {
            mario.state = new RightMovingFireMS(mario);
        }
        public void MakeBigMario()
        {
            mario.state = new RightJumpingBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new RightJumpingSmallMS(mario);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeFireballMario()
        {
            // null
        }
        public void MakeNinjaMario()
        {

        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Flip() { }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}
