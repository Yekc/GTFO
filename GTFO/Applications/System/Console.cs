using GTFO.Graphics.UI;
using System.Drawing;
using static GTFO.Graphics.UI.WindowManager;

namespace GTFO.Applications.System
{
    public static class Console
    {
        public static Window MainWindow = null!;

        public static void Run()
        {
            MainWindow = new(new Point(100, 100), new Size(600, 400), "Console");
            Windows.Add(MainWindow);
        }
    }
}
