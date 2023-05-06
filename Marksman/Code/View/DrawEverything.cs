using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Marksman
{
    internal class DrawEverything
    {
        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            switch (Main.state)
            {
                case GameState.SplashScreen:
                    SplashScreenDraw(spriteBatch);
                    break;
                case GameState.Menu:
                    MenuDraw(gameTime, spriteBatch);
                    break;
                case GameState.Game:
                    ShootModeDraw(gameTime, spriteBatch);
                    break;
                case GameState.Levels:
                    LevelsDraw(gameTime, spriteBatch);
                    break;
                case GameState.Shop:
                    ShopDraw(gameTime, spriteBatch);
                    break;
            }
        }

        private static void SplashScreenDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SplashScreen.Background, Vector2.Zero, Color.White);
            spriteBatch.DrawString(SplashScreen.Font, "Нажмите Enter, чтобы продолжить", new(1270, 1000), SplashScreen.color);
        }

        private static void MenuDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in Menu.gameComponents)
                component.Draw(gameTime, spriteBatch);
        }

        private static void ShopDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        private static void LevelsDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var button in Levels.levelButtons)
                button.Draw(gameTime, spriteBatch);
        }

        private static void ShootModeDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            ShootMode.targetCenterY = 10 + ShootMode.Target.Height / 2;
            var posXtarget = ShootMode.centerX - ShootMode.Target.Width / 2;
            var posXaimer = ShootMode.centerX - ShootMode.Aimer.Width / 2;
            spriteBatch.Draw(ShootMode.Background, Vector2.Zero, Color.White);
            spriteBatch.Draw(ShootMode.Target, new Rectangle(posXtarget, 10, ShootMode.Target.Width, ShootMode.Target.Height), Color.White);
            spriteBatch.Draw(ShootMode.Aimer, new Rectangle(posXaimer, 1080 - ShootMode.Aimer.Height, ShootMode.Aimer.Width, ShootMode.Aimer.Height), Color.White);

            var noteColor = Color.DarkBlue;
            spriteBatch.Draw(ShootMode.Notebook, new Rectangle(1510, 10, ShootMode.Notebook.Width, ShootMode.Notebook.Height), Color.White);
            spriteBatch.DrawString(ShootMode.NotebookFont, $"Дистанция: {ShootMode.distance}м", new(1595, 70), noteColor);
            spriteBatch.DrawString(ShootMode.NotebookFont, $"Ветер: {ShootMode.windPowerX}м/с", new(1595, 103), noteColor);
            spriteBatch.DrawString(ShootMode.NotebookFont, $"Направление ветра:", new(1595, 136), noteColor);
            spriteBatch.DrawString(ShootMode.NotebookFont, $"{ShootMode.GetDirectionText()}", new(1595, 169), noteColor);
            if (ShootMode.shotsDone != 0)
            {
                spriteBatch.DrawString(ShootMode.NotebookFont, "Последний выстрел:", new(1595, 202), Color.Red);
                spriteBatch.DrawString(ShootMode.NotebookFont, $"Откл. {ShootMode.GetOffsetTextX()}: {Math.Abs(ShootMode.lastShotOffsetX)}см", new(1595, 235), Color.Red);
                spriteBatch.DrawString(ShootMode.NotebookFont, $"Откл. {ShootMode.GetOffsetTextY()}: {Math.Abs(ShootMode.lastShotOffsetY)}см", new(1595, 268), Color.Red);
                spriteBatch.DrawString(ShootMode.NotebookFont, $"От центра: {ShootMode.lastShotDistance}см", new(1595, 301), Color.Red);
                spriteBatch.DrawString(ShootMode.NotebookFont, $"Оценка: {ShootMode.GetMark()}", new(1595, 334), Color.Red);
            }

            spriteBatch.Draw(ShootMode.BulletInfo, new Rectangle(20, 120, ShootMode.Notebook.Width, ShootMode.Notebook.Height), Color.White);
            DrawBulletInfo(gameTime, spriteBatch);

            spriteBatch.DrawString(ShootMode.MainFont, ShootMode.GetSign(ShootMode.dx) + ShootMode.dx, ShootMode.GetOffsetTextPosX(), Color.White);
            spriteBatch.DrawString(ShootMode.MainFont, ShootMode.GetSign(ShootMode.dy) + ShootMode.dy, ShootMode.GetOffsetTextPosY(), Color.White);
            foreach (var button in ShootMode.Buttons)
                button.Draw(gameTime, spriteBatch);
            var i = 0;
            foreach (var shot in ShootMode.shotsPos)
            {
                spriteBatch.Draw(ShootMode.Shots[i % 6], shot, Color.White);
                i++;
            }
        }

        private static void DrawBulletInfo(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var pos = new Vector2(145, 210);
            var info = new List<string>();
            info.Add("Снос по X");
            info.Add($"Ветер   {ShootMode.windPowerX} м/с");
            info.Add("Дист. м  Снос см");
            for (var i = 1; i < 9; i++)
            {
                var dist = i * 50;
                info.Add($"{dist}   {ShootMode.offsetWind308[(ShootMode.windPowerX, dist)]}");
            }
            foreach (var str in info)
            {
                spriteBatch.DrawString(ShootMode.NotebookFont, str, pos, Color.DarkBlue);
                pos += new Vector2(0, 25);
            }
        }
    }
}
