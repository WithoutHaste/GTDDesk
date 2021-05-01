using System;
using System.Collections.Generic;
using System.IO;

namespace GTDDesk_Core
{
    public static class ListProjects
    {
        public static string[] Run(Settings settings)
        {
            string directory = settings.Directory;
            ValidateDirectory(directory);

            List<string> files = new List<string>();
            SearchDirectory(directory, ref files);
            CleanPaths(directory, ref files);
            return files.ToArray();
        }

        private static void CleanPaths(string prefix, ref List<string> paths)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                string path = paths[i];
                if (path.StartsWith(prefix))
                    paths[i] = path.Substring(prefix.Length);
            }
        }

        private static void SearchDirectory(string directory, ref List<string> foundFiles)
        {
            foundFiles.AddRange(Directory.GetFiles(directory, "*.txt"));
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
