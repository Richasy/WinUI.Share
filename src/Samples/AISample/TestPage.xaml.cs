// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.AgentKernel;
using Richasy.WinUIKernel.AI.Chat;
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
        LoadChatControls();
    }

    private void LoadChatControls()
    {
        foreach (var vm in _settingsViewModel.ChatServices)
        {
            var control = vm.ProviderType switch
            {
                ChatProviderType.AzureOpenAI => new AzureOpenAIChatSettingControl(),
                _ => default,
            };

            if (control != null)
            {
                control.DataContext = vm;
                control.ViewModel = vm;
                vm.InitializeCommand.Execute(default);
                ChatContainer.Children.Add(control);
            }
        }
    }
}
