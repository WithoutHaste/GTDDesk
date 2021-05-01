namespace GTDDesk_Core
{
    /// <summary>
    /// A GTD project. A collection of tasks.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Full path to project file
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// aka display name
        /// </summary>
        public string Label { get; set; }
    }
}
