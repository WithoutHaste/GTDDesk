using GTDDesk_Core;

namespace GTDDesk_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = LoadSettings.Run();

            Project[] projects = ListProjects.Run(settings);
            Display.ProjectsTable(projects);
        }
    }
}
