using System.Drawing;

namespace GTFO.Graphics.UI.Controls
{
    public class Panel : Control
    {
        public Panel(Point Location, Size Size, PrismAPI.Graphics.Color Background, ushort Radius) : base(Location, Size)
        {
            this.Background = Background;
            this.Radius = Radius;
        }

        public override void Update(PrismAPI.Graphics.Canvas Canvas)
        {
            Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y, (ushort)Size.Width, (ushort)Size.Height, Radius, Background);
        }
    }
}
