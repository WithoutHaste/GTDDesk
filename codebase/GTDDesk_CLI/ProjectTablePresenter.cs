using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTDDesk_Core;

namespace GTDDesk_CLI
{
    public static class ProjectTablePresenter
    {
        private const char ROW_DIVIDER = '-';

        public static void Display(Project[] projects)
        {
            ProjectTableLayout layout = CalculateLayout(projects);

            DisplayRow(layout, "Projects", "Next Task");
            DisplayRowDivider(layout);

            foreach (Project project in projects)
            {
                string[] projectLines = SizeTextToColumn(project.Label, Path.DirectorySeparatorChar, layout.LabelColumnWidth);
                string[] taskLines = SizeTextToColumn(project.Tasks[0], '\n', layout.TaskColumnWidth);

                for (int i = 0; i < projectLines.Length || i < taskLines.Length; i++)
                {
                    DisplayRow(layout, (i < projectLines.Length) ? projectLines[i] : "", (i < taskLines.Length) ? taskLines[i] : "");
                }
                DisplayRow(layout, "", "");
            }
        }

        private static void DisplayRow(ProjectTableLayout layout, string column1, string column2)
        {
            Console.WriteLine($"{layout.ColumnDivider}{layout.ColumnPadding}{column1.PadRight(layout.LabelColumnWidth)}{layout.ColumnPadding}{layout.ColumnDivider}{layout.ColumnPadding}{column2.PadRight(layout.TaskColumnWidth)}{layout.ColumnPadding}{layout.ColumnDivider}");
        }

        private static void DisplayRowDivider(ProjectTableLayout layout)
        {
            Console.WriteLine($"{layout.ColumnDivider}{layout.ColumnPadding}{new String(ROW_DIVIDER, layout.LabelColumnWidth)}{layout.ColumnPadding}{layout.ColumnDivider}{layout.ColumnPadding}{new String(ROW_DIVIDER, layout.TaskColumnWidth)}{layout.ColumnPadding}{layout.ColumnDivider}");
        }

        private static string[] SizeTextToColumn(string text, char textDivider, int maxWidth)
        {
            List<string> result = new List<string>();
            string[] lines = text.Split(textDivider);
            foreach (string line in lines)
            {
                if (line.Length <= maxWidth)
                {
                    result.Add(line);
                }
                else
                {
                    string remainingLine = line;
                    while (remainingLine.Length > maxWidth)
                    {
                        result.Add(remainingLine.Substring(0, maxWidth));
                        remainingLine = remainingLine.Substring(maxWidth);
                    }
                }
            }
            return result.ToArray();
        }

        private static ProjectTableLayout CalculateLayout(Project[] projects)
        {
            ProjectTableLayout layout = new ProjectTableLayout()
            {
                ColumnDividerWidth = 1,
                ColumnPaddingWidth = 1,
                LabelColumnWidth = projects.Max(p => p.Label.MaxLineLength(Path.DirectorySeparatorChar)),
                TaskColumnWidth = projects.Max(project => project.FirstTask().MaxLineLength('\n'))
            };

            int minimumTableWidth = 60;
            int targetMinimumColumnWidth = 20;

            int? maxTableWidthSetting = Configuration.MaxTableWidth;
            if (maxTableWidthSetting.HasValue)
            {
                int maxTextWidth = Math.Max(minimumTableWidth, maxTableWidthSetting.Value) - layout.StructuralWidth;

                //there is enough room for un-wrapped labels
                if (maxTextWidth >= layout.LabelColumnWidth + targetMinimumColumnWidth)
                {
                    layout.TaskColumnWidth = maxTextWidth - layout.LabelColumnWidth;
                }
                //labels and tasks must both wrap
                else
                {
                    int labelPercent = Math.Max(1, (int)Math.Floor((layout.LabelColumnWidth / (layout.LabelColumnWidth + layout.TaskColumnWidth)) * 100m));
                    layout.LabelColumnWidth = (int)(maxTextWidth * 0.33);
                    layout.TaskColumnWidth = maxTextWidth - layout.LabelColumnWidth;
                }
            }

            return layout;
        }
    }
}
