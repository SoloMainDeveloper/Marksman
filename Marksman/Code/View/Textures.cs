using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Marksman
{
    internal class Textures
    {
        public static Dictionary<string, Texture2D> Backgrounds = new()
        {
            { "grass", ShootBackground },
            { "forest", Forest },
            { "sand", Sand }
        };
        public static SpriteFont FontHead = Main.Content.Load<SpriteFont>("SplashFont");

        //splashScreen
        public static Texture2D SplashScreenBackground = Main.Content.Load<Texture2D>("Background");

        //menu
        public static Texture2D MenuBackground = Main.Content.Load<Texture2D>("Assets/MenuBackground");
        public static Texture2D PlayButton = Main.Content.Load<Texture2D>("Assets/MenuControls/PlayButton");
        public static Texture2D QuitButton = Main.Content.Load<Texture2D>("Assets/MenuControls/QuitButton");
        public static Texture2D ShopButton = Main.Content.Load<Texture2D>("Assets/MenuControls/ShopButton");
        public static Texture2D MusicButton = Main.Content.Load<Texture2D>("Assets/MenuControls/MusicButton");

        //shop
        public static Texture2D Sand = Main.Content.Load<Texture2D>("Sand");
        public static Texture2D Forest = Main.Content.Load<Texture2D>("Forest");
        public static Texture2D ForestButton = Main.Content.Load<Texture2D>("Assets/Shop/ForestButton");
        public static Texture2D SandButton = Main.Content.Load<Texture2D>("Assets/Shop/SandButton");
        public static Texture2D ShootBackgroundButton = Main.Content.Load<Texture2D>("Assets/Shop/GrassButton");

        //levels
        public static Texture2D Level = Main.Content.Load<Texture2D>("Assets/Level");
        public static Texture2D Cup = Main.Content.Load<Texture2D>("Assets/Cup");

        //shootMode
        public static SpriteFont NotebookFont = Main.Content.Load<SpriteFont>("Assets/Fonts/NotebookFont");
        public static Texture2D ShootBackground = Main.Content.Load<Texture2D>("Assets/Grass");
        public static Texture2D ShootTarget = Main.Content.Load<Texture2D>("Assets/Target");
        public static Texture2D ShootAimer = Main.Content.Load<Texture2D>("Assets/Aimer");
        public static Texture2D ShootBulletInfo = Main.Content.Load<Texture2D>("Assets/BulletInfo");
        public static Texture2D Notebook = Main.Content.Load<Texture2D>("Assets/Notebook");
        public static Texture2D[] Shots = new Texture2D[6];

        //shootControls
        public static Texture2D RightController = Main.Content.Load<Texture2D>("Assets/GunControls/ButtonRight");
        public static Texture2D LeftController = Main.Content.Load<Texture2D>("Assets/GunControls/ButtonLeft");
        public static Texture2D DownController = Main.Content.Load<Texture2D>("Assets/GunControls/ButtonDown");
        public static Texture2D UpController = Main.Content.Load<Texture2D>("Assets/GunControls/ButtonUp");
        public static Texture2D ResetButton = Main.Content.Load<Texture2D>("Assets/GunControls/ButtonReset");
        public static Texture2D ShootButton = Main.Content.Load<Texture2D>("Assets/GunControls/ButtonShoot");
        public static Texture2D MenuButton = Main.Content.Load<Texture2D>("Assets/MenuControls/ButtonMenu");

        //sounds
        public static Song Switch = Main.Content.Load<Song>("Assets/Sounds/Switch");
        public static Song MainMusic = Main.Content.Load<Song>("Assets/Sounds/GNR");
        public static Song Metallica = Main.Content.Load<Song>("Assets/Sounds/Metallica");
        public static Song SoaD = Main.Content.Load<Song>("Assets/Sounds/SoaD");

        public static Texture2D CurrentBackground { get; set; } = ShootBackground;
    }
}
