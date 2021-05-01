using System.Collections.Generic;

namespace GTDDesk_Core
{
    internal static class ListExtensions
    {
        /// <summary>
        /// Remove <paramref name="prefix"/> from the beginning of each element of <paramref name="list"/> that starts with it.
        /// </summary>
        internal static void CleanPrefixes(this List<string> list, string prefix)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string element = list[i];
                if (element.StartsWith(prefix))
                    list[i] = element.Substring(prefix.Length);
            }
        }

        /// <summary>
        /// Remove <paramref name="suffix"/> from the end of each element of <paramref name="list"/> that end with it.
        /// </summary>
        internal static void CleanSuffixes(this List<string> list, string suffix)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string element = list[i];
                if (element.EndsWith(suffix))
                    list[i] = element.Substring(0, element.Length - suffix.Length);
            }
        }
    }
}
