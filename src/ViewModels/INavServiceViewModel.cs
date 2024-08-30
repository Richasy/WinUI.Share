// Copyright (c) Richasy. All rights reserved.

namespace Richasy.WinUI.Share.ViewModels;

/// <summary>
/// 导航服务视图模型.
/// </summary>
public interface INavServiceViewModel
{
    /// <summary>
    /// 导航到指定页面.
    /// </summary>
    void NavigateTo(string pageKey, object? parameter = default);

    /// <summary>
    /// 导航到覆盖页面.
    /// </summary>
    void NavigateToOver(string pageKey, object? parameter = default);
}
