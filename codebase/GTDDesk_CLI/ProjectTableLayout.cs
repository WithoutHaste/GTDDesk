using System;

namespace GTDDesk_CLI
{
    public class ProjectTableLayout
    {
        public const int ColumnCount = 2;

        /// <summary>
        /// The amount of table width taken up by the overhead of the table structure
        /// </summary>
        public int StructuralWidth => (ColumnCount * ColumnPaddingWidth * 2) + ((ColumnCount + 1) * ColumnDividerWidth);

        public char ColumnDividerChar => '|';
        public int ColumnDividerWidth { get; set; }
        public string ColumnDivider => new String(ColumnDividerChar, ColumnDividerWidth);

        /// <summary>
        /// Padding is applied to each side of a column
        /// </summary>
        public int ColumnPaddingWidth { get; set; }
        public string ColumnPadding => new String(' ', ColumnPaddingWidth);

        public int LabelColumnWidth { get; set; }
        public int TaskColumnWidth { get; set; }
    }
}
