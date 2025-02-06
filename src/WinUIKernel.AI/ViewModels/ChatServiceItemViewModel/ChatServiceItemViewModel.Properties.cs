// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using Richasy.AgentKernel;
using System.Collections.ObjectModel;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// AI服务项目视图模型.
/// </summary>
public sealed partial class ChatServiceItemViewModel
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private ChatProviderType _providerType;

    [ObservableProperty]
    private bool _isCompleted;

    [ObservableProperty]
    private ChatClientConfigBase _config;

    [ObservableProperty]
    private bool _isServerModelVisible;

    [ObservableProperty]
    private bool _isCustomModelsEmpty;

    [ObservableProperty]
    private bool _isSelected;

    /// <summary>
    /// 自定义模型.
    /// </summary>
    public ObservableCollection<ChatModelItemViewModel> CustomModels { get; } = new();

    /// <summary>
    /// 服务模型.
    /// </summary>
    public ObservableCollection<ChatModelItemViewModel> ServerModels { get; } = new();

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ChatServiceItemViewModel model && ProviderType == model.ProviderType;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(ProviderType);
}
