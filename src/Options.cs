using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace OpenInGVim
{
    public class Options : DialogPage
    {
        const string DefaultPathToExe = @"C:\Program Files (x86)\vim\vim74\gvim.exe";

        [Category("General")]
        [DisplayName("Path to gvim.exe")]
        [Description("Specify the path to gvim.exe.")]
        [DefaultValue(DefaultPathToExe)]
        public string PathToExe { get; set; } = DefaultPathToExe;

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
