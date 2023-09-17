using Cosmos.System;
using PrismAPI.Graphics;
using PrismAPI.Tools.Extentions;
using PrismAPI.UI.Config;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GTFO.Graphics.UI
{
    public static class WindowManager
    {
        public static List<Window> Windows = new();
        internal static bool IsDragging = false;

        public static void Update(Canvas Canvas)
        {
            foreach (Window W in Windows)
            {
                if (MouseManager.MouseState != MouseState.Left)
                {
                    Mouse.Cursor = 0;

                    IsDragging = false;
                    W.IsMoving = false;
                    W.IsResizing = false;

                    W.CloseButton.Disabled = false;
                }


                //Move
                if (MouseEx.IsMouseWithin(W.Location.X, W.Location.Y - 20, (ushort)(W.Size.Width - 28), 20) && !W.IsMoving && !IsDragging)
                {
                    Windows.Remove(W);
                    Windows.Insert(Windows.Count, W);

                    W.ILocation.X = (int)MouseManager.X - W.Location.X;
                    W.ILocation.Y = (int)MouseManager.Y - W.Location.Y;
                    IsDragging = true;
                    W.IsMoving = true;
                }

                if (W.IsMoving)
                {
                    Mouse.Cursor = 1;
                    W.CloseButton.Disabled = true;

                    W.Location.X = (int)MouseManager.X - W.ILocation.X;
                    W.Location.Y = (int)MouseManager.Y - W.ILocation.Y;
                }


                //Resize
                if (W.IsResizeable && MouseEx.IsMouseWithin(W.Location.X + W.Size.Width - 8, W.Location.Y + W.Size.Height - 8, 8, 8) && !W.IsResizing && !IsDragging)
                {
                    Windows.Remove(W);
                    Windows.Insert(Windows.Count, W);

                    IsDragging = true;
                    W.IsResizing = true;
                }

                if (W.IsResizing)
                {
                    Mouse.Cursor = 2;
                    W.CloseButton.Disabled = true;

                    if (MouseEx.IsClickPressed())
                    {
                        W.ILocation.X = (int)MouseManager.X - W.Location.X;
                        W.ILocation.Y = (int)MouseManager.Y - W.Location.Y;

                        W.Size.Width = Math.Min(Math.Max(W.ILocation.X, W.MinSize.Width), W.MaxSize.Width);
                        W.Size.Height = Math.Min(Math.Max(W.ILocation.Y, W.MinSize.Height), W.MaxSize.Height);
                    }
                }


                W.Update(Canvas);
            }
        }

        public class Window : Control
        {
            public string Text;
            public bool IsResizeable = true;
            public bool MinimizeButton = true;
            public Size MaxSize = new Size(int.MaxValue, int.MaxValue);
            public Size MinSize = new Size(100, 20);
            public Action OnClose;

            internal bool IsMoving;
            internal bool IsResizing;
            internal Point ILocation = new();
            internal Size ISize = new();

            public readonly List<Control> ShelfControls;
            public readonly List<Control> Controls;
            private readonly Controls.Gradient TitleShelf;
            private readonly Controls.Panel WindowBody;
            internal readonly Controls.Button CloseButton;

            public Window(Point Location, Size Size, string Text) : base(Location, Size)
            {
                ShelfControls = new();
                Controls = new();

                TitleShelf = new(Location, new Size(Size.Width, 20), Settings.SystemColors.ShelfBackgroundLight, Settings.SystemColors.ShelfBackgroundDark);
                WindowBody = new(new Point(Location.X, Location.Y + 20), new Size(Size.Width, Size.Height - 20), Settings.SystemColors.WindowBackground, 0);
                CloseButton = new(new Point(Location.X + Size.Width - 28, Location.Y - 20), new Size(27, 20), 0, string.Empty, new(240, 101, 101), Settings.SystemColors.ShelfBackgroundLight);
                CloseButton.Gradient3D = true;
                CloseButton.GradientColor = new(200, 61, 61);
                CloseButton.OnClick = new((int _, int _, MouseState _) => { Close(); });

                ShelfControls.Add(CloseButton);

                this.Location = Location;
                this.Size = Size;
                this.Text = Text;
            }

            internal static void Process(int XOffset, int YOffset, List<Control> Controls, Canvas Target, ConsoleKeyInfo? Key)
            {
                foreach (Control C in Controls)
                {
                    if (!C.IsEnabled) continue;

                    if (MouseEx.IsMouseWithin(XOffset + C.Location.X, YOffset + C.Location.Y, (ushort)C.Size.Width, (ushort)C.Size.Height))
                    {
                        C.Status = (MouseManager.MouseState != MouseState.None) ? CursorStatus.Clicked : CursorStatus.Hovering;

                        if (MouseManager.MouseState == MouseState.None && MouseManager.LastMouseState != MouseState.None)
                        {
                            C.OnClick(XOffset - (int)MouseManager.X, YOffset - (int)MouseManager.Y, MouseManager.LastMouseState);
                        }
                    }
                    else
                    {
                        C.Status = CursorStatus.Idle;
                    }

                    if (Key != null)
                    {
                        C.OnKey(Key.Value);
                    }

                    C.Update(Target);
                }
            }

            public override void Update(Canvas Canvas)
            {
                ConsoleKeyInfo? Key = KeyboardEx.ReadKey();

                Process(0, 0, ShelfControls, TitleShelf, Key);
                Process(0, 0, Controls, WindowBody, Key);

                TitleShelf.Location = new Point(Location.X, Location.Y - 20);
                TitleShelf.Size = new Size(Size.Width, 20);
                WindowBody.Location = Location;
                WindowBody.Size = Size;
                CloseButton.Location = new Point(Location.X + Size.Width - 28, Location.Y - 20);

                TitleShelf.Update(Kernel.Canvas);
                WindowBody.Update(Kernel.Canvas);
                CloseButton.Update(Kernel.Canvas);

                //Close Button
                Kernel.Canvas.DrawImage(CloseButton.Location.X + (CloseButton.Size.Width / 2) - 3, CloseButton.Location.Y + (CloseButton.Size.Height / 2) - 4, Assets.Manager.Close);

                //Shelf Divider
                Kernel.Canvas.DrawLine(Location.X, Location.Y, Location.X + Size.Width, Location.Y, Settings.SystemColors.WindowBorder);

                //Window Border
                Kernel.Canvas.DrawRectangle(Location.X - 1, Location.Y - 21, (ushort)(Size.Width + 1), (ushort)(Size.Height + 21), 0, Settings.SystemColors.WindowBorder);

                //Window Title
                Kernel.Canvas.DrawString(Location.X + 1, Location.Y - 20, Text, default, Settings.SystemColors.ShelfForeground, false);

                //Resize Box
                if (IsResizeable)
                {
                    Kernel.Canvas.DrawFilledRectangle(Location.X + Size.Width - 8, Location.Y + Size.Height - 8, 8, 8, 0, Settings.SystemColors.ShelfBackgroundLight);
                    Kernel.Canvas.DrawRectangle(Location.X + Size.Width - 8, Location.Y + Size.Height - 8, 8, 8, 0, Settings.SystemColors.WindowBorder);
                }
            }

            public void Close()
            {
                Windows.Remove(this);
            }
        }
    }
}
