using System;
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
            Applications.Add(new App("console", System.Console.Run));
        }

        public class App
        {
            public string Identifier;
            public Action Run;

            public App(string Identifier, Action Run)
            {
                this.Identifier = Identifier;
                this.Run = Run;
            }
        }
    }
}
