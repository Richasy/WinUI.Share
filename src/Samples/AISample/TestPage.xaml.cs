// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.WinUIKernel.Share.Base;

namespace AISample;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class TestPage : LayoutPageBase
{
    private readonly SettingsViewModel _settingsViewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestPage"/> class.
    /// </summary>
    public TestPage()
    {
        InitializeComponent();
        _settingsViewModel = GlobalDependencies.Kernel.GetRequiredService<SettingsViewModel>();
    }

    /// <inheritdoc/>
    protected override async void OnPageLoaded()
    {
        await _settingsViewModel.InitializeChatServicesAsync();
        await LoadChatControls();
    }

    private async Task LoadChatControls()
    {
        foreach (var vm in _settingsViewModel.ChatServices)
        {
            var control = vm.GetSettingControl();

            if (control != null)
            {
                await vm.InitializeCommand.ExecuteAsync(default);
                ChatContainer.Children.Add(control);
            }
        }
    }
}
