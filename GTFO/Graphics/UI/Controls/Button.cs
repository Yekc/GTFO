﻿using Cosmos.System;
using PrismAPI.Graphics;
using PrismAPI.Tools.Extentions;
using PrismAPI.UI.Config;
using System;
using System.Drawing;

namespace GTFO.Graphics.UI.Controls
{
    public class Button : Control
    {
        public string Text;
        public bool Center;
        public bool Gradient = false;
        public bool Gradient3D = false;
        public bool Disabled = false;
        public PrismAPI.Graphics.Color GradientColor;

        internal PrismAPI.Graphics.Color BackgroundHover;
        internal PrismAPI.Graphics.Color BackgroundClick;
        internal PrismAPI.Graphics.Color GradientHover;
        internal PrismAPI.Graphics.Color GradientClick;

        public Button(Point Location, Size Size, ushort Radius, string Text, PrismAPI.Graphics.Color Background, PrismAPI.Graphics.Color Foreground, bool Center = false) : base(Location, Size)
        {
            this.Text = Text;
            this.Center = Center;
            this.Radius = Radius;
            this.Background = Background;
            this.Foreground = Foreground;
        }

        public override void Update(Canvas Canvas)
        {
            BackgroundHover = new(Math.Min(Background.R + 20, 255), Math.Min(Background.G + 20, 255), Math.Min(Background.B + 20, 255));
            BackgroundClick = new(Math.Max(Background.R - 40, 0), Math.Max(Background.G - 40, 0), Math.Max(Background.B - 40, 0));
            GradientHover = new(Math.Min(GradientColor.R + 20, 255), Math.Min(GradientColor.G + 20, 255), Math.Min(GradientColor.B + 20, 255));
            GradientClick = new(Math.Max(GradientColor.R - 40, 0), Math.Max(GradientColor.G - 40, 0), Math.Max(GradientColor.B - 40, 0));

            if (!Disabled && MouseEx.IsMouseWithin(Location.X, Location.Y, (ushort)Size.Width, (ushort)Size.Height))
            {
                if (MouseEx.IsClickPressed())
                {
                    Status = CursorStatus.Clicked;
                }
                else
                {
                    Status = CursorStatus.Hovering;
                }
            }
            else
            {
                Status = CursorStatus.Idle;
            }

            if (Gradient || Gradient3D)
            {
                switch (Status)
                {
                    default:
                        for (int I = 0; I < Size.Height; I++)
                        {
                            Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y + I, (ushort)Size.Width, 1, 0, PrismAPI.Graphics.Color.Lerp(Background, GradientColor, 1.0f / Size.Height * I));
                        }

                        if (Gradient3D)
                        {
                            Kernel.Canvas.DrawLine(Location.X, Location.Y, Location.X, Location.Y + Size.Height, new(Math.Max(Background.R - 40, 0), Math.Max(Background.G - 40, 0), Math.Max(Background.B - 40, 0)));
                            Kernel.Canvas.DrawLine(Location.X, Location.Y + Size.Height, Location.X + Size.Width, Location.Y + Size.Height, new(Math.Max(Background.R - 40, 0), Math.Max(Background.G - 40, 0), Math.Max(Background.B - 40, 0)));
                            Kernel.Canvas.DrawLine(Location.X + Size.Width, Location.Y, Location.X + Size.Width, Location.Y + Size.Height, new(Math.Max(Background.R - 40, 0), Math.Max(Background.G - 40, 0), Math.Max(Background.B - 40, 0)));
                        }

                        Kernel.Canvas.DrawString(Center ? Location.X + 1 + (Size.Width / 2) : Location.X + 1, Center ? Location.Y + (Size.Height / 2) - 10 : Location.Y, Text, default, Foreground, Center);
                        break;
                    case CursorStatus.Hovering:
                        for (int I = 0; I < Size.Height; I++)
                        {
                            Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y + I, (ushort)Size.Width, 1, 0, PrismAPI.Graphics.Color.Lerp(BackgroundHover, GradientHover, 1.0f / Size.Height * I));
                        }

                        if (Gradient3D)
                        {
                            Kernel.Canvas.DrawLine(Location.X, Location.Y, Location.X, Location.Y + Size.Height, new(Math.Max(BackgroundHover.R - 40, 0), Math.Max(BackgroundHover.G - 40, 0), Math.Max(BackgroundHover.B - 40, 0)));
                            Kernel.Canvas.DrawLine(Location.X, Location.Y + Size.Height, Location.X + Size.Width, Location.Y + Size.Height, new(Math.Max(BackgroundHover.R - 40, 0), Math.Max(BackgroundHover.G - 40, 0), Math.Max(BackgroundHover.B - 40, 0)));
                            Kernel.Canvas.DrawLine(Location.X + Size.Width, Location.Y, Location.X + Size.Width, Location.Y + Size.Height, new(Math.Max(BackgroundHover.R - 40, 0), Math.Max(BackgroundHover.G - 40, 0), Math.Max(BackgroundHover.B - 40, 0)));
                        }

                        Kernel.Canvas.DrawString(Center ? Location.X + 1 + (Size.Width / 2) : Location.X + 1, Center ? Location.Y + (Size.Height / 2) - 10 : Location.Y, Text, default, Foreground, Center);
                        break;
                    case CursorStatus.Clicked:
                        for (int I = 0; I < Size.Height; I++)
                        {
                            Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y + I, (ushort)Size.Width, 1, 0, PrismAPI.Graphics.Color.Lerp(BackgroundClick, GradientClick, 1.0f / Size.Height * I));
                        }

                        if (Gradient3D)
                        {
                            Kernel.Canvas.DrawLine(Location.X, Location.Y, Location.X, Location.Y + Size.Height, new(Math.Max(BackgroundClick.R - 40, 0), Math.Max(BackgroundClick.G - 40, 0), Math.Max(BackgroundClick.B - 40, 0)));
                            Kernel.Canvas.DrawLine(Location.X, Location.Y + Size.Height, Location.X + Size.Width, Location.Y + Size.Height, new(Math.Max(BackgroundClick.R - 40, 0), Math.Max(BackgroundClick.G - 40, 0), Math.Max(BackgroundClick.B - 40, 0)));
                            Kernel.Canvas.DrawLine(Location.X + Size.Width, Location.Y, Location.X + Size.Width, Location.Y + Size.Height, new(Math.Max(BackgroundClick.R - 40, 0), Math.Max(BackgroundClick.G - 40, 0), Math.Max(BackgroundClick.B - 40, 0)));
                        }

                        Kernel.Canvas.DrawString(Center ? Location.X + 1 + (Size.Width / 2) : Location.X + 1, Center ? Location.Y + (Size.Height / 2) - 10 : Location.Y, Text, default, Foreground, Center);
                        break;
                }
            }
            else
            {
                switch (Status)
                {
                    default:
                        Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y, (ushort)Size.Width, (ushort)Size.Height, Radius, Background);
                        Kernel.Canvas.DrawString(Center ? Location.X + 1 + (Size.Width / 2) : Location.X + 1, Center ? Location.Y + (Size.Height / 2) - 10 : Location.Y, Text, default, Foreground, Center);
                        break;
                    case CursorStatus.Hovering:
                        Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y, (ushort)Size.Width, (ushort)Size.Height, Radius, BackgroundHover);
                        Kernel.Canvas.DrawString(Center ? Location.X + 1 + (Size.Width / 2) : Location.X + 1, Center ? Location.Y + (Size.Height / 2) - 10 : Location.Y, Text, default, Foreground, Center);
                        break;
                    case CursorStatus.Clicked:
                        Kernel.Canvas.DrawFilledRectangle(Location.X, Location.Y, (ushort)Size.Width, (ushort)Size.Height, Radius, BackgroundClick);
                        Kernel.Canvas.DrawString(Center ? Location.X + 1 + (Size.Width / 2) : Location.X + 1, Center ? Location.Y + (Size.Height / 2) - 10 : Location.Y, Text, default, Foreground, Center);
                        break;
                }
            }
        }
    }
}
