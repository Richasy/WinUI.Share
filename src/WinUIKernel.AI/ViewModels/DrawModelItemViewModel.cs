// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using Richasy.AgentKernel.Models;
using Richasy.WinUIKernel.Share.ViewModels;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 绘图模型项视图模型.
/// </summary>
public sealed partial class DrawModelItemViewModel : ViewModelBase<DrawModel>
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _id;

    [ObservableProperty]
    private bool _isSelected;

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
