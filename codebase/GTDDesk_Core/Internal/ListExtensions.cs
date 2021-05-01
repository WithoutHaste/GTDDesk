using System.Collections.Generic;

namespace GTDDesk_Core.Internal
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
                list[i] = list[i].CleanPrefix(prefix);
            }
        }

        /// <summary>
        /// Remove <paramref name="suffix"/> from the end of each element of <paramref name="list"/> that ends with it.
        /// </summary>
        internal static void CleanSuffixes(this List<string> list, string suffix)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].CleanSuffix(suffix);
            }
        }
    }
}
