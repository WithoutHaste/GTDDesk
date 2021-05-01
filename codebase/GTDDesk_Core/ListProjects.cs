using System;
using System.IO;

namespace GTDDesk_Core
{
    public static class ListProjects
    {
        public static string[] Run(Settings settings)
        {
            string directory = settings.Directory;
            ValidateDirectory(directory);

            return Directory.GetFiles(settings.Directory);
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
