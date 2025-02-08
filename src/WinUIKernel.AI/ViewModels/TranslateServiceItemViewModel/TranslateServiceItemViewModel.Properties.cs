// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using Richasy.AgentKernel;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 翻译服务项目视图模型.
/// </summary>
public sealed partial class TranslateServiceItemViewModel
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private TranslateProviderType _providerType;

    [ObservableProperty]
    private bool _isCompleted;

    [ObservableProperty]
    private TranslateClientConfigBase? _config;

    [ObservableProperty]
    private bool _isSelected;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is TranslateServiceItemViewModel model && ProviderType == model.ProviderType;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(ProviderType);
}
