using System.Drawing;

namespace GTFO.Graphics.UI.Controls
{
    public class Gradient : Control
    {
        public PrismAPI.Graphics.Color GradientColor;

        public Gradient(Point Location, Size Size, PrismAPI.Graphics.Color Background, PrismAPI.Graphics.Color GradientColor) : base(Location, Size)
        {
            this.Background = Background;
            this.GradientColor = GradientColor;
        }

        public override void Update(PrismAPI.Graphics.Canvas Canvas)
        {
            for (int I = 0; I < Size.Height; I++)
            {
                Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y + I, (ushort)Size.Width, 1, 0, PrismAPI.Graphics.Color.Lerp(Background, GradientColor, 1.0f / Size.Height * I));
            }
        }
    }
}
