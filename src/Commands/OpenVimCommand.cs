using System;
using System.ComponentModel.Design;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;

namespace OpenInGVim
{
    internal sealed class OpenVimCommand
    {
        private readonly Package _package;

        private OpenVimCommand(Package package)
        {
            _package = package;

            OleMenuCommandService commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(PackageGuids.guidOpenInVimCmdSet, PackageIds.OpenInVim);
                var menuItem = new MenuCommand(OpenFolderInVim, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        public static OpenVimCommand Instance { get; private set; }

        private IServiceProvider ServiceProvider
        {
            get { return _package; }
        }

        public static void Initialize(Package package)
        {
            Instance = new OpenVimCommand(package);
        }

        private void OpenFolderInVim(object sender, EventArgs e)
        {
            var dte = (DTE2)ServiceProvider.GetService(typeof(DTE));

            try
            {
                string path = ProjectHelpers.GetSelectedPath(dte);

                if (!string.IsNullOrEmpty(path))
                {
                    OpenVim(path);
                }
                else
                {
                    MessageBox.Show("Couldn't resolve the folder");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

        private static void OpenVim(string path)
        {
            EnsurePathExist();
            bool isDirectory = Directory.Exists(path);
            string cwd = File.Exists(path) ? Path.GetDirectoryName(path) : path;

            var start = new System.Diagnostics.ProcessStartInfo()
            {
                WorkingDirectory = cwd,
                FileName = VSPackage.Options.PathToExe,
                Arguments = isDirectory ? "." : $"\"{path}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            };

            using (System.Diagnostics.Process.Start(start))
            {
                string evt = isDirectory ? "directory" : "file";
            }
        }

        private static void EnsurePathExist()
        {
            if (File.Exists(VSPackage.Options.PathToExe))
                return;

            var box = MessageBox.Show("I can't find Vim (gvim.exe). Would you like to help me find it?", Vsix.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (box == DialogResult.No)
                return;

            var dialog = new OpenFileDialog
            {
                DefaultExt = ".exe",
                FileName = "gvim.exe",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                CheckFileExists = true
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                VSPackage.Options.PathToExe = dialog.FileName;
                VSPackage.Options.SaveSettingsToStorage();
            }
        }
    }
}
