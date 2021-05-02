using System;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    public static class CommandLoop
    {
        public static void Run()
        {
            ListProjects();
            Console.ReadLine();
        }

        private static void ListProjects()
        {
            Settings settings = LoadSettings.Run();

            Project[] projects = GTDDesk_Core.ListProjects.Run(settings);
            Display.ProjectsTable(projects);
        }
    }
}
