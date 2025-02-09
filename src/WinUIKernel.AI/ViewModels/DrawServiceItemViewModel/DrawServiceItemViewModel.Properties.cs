// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using Richasy.AgentKernel;
using System.Collections.ObjectModel;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 绘图服务项目视图模型.
/// </summary>
public sealed partial class DrawServiceItemViewModel
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private DrawProviderType _providerType;

    [ObservableProperty]
    private bool _isCompleted;

    [ObservableProperty]
    private DrawClientConfigBase? _config;

    [ObservableProperty]
    private bool _isServerModelVisible;

    [ObservableProperty]
    private bool _isSelected;

    /// <summary>
    /// 服务模型.
    /// </summary>
    public ObservableCollection<DrawModelItemViewModel> ServerModels { get; } = [];

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DrawServiceItemViewModel model && ProviderType == model.ProviderType;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(ProviderType);
}
