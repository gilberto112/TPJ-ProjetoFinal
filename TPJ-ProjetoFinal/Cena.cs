﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPJ_ProjetoFinal
{
    public class Cena
    {
        // Variáveis
        public SpriteBatch spriteBatch;
        private List<Sprite> spriteList;
        private List<Sprite> backGround;
        int key;
        public static Vector2 collisionPoint;

        // Construtor
        public Cena(SpriteBatch spriteBatch)
        {
            this.SpriteBatch = spriteBatch;
            this.spriteList = new List<Sprite>();
            this.backGround = new List<Sprite>();
        }

        // Update
        public void Update(GameTime gameTime)
        {
            foreach (var sprite in backGround.ToList())
                sprite.Update(gameTime);
            foreach (var sprite in spriteList.ToList())
                sprite.Update(gameTime);
        }

        // Draw
        public void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            foreach (var sprite in backGround.ToList())
                sprite.Draw(gameTime);
            foreach (var sprite in spriteList)
                sprite.Draw(gameTime);
            this.spriteBatch.End();
        }


        // Adiciona uma nova sprite à cena
        public void AddSprite(Sprite sprite)
        {
            this.spriteList.Add(sprite);
            sprite.SetScene(this);
        }

        public void AddBackGround(Sprite sprite)
        {
            this.backGround.Add(sprite);
            sprite.SetScene(this);
        }

        // Remove uma sprite da cena
        public void RemoveSprite(Sprite sprite)
        {
            this.spriteList.Remove(sprite);
        }

        // Deteção de colisões de todas as sprites da cena
        public bool Collides(Sprite sprite, out Sprite collided)
        {
            bool collisionExists = false;
            // Parar "calar" o compilador
            collided = sprite;
            collisionPoint = Vector2.Zero;

            foreach (var s in spriteList)
            {
                if (sprite == s) continue;
                if (sprite.CollidesWith(s, out collisionPoint))
                {
                    collisionExists = true;
                    collided = s;
                    break;
                }
            }
            return collisionExists;
        }

        // Dispose
        public void Dispose()
        {
            foreach (var sprite in spriteList)
                sprite.Dispose();
        }

        // Métodos get/set
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            private set { spriteBatch = value; }
        }
    }
}