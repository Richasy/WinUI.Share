// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using Richasy.AgentKernel.Models;
using Richasy.WinUIKernel.Share.ViewModels;
using WinRT;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 绘图模型项视图模型.
/// </summary>
[GeneratedBindableCustomProperty]
public sealed partial class DrawModelItemViewModel : ViewModelBase<DrawModel>
{
    [ObservableProperty]
    public partial string? Name { get; set; }

    [ObservableProperty]
    public partial string? Id { get; set; }

    [ObservableProperty]
    public partial bool IsSelected { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DrawModelItemViewModel"/> class.
    /// </summary>
    public DrawModelItemViewModel(DrawModel model)
        : base(model)
    {
        Name = model.DisplayName;
        Id = model.Id;
    }
}
