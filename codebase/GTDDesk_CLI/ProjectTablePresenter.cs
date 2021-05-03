using System;
using System.Collections.Generic;
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
                string[] taskLines = SizeTextToColumn(project.Tasks[0], layout.TaskColumnWidth);
                DisplayRow(layout, project.Label, taskLines[0]);
                for (int i = 1; i < taskLines.Length; i++)
                {
                    DisplayRow(layout, "", taskLines[i]);
                }
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

        private static string[] SizeTextToColumn(string multiLineText, int maxWidth)
        {
            List<string> result = new List<string>();
            string[] lines = multiLineText.Split("\n");
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
                LabelColumnWidth = projects.Max(p => p.Label.Length),
                TaskColumnWidth = projects.Max(project => project.FirstTask().MaxLineLength())
            };

            int targetMinimumColumnWidth = 20;

            int? maxTableWidthSetting = Configuration.MaxTableWidth;
            if (maxTableWidthSetting.HasValue)
            {
                int maxTextWidth = Math.Max(80, maxTableWidthSetting.Value - layout.StructuralWidth);

                //there is enough room for un-wrapped labels
                if (maxTextWidth >= layout.LabelColumnWidth + targetMinimumColumnWidth)
                {
                    layout.TaskColumnWidth = maxTextWidth - layout.LabelColumnWidth;
                }
                //labels and tasks must both wrap
                else
                {
                    int labelPercent = Math.Max(1, (int)Math.Floor((layout.LabelColumnWidth / (layout.LabelColumnWidth + layout.TaskColumnWidth)) * 100m));
                    layout.LabelColumnWidth = Math.Max(1, (int)Math.Ceiling(maxTextWidth * (labelPercent / 100m)));
                    layout.TaskColumnWidth = maxTextWidth - layout.LabelColumnWidth;
                }
            }

            return layout;
        }
    }
}
