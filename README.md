# Open In GVim

A Visual Studio extension that adds a menu command that lets you open a solution, project,
folder or file in Vim.

Build Status **TBD**

Download the extension at the [VS Gallery](https://visualstudiogallery.msdn.microsoft.com/2c4f2826-c298-4ec8-8c13-3d6b77fd9675).

------------------------------------

This extension was largely patterned after Mads Kristensen's wonderful
["Open In Visual Studio Code"](https://github.com/madskristensen/OpenInVsCode) plugin.

I do use Visual Studio Code from time-to-time but I much prefer Vim.  This extension is for
those times when you are editing something in Visual Studio but want to be able to
quickly open it in Vim.

## Prerequisite

In order to use this extension, you must have Visual Studio 2015+ as well as Gvim installed.

## Solution Explorer

You can open any solution, project, folder, or file in Vim by simply right-clicking
it in Solution Explorer and selecting **Open In GVim**.

![Context menu](art/context-menu.png)

## Path to Gvim.exe

If you installed Vim to a non-default location, a prompt will ask for the path to _Gvim.exe_.

You can always change the location in **Tools -> Options -> VsVim -> Open In GVim**.

![Options](art/options.png)

## License

[Apache 2.0](LICENSE)
