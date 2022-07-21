using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpression.Winforms.Components
{
    internal class FileDialogHelpers
    {
        public static string[]? OpenFileDialogAndGetResults()
        {
            var FileDialog = new OpenFileDialog();
            FileDialog.Title = "Open File";
            FileDialog.Filter = "NExpression Document (*.nex)|*.nex";
            FileDialog.DefaultExt = "nex";
            FileDialog.FileName = string.Empty;
            FileDialog.Multiselect = true;

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                if (FileDialog.FileNames.Length > 0)
                {
                    return FileDialog.FileNames;
                }
            }
            return null;
        }

        public static string? SaveFileDialogAndGetResult()
        {
            var FileDialog = new SaveFileDialog();
            FileDialog.Title = "Save File";
            FileDialog.Filter = "NExpression Document (*.nex)|*.nex";
            FileDialog.DefaultExt = "nex";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                return FileDialog.FileName;
            }
            return null;
        }
    }
}
