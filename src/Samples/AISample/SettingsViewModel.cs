// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.AgentKernel;
using Richasy.WinUIKernel.AI.ViewModels;

namespace AISample;

/// <summary>
/// Settings view model.
/// </summary>
public sealed partial class SettingsViewModel : AISettingsViewModelBase
{
    /// <inheritdoc/>
    public override async Task InitializeChatServicesAsync()
    {
        await base.InitializeChatServicesAsync();
        if (ChatServices.Count > 0)
        {
            return;
        }

        ChatServices.Add(new ChatServiceItemViewModel(ChatProviderType.AzureOpenAI));
    }

    /// <inheritdoc/>
    protected override async Task SaveChatServicesAsync()
    {
        await base.SaveChatServicesAsync();
        var configManager = this.Get<IChatConfigManager>();
        var dict = ChatServices.ToDictionary(item => item.ProviderType, item => item.Config);
        await configManager.SaveChatConfigAsync(dict);
    }
}
