using GTFO.Graphics.UI;
using System.Collections.Generic;

namespace GTFO.Applications
{
    public static class Manager
    {
        public static List<App> Applications = new();

        public static void RunApplication(string Identifier)
        {
            foreach (App Application in Applications)
            {
                if (Application.Identifier == Identifier)
                {
                    Application.Run();
                    return;
                }
            }
        }

        public static void InitializeSystemApplications()
        {
            Applications.Add(new System.Console("console"));
        }

        public abstract class App
        {
            public string Identifier;
            public bool IsRunning = false;

            public abstract void Run();
            public abstract void Kill();

            public App(string Identifier)
            {
                this.Identifier = Identifier;
            }
        }
    }
}
