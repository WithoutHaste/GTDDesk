namespace GTDDesk_Core.Internal
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Remove <paramref name="prefix"/> from the beginning of <paramref name="element"/> if it starts with it.
        /// </summary>
        internal static string CleanPrefix(this string element, string prefix)
        {
            if (element.StartsWith(prefix))
                return element.Substring(prefix.Length);
            return element;
        }

        /// <summary>
        /// Remove <paramref name="suffix"/> from the end of <paramref name="element"/> if it ends with it.
        /// </summary>
        internal static string CleanSuffix(this string element, string suffix)
        {
            if (element.EndsWith(suffix))
                return element.Substring(0, element.Length - suffix.Length);
            return element;
        }
    }
}
