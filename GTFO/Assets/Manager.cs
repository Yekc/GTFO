using IL2CPU.API.Attribs;
using PrismAPI.Graphics;
using System;

namespace GTFO.Assets
{
    public static class Manager
    {
        [ManifestResourceStream(ResourceName = "GTFO.Assets.mouse.bmp")] static byte[] MouseSource;
        [ManifestResourceStream(ResourceName = "GTFO.Assets.mouse_click.bmp")] static byte[] MouseClickSource;
        [ManifestResourceStream(ResourceName = "GTFO.Assets.mouse_move.bmp")] static byte[] MouseMoveSource;
        [ManifestResourceStream(ResourceName = "GTFO.Assets.mouse_move_click.bmp")] static byte[] MouseMoveClickSource;
        [ManifestResourceStream(ResourceName = "GTFO.Assets.mouse_resize.bmp")] static byte[] MouseResizeSource;
        [ManifestResourceStream(ResourceName = "GTFO.Assets.mouse_resize_click.bmp")] static byte[] MouseResizeClickSource;
        [ManifestResourceStream(ResourceName = "GTFO.Assets.close.bmp")] static byte[] CloseSource;

        public static Canvas Mouse;
        public static Canvas MouseClick;
        public static Canvas MouseMove;
        public static Canvas MouseMoveClick;
        public static Canvas MouseResize;
        public static Canvas MouseResizeClick;
        public static Canvas Close;

        public static void Load()
        {
            Mouse = Image.FromBitmap(MouseSource, false);
            MouseClick = Image.FromBitmap(MouseClickSource, false);
            MouseMove = Image.FromBitmap(MouseMoveSource, false);
            MouseMoveClick = Image.FromBitmap(MouseMoveClickSource, false);
            MouseResize = Image.FromBitmap(MouseResizeSource, false);
            MouseResizeClick = Image.FromBitmap(MouseResizeClickSource, false);
            Close = Image.FromBitmap(CloseSource, false);

            Console.WriteLine("[GTFO] Loaded Embedded Resources");
        }
    }
}
