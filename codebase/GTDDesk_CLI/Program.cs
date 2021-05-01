using System;
using System.Linq;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = LoadSettings.Run();

            Project[] projects = ListProjects.Run(settings);
            foreach (Project project in projects)
            {
                Console.WriteLine($"Project {project.Label}:");
                Console.WriteLine(project.Tasks.FirstOrDefault());
                Console.WriteLine();
            }
        }
    }
}
