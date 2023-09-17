using Sys = Cosmos.System;
using PrismAPI.Hardware.GPU;
using Cosmos.System;
using Cosmos.Core.Memory;
using GTFO.Graphics;
using GTFO.Graphics.UI;

namespace GTFO
{
    public class Kernel : Sys.Kernel
    {
        public static Display Canvas = null!;

        protected override void BeforeRun()
        {
            Assets.Manager.Load();

            Cosmos.HAL.Global.PIT.Wait(1000);

            MouseManager.ScreenWidth = (uint)Settings.DisplaySize.Width;
            MouseManager.ScreenHeight = (uint)Settings.DisplaySize.Height;

            Canvas = Display.GetDisplay((ushort)Settings.DisplaySize.Width, (ushort)Settings.DisplaySize.Height);

            Applications.Manager.InitializeSystemApplications();
        }

        protected override void Run()
        {
            Canvas.Clear(Settings.SystemColors.DesktopBackground);

            Toolbar.Draw();
            Canvas.DrawString(2, 2, $"{Canvas.GetFPS()}", default, Settings.SystemColors.ToolbarForeground);

            Applications.Manager.RunApplication("console");

            WindowManager.Update(Canvas);
            Mouse.Draw();
            Canvas.Update();
            Heap.Collect();
        }
    }
}
