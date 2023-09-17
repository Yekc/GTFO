using System.Drawing;
using static GTFO.Graphics.UI.WindowManager;

namespace GTFO.Applications.System
{
    public class Console : Manager.App
    {
        public Window MainWindow = null!;

        public Console(string Identifier) : base(Identifier)
        {
            this.Identifier = Identifier;
        }

        public override void Run()
        {
            IsRunning = true;

            MainWindow = new(new Point(100, 100), new Size(600, 400), "Console");
            MainWindow.Parent = this;
            Windows.Add(MainWindow);
        }

        public override void Kill()
        {
            IsRunning = false;
        }
    }
}
