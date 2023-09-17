using Cosmos.System;
using PrismAPI.Graphics;
using PrismAPI.Tools.Extentions;
using System.Drawing;

namespace GTFO.Graphics
{
    public static class Mouse
    {
        public static int Cursor = 0;
        internal static Canvas Image;
        internal static Canvas ImageClick;
        internal static Point Offset;

        public static void Draw()
        {
            switch (Cursor) {
                default:
                    Image = Assets.Manager.Mouse;
                    ImageClick = Assets.Manager.MouseClick;
                    Offset = new(0, 0);
                    break;
                case 1:
                    Image = Assets.Manager.MouseMove;
                    ImageClick = Assets.Manager.MouseMoveClick;
                    Offset = new(-8, -8);
                    break;
                case 2:
                    Image = Assets.Manager.MouseResize;
                    ImageClick = Assets.Manager.MouseResizeClick;
                    Offset = new(-8, -8);
                    break;
            }

            if (MouseEx.IsClickPressed())
            {
                Kernel.Canvas.DrawImage((int)MouseManager.X + Offset.X, (int)MouseManager.Y + Offset.Y, ImageClick);
                return;
            }

            Kernel.Canvas.DrawImage((int)MouseManager.X + Offset.X, (int)MouseManager.Y + Offset.Y, Image);
        }
    }
}
