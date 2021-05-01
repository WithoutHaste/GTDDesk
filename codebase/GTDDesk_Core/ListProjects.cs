using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using GTDDesk_Core.Internal;

namespace GTDDesk_Core
{
    public static class ListProjects
    {
        private const string FILE_EXTENSION = ".txt";

        public static Project[] Run(Settings settings)
        {
            string directory = settings.Directory;
            ValidateDirectory(directory);

            List<string> files = new List<string>();
            SearchDirectory(directory, ref files, settings.IncludeSubDirectories);
            Project[] projects = LoadProjects(files, directory);
            return projects;
        }

        private static Project[] LoadProjects(List<string> files, string homeDirectory)
        {
            Project[] projects = files.Select(file => new Project()
            {
                Path = file,
                Label = GetProjectLabelFromPath(file, homeDirectory),
                Tasks = LoadTasks(file)
            }).ToArray();
            return projects;
        }

        private static string[] LoadTasks(string fullFileName)
        {
            List<string> tasks = new List<string>();

            string line;
            string task = null;
            using (StreamReader file = new StreamReader(fullFileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line))
                    {
                        if (task == null)
                        {
                            //haven't found the next task yet - do nothing
                        }
                        else
                        {
                            //ending one task, starting another
                            tasks.Add(task);
                            task = null;
                        }
                    }
                    else
                    {
                        task += line + "\n";
                    }
                }
            }

            return tasks.ToArray();
        }

        private static string GetProjectLabelFromPath(string path, string homeDirectory)
        {
            return path.CleanPrefix(homeDirectory).CleanSuffix(FILE_EXTENSION);
        }

        private static void SearchDirectory(string directory, ref List<string> foundFiles, bool includeSubDirectories)
        {
            foundFiles.AddRange(Directory.GetFiles(directory, $"*{FILE_EXTENSION}"));
            if (includeSubDirectories)
            {
                foreach (string subDirectory in Directory.GetDirectories(directory))
                {
                    SearchDirectory(subDirectory, ref foundFiles, includeSubDirectories);
                }
            }
        }

        private static void ValidateDirectory(string directory)
        {
            if (string.IsNullOrEmpty(directory))
                throw new Exception("Directory not found in settings");
            if (!Directory.Exists(directory))
                throw new Exception($"Directory not found: {directory}");
        }
    }
}
