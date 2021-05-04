using System;
using System.Collections.Generic;
using System.IO;
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
        /// Determines the longest line in the text, given the divider
        /// </summary>
        public static int MaxLineLength(this string text, char divider)
        {
            if (text == null)
                return 0;

            return text.Split(divider).Max(line => line.Length);
        }
    }
}
