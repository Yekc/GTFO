using GTFO.Graphics.UI.Controls;

namespace GTFO.Graphics
{
    public static class Toolbar
    {
        static Gradient Container = new(new System.Drawing.Point(0, 0), new System.Drawing.Size((ushort)Settings.DisplaySize.Width, 24), Settings.SystemColors.ToolbarBackgroundLight, Settings.SystemColors.ToolbarBackgroundDark);

        public static void Draw()
        {
            Container.Update(Kernel.Canvas);
            Kernel.Canvas.DrawLine(0, 24, Settings.DisplaySize.Width, 24, Settings.SystemColors.ToolbarForeground);
        }
    }
}
