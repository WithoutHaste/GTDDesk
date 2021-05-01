using System;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] projects = ListProjects.Run();
            foreach (string project in projects)
            {
                Console.WriteLine(project);
            }
        }
    }
}
