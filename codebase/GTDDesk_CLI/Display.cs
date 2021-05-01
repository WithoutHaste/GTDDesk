using System;
using System.Linq;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    public static class Display
    {
        private const char ROW_DIVIDER = '-';

        public static void ProjectsTable(Project[] projects)
        {
            int labelMaxWidth = projects.Max(p => p.Label.Length);
            int taskMaxWidth = GetTaskMaxWidth(projects);

            Console.WriteLine($"| {"Projects".PadRight(labelMaxWidth)} | {"Next Task".PadRight(taskMaxWidth)} |");
            Console.WriteLine($"| {new String(ROW_DIVIDER, labelMaxWidth)} | {new String(ROW_DIVIDER, taskMaxWidth)} |");

            foreach (Project project in projects)
            {
                string[] taskLines = project.Tasks[0].Split("\n");
                Console.WriteLine($"| {project.Label.PadRight(labelMaxWidth)} | {taskLines[0].PadRight(taskMaxWidth)} |");
                for (int i = 1; i < taskLines.Length; i++)
                {
                    Console.WriteLine($"| {new String(' ', labelMaxWidth)} | {taskLines[i].PadRight(taskMaxWidth)} |");
                }
            }
        }

        private static int GetTaskMaxWidth(Project[] projects)
        {
            return projects.Max(project => project.Tasks[0].Split("\n").Max(line => line.Length));
        }
    }
}
