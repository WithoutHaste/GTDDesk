using System;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    public static class CommandLoop
    {
        private const string DOCUMENTATION_LOCATION = "https://github.com/WithoutHaste/GTDDesk";

        public static void Run()
        {
            try
            {
                ListProjects();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"See {DOCUMENTATION_LOCATION} for documentation");
            }
            Console.ReadLine();
        }

        private static void ListProjects()
        {
            Settings settings = GetSettings();

            Project[] projects = GTDDesk_Core.ListProjects.Run(settings);
            Display.ProjectsTable(projects);
        }

        private static Settings GetSettings()
        {
            return new Settings()
            {
                Directory = Configuration.Directory,
                IncludeSubDirectories = Configuration.IncludeSubDirectories
            };
        }
    }
}
