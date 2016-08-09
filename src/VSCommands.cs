using System;

namespace OpenInGVim
{
    internal sealed partial class PackageGuids
    {
        public const string guidPackageString = "19B50D05-1E69-4DE0-B4DF-ED3DCF29FDFE";
        public const string guidOpenInVimCmdSetString = "00626A7A-5F48-48B6-83FB-BF6240AD8062";
        public const string guidImageString = "00626A7A-5F48-48B6-83FB-BF6240AD8063";
        public static Guid guidPackage = new Guid(guidPackageString);
        public static Guid guidOpenInVimCmdSet = new Guid(guidOpenInVimCmdSetString);
        public static Guid guidImages = new Guid(guidImageString);
    }

    internal sealed partial class PackageIds
    {
        public const int OpenInVim = 0x0100;
        public const int VimIcon = 0x0001;
    }
}
