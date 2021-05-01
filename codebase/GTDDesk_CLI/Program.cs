using System;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = LoadSettings.Run();

            string[] projects = ListProjects.Run(settings);
            foreach (string project in projects)
            {
                Console.WriteLine(project);
            }
        }
    }
}
