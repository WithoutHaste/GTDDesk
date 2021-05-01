namespace GTDDesk_Core
{
    /// <summary>
    /// aka Configuration
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Directory containing user's GTD project files
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// If true, subdirectories of <cref see="Directory"/> will be searched recursively for more projects
        /// </summary>
        public bool IncludeSubDirectories { get; set; }
    }
}
