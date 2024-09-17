// Copyright (c) Richasy. All rights reserved.

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Richasy.WinUI.Share.ViewModels;

/// <summary>
/// 应用导航视图项视图模型.
/// </summary>
public sealed partial class AppNavigationItemViewModel : ViewModelBase
{
    private readonly Action<object?> _navigateAction;

    [ObservableProperty]
    private bool _showUnread;

    [ObservableProperty]
    private FluentIcons.Common.Symbol _symbol;

    [ObservableProperty]
    private bool _isSelected;

    [ObservableProperty]
    private string _title;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppNavigationItemViewModel"/> class.
    /// </summary>
    public AppNavigationItemViewModel(
        INavServiceViewModel navService,
        Type pageType,
        string title,
        FluentIcons.Common.Symbol? symbol = default,
        bool isSelected = false)
    {
        PageKey = pageType.FullName;
        Title = title;
        Symbol = symbol ?? FluentIcons.Common.Symbol.Circle;
        IsSelected = isSelected;
        _navigateAction = parameter => navService.NavigateTo(pageType, parameter);
    }

    /// <summary>
    /// 页面标识.
    /// </summary>
    public string PageKey { get; }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is AppNavigationItemViewModel model && PageKey == model.PageKey;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(PageKey);

    [RelayCommand]
    private void Navigate(object? parameter = default)
        => _navigateAction?.Invoke(parameter);
}
