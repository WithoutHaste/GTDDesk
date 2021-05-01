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
            SearchDirectory(directory, ref files);
            Project[] projects = files.Select(file => new Project() { 
                Path = file,
                Label = GetProjectLabelFromPath(file, directory)
            }).ToArray();
            return projects;
        }

        private static string GetProjectLabelFromPath(string path, string homeDirectory)
        {
            return path.CleanPrefix(homeDirectory).CleanSuffix(FILE_EXTENSION);
        }

        private static void SearchDirectory(string directory, ref List<string> foundFiles)
        {
            foundFiles.AddRange(Directory.GetFiles(directory, $"*{FILE_EXTENSION}"));
            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                SearchDirectory(subDirectory, ref foundFiles);
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
