using Cosmos.System;
using GTFO.Graphics.UI;
using System;
using System.Drawing;

namespace GTFO.Applications.System
{
    public class Console : Manager.App
    {
        Graphics.UI.Controls.Button CreateWindowButton = null!;

        public Console(string Identifier) : base(Identifier)
        {
            this.Identifier = Identifier;

            CreateWindowButton = new(new Point(400, 2), new Size(125, 18), 2, "Test Window", Graphics.Settings.SystemColors.ShelfBackgroundLight, Graphics.Settings.SystemColors.ShelfForeground, true);
            CreateWindowButton.Gradient3D = true;
            CreateWindowButton.GradientColor = Graphics.Settings.SystemColors.ShelfBackgroundDark;
            CreateWindowButton.OnClick = new((int _, int _, MouseState _) => { CreateWindow(); });
        }

        internal void CreateWindow()
        {
            Random R = new();
            WindowManager.Window W = new(new Point(R.Next(750) + 5, R.Next(400) + 25), new Size(600, 400), "Test Window")
            {
                Parent = this
            };
            WindowManager.Windows.Add(W);
        }

        public override void Run()
        {
            CreateWindowButton.Update(Kernel.Canvas);
        }

        public override void Kill()
        {
            IsRunning = false;
        }
    }
}
