namespace RT.VS2022.CloseAllToolWindows;

[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
[InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
[ProvideMenuResource("Menus.ctmenu", 1)]
[Guid("10671c9b-91bc-867d-b9a3-4e96fc9bc5f2")]
[ProvideAutoLoad(VSConstants.UICONTEXT.DocumentWindowActive_string, PackageAutoLoadFlags.BackgroundLoad)]
public sealed class CloseAllToolWindowsPackage : ToolkitPackage
{
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
    {
        await Services.InitializeAsync();
        await this.RegisterCommandsAsync();
    }
}