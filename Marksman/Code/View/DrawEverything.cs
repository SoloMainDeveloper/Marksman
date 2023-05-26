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
            switch (Main.State)
            {
                case GameState.SplashScreen:
                    SplashScreenDraw(spriteBatch);
                    break;
                case GameState.Menu:
                    MenuDraw(gameTime, spriteBatch);
                    break;
                case GameState.Levels:
                    LevelsDraw(gameTime, spriteBatch);
                    break;
                case GameState.Game:
                    ShootModeDraw(gameTime, spriteBatch);
                    break;
                case GameState.Shop:
                    ShopDraw(gameTime, spriteBatch);
                    break;
            }
        }

        private static void SplashScreenDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textures.SplashScreenBackground, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Textures.FontHead, "Нажмите Enter, чтобы продолжить", new(1270, 1000), SplashScreen.color);
        }

        private static void MenuDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textures.MenuBackground, Vector2.Zero, Color.White);
            foreach (var component in Menu.GameComponents)
                component.Draw(gameTime, spriteBatch);
        }

        private static void ShopDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textures.MenuBackground, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Textures.FontHead, $"Монеты: {Main.Money}", new(250, 45), Color.Black );
            foreach (var component in Shop.Options)
                component.Draw(gameTime, spriteBatch);
        }

        private static void LevelsDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textures.MenuBackground, Vector2.Zero, Color.White);
            foreach (var button in Levels.LevelButtons)
                button.Draw(gameTime, spriteBatch);
        }

        private static void ShootModeDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var notebookFont = Textures.NotebookFont;
            var notebook = Textures.Notebook;
            var centerX = Main.CenterX;
            var posXtarget = centerX - Textures.ShootTarget.Width / 2;
            var posXaimer = centerX - Textures.ShootAimer.Width / 2;
            spriteBatch.Draw(Textures.CurrentBackground, Vector2.Zero, Color.White);
            spriteBatch.Draw(Textures.ShootTarget, new Rectangle(posXtarget, 10, Textures.ShootTarget.Width, Textures.ShootTarget.Height), Color.White);
            spriteBatch.Draw(Textures.ShootAimer, new Rectangle(posXaimer, 1080 - Textures.ShootAimer.Height, Textures.ShootAimer.Width, Textures.ShootAimer.Height), Color.White);

            var noteColor = Color.DarkBlue;
            spriteBatch.Draw(notebook, new Rectangle(1510, 10, notebook.Width, notebook.Height), Color.White);
            //spriteBatch.DrawString(notebookFont, $"Дистанция  {ShootMode.Distance}м", new(centerX - 140, 5), Color.White);
            spriteBatch.DrawString(notebookFont, $"Level: {Main.Level}", new(1595, 45), Color.Green);
            spriteBatch.DrawString(notebookFont, $"Дистанция: {ShootMode.Distance}м", new(1595, 70), noteColor);
            spriteBatch.DrawString(notebookFont, $"Ветер: {ShootMode.WindPowerX}м/с", new(1595, 103), noteColor);
            spriteBatch.DrawString(notebookFont, $"Направление ветра:", new(1595, 136), noteColor);
            spriteBatch.DrawString(notebookFont, $"{ShootMode.GetDirectionText()}", new(1595, 169), noteColor);

            if (ShootMode.ShotsDone != 0)
            {
                spriteBatch.DrawString(notebookFont, "Последний выстрел:", new(1595, 202), Color.Red);
                spriteBatch.DrawString(notebookFont, $"Откл. {ShootMode.GetOffsetTextX()}: {Math.Abs(ShootMode.LastShotOffsetX)}см", new(1595, 235), Color.Red);
                spriteBatch.DrawString(notebookFont, $"Откл. {ShootMode.GetOffsetTextY()}: {Math.Abs(ShootMode.LastShotOffsetY)}см", new(1595, 268), Color.Red);
                spriteBatch.DrawString(notebookFont, $"От центра: {ShootMode.LastShotDistance}см", new(1595, 301), Color.Red);
                spriteBatch.DrawString(notebookFont, $"Оценка: {ShootMode.GetMark()}", new(1595, 334), Color.Red);
            }

            spriteBatch.Draw(Textures.ShootBulletInfo, new Rectangle(20, 120, notebook.Width, notebook.Height), Color.White);
            spriteBatch.Draw(Textures.ShootBulletInfo, new Rectangle(20, 580, notebook.Width, notebook.Height), Color.White);
            DrawBulletInfoHorizontal(gameTime, spriteBatch);
            DrawBulletInfoVertical(gameTime, spriteBatch);

            spriteBatch.DrawString(Textures.FontHead, ShootMode.GetSign(ShootMode.dx) + ShootMode.dx, ShootMode.GetOffsetTextPosX(), Color.White);
            spriteBatch.DrawString(Textures.FontHead, ShootMode.GetSign(ShootMode.dy) + ShootMode.dy, ShootMode.GetOffsetTextPosY(), Color.White);
            foreach (var button in ShootMode.Buttons)
                button.Draw(gameTime, spriteBatch);
            var i = 0;
            foreach (var shot in ShootMode.ShotsPos)
                spriteBatch.Draw(Textures.Shots[i++ % 6], shot, Color.White);
        }

        private static void DrawBulletInfoHorizontal(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Textures.NotebookFont, "Снос по X", new(145, 210), Color.DarkBlue);
            spriteBatch.DrawString(Textures.NotebookFont, $"Ветер   {ShootMode.WindPowerX} м/с", new(145, 235), Color.DarkBlue);
            spriteBatch.DrawString(Textures.NotebookFont, "Дист. м  Снос см", new(145, 260), Color.DarkBlue);
            for (var i = 1; i < 9; i++)
            {
                var dist = i * 50;
                spriteBatch.DrawString(Textures.NotebookFont, $"{dist}", new(145, 260 + i * 25), Color.DarkBlue);
                spriteBatch.DrawString(Textures.NotebookFont, $"{GunsInfo.offsetXWind308[(ShootMode.WindPowerX, dist)]}", new(270, 260 + i * 25), Color.DarkBlue);
            }
        }

        private static void DrawBulletInfoVertical(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Textures.NotebookFont, "Снос по Y", new(145, 670), Color.DarkBlue);
            spriteBatch.DrawString(Textures.NotebookFont, "Дист. м  Снос см", new(145, 695), Color.DarkBlue);
            for (var i = 1; i < 9; i++)
            {
                var dist = i * 50;
                spriteBatch.DrawString(Textures.NotebookFont, $"{dist}", new(145, 695 + i * 25), Color.DarkBlue);
                spriteBatch.DrawString(Textures.NotebookFont, $"{GunsInfo.offsetY150m308[dist]}", new(270, 695 + i * 25), Color.DarkBlue);
            }
        }
    }
}
