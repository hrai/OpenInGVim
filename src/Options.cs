using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace OpenInGVim
{
    public class Options : DialogPage
    {
        const string DefaultPathToExe = @"C:\Program Files (x86)\vim\vim80\gvim.exe";

        [Category("General")]
        [DisplayName("Command line arguments")]
        [Description("Command line arguments to pass to gvim.exe")]
        public string CommandLineArguments { get; set; }

        [Category("General")]
        [DisplayName("Path to gvim.exe")]
        [Description("Specify the path to gvim.exe.")]
        [DefaultValue(DefaultPathToExe)]
        public string PathToExe { get; set; } = DefaultPathToExe;

        [Category("General")]
        [DisplayName("Open solution/project as regular file")]
        [Description("When true, opens solutions/projects as regular files and does not load folder path into VS Code.")]
        public bool OpenSolutionProjectAsRegularFile { get; set; }

        protected override void OnApply(PageApplyEventArgs e)
        {
            if (!File.Exists(PathToExe))
            {
                e.ApplyBehavior = ApplyKind.Cancel;
                MessageBox.Show($"The file \"{PathToExe}\" doesn't exist.", Vsix.Name, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            base.OnApply(e);
        }
    }
}
