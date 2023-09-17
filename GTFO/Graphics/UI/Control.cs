using Cosmos.System;
using PrismAPI.Graphics;
using PrismAPI.UI.Config;
using System;
using System.Drawing;

namespace GTFO.Graphics.UI
{
    public abstract class Control : Canvas
    {
        public Action<int, int, MouseState> OnClick;
        public Action<ConsoleKeyInfo> OnKey;

        public Point Location;
        new public Size Size;
        public PrismAPI.Graphics.Color Foreground = Settings.SystemColors.WindowForeground;
        public PrismAPI.Graphics.Color Background = Settings.SystemColors.WindowBackground;
        public ushort Radius = 0;
        public bool IsEnabled = true;

        public CursorStatus Status;

        public abstract void Update(Canvas Canvas);

        public Control(Point Location, Size Size) : base((ushort)Size.Width, (ushort)Size.Height)
        {
            OnClick = new((int _, int _, MouseState _) => { });
            OnKey = new((ConsoleKeyInfo _) => { });

            this.Location = Location;
            this.Size = Size;
        }
    }
}
