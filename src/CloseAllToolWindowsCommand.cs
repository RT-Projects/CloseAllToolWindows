namespace RT.VS2022.CloseAllToolWindows;

[Command(0x0123)]
internal sealed class CloseAllToolWindowsCommand : BaseCommand<CloseAllToolWindowsCommand>
{
    protected override void Execute(object sender, EventArgs e)
    {
        ThreadHelper.ThrowIfNotOnUIThread();

        ErrorHandler.ThrowOnFailure(Services.VsUIShell.GetToolWindowEnum(out IEnumWindowFrames toolwins));
        var temp = new IVsWindowFrame[1];
        while (toolwins.Next(1, temp, out uint fetched) == VSConstants.S_OK && fetched == 1)
        {
            IVsWindowFrame frame = temp[0];
            frame.CloseFrame((uint) __FRAMECLOSE.FRAMECLOSE_PromptSave);
        }
    }
}