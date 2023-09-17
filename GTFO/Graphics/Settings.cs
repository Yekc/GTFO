using System.Drawing;

namespace GTFO.Graphics
{
    public static class Settings
    {
        public static Size DisplaySize = new Size(1280, 720);

        public static class SystemColors
        {
            public static PrismAPI.Graphics.Color DesktopForeground = PrismAPI.Graphics.Color.White;
            public static PrismAPI.Graphics.Color DesktopBackground = new(140, 177, 237);
            public static PrismAPI.Graphics.Color ToolbarForeground = PrismAPI.Graphics.Color.White;
            public static PrismAPI.Graphics.Color ToolbarBackgroundLight = new(103, 128, 168);
            public static PrismAPI.Graphics.Color ToolbarBackgroundDark = new(84, 108, 145);
            public static PrismAPI.Graphics.Color WindowForeground = new(20, 20, 20);
            public static PrismAPI.Graphics.Color WindowBackground = new(247, 247, 247);
            public static PrismAPI.Graphics.Color WindowBorder = new(200, 200, 200);
            public static PrismAPI.Graphics.Color ShelfForeground = new(20, 20, 20);
            public static PrismAPI.Graphics.Color ShelfBackgroundLight = new(247, 247, 247);
            public static PrismAPI.Graphics.Color ShelfBackgroundDark = new(222, 222, 222);
        }
    }
}
