using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    public static class CoreExtensions
    {
        public static string FirstTask(this Project project)
        {
            return project.Tasks.FirstOrDefault();
        }

        /// <summary>
        /// Determines the longest line in the text, dividing on EndLine characters
        /// </summary>
        public static int MaxLineLength(this string multiLineText)
        {
            if (multiLineText == null)
                return 0;

            return multiLineText.Split("\n").Max(line => line.Length);
        }
    }
}
