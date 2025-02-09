// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.WinUIKernel.AI.ViewModels;
using Richasy.WinUIKernel.Share.Base;

namespace Richasy.WinUIKernel.AI;

/// <summary>
/// 绘图模型卡片控件.
/// </summary>
public sealed partial class DrawModelCard : LayoutControlBase<DrawModelItemViewModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DrawModelCard"/> class.
    /// </summary>
    public DrawModelCard() => DefaultStyleKey = typeof(DrawModelCard);
}
