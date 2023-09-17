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

            CreateWindowButton = new(new Point(400, 1), new Size(150, 18), 2, "Create Window", Graphics.Settings.SystemColors.ShelfBackgroundDark, Graphics.Settings.SystemColors.ShelfForeground, true);
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
