// Copyright (c) Richasy. All rights reserved.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Richasy.WinUI.Share.Base;

/// <summary>
/// 文本块，超出部分省略，并提供工具提示.
/// </summary>
public sealed partial class TrimTextBlock : UserControl
{
    /// <summary>
    /// <see cref="Text"/> 的依赖属性.
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(TrimTextBlock), new PropertyMetadata(default));

    /// <summary>
    /// <see cref="MaxLines"/> 的依赖属性.
    /// </summary>
    public static readonly DependencyProperty MaxLinesProperty =
        DependencyProperty.Register(nameof(MaxLines), typeof(int), typeof(TrimTextBlock), new PropertyMetadata(99));

    /// <summary>
    /// Initializes a new instance of the <see cref="TrimTextBlock"/> class.
    /// </summary>
    public TrimTextBlock()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 文本.
    /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 最大行数.
    /// </summary>
    public int MaxLines
    {
        get => (int)GetValue(MaxLinesProperty);
        set => SetValue(MaxLinesProperty, value);
    }
}
