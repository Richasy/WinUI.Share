// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;

namespace Richasy.WinUIKernel.Share.Base;

/// <summary>
/// ��ע�͵�ͷ���ؼ�.
/// </summary>
public sealed partial class TipHeader : LayoutUserControlBase
{
    /// <summary>
    /// <see cref="Title"/> ����������.
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(TipHeader), new PropertyMetadata(default));

    /// <summary>
    /// <see cref="Comment"/> ����������.
    /// </summary>
    public static readonly DependencyProperty CommentProperty =
        DependencyProperty.Register(nameof(Comment), typeof(string), typeof(TipHeader), new PropertyMetadata(default));

    /// <summary>
    /// Initializes a new instance of the <see cref="TipHeader"/> class.
    /// </summary>
    public TipHeader() => InitializeComponent();

    /// <summary>
    /// ��ȡ�����ñ���.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// ��ȡ������ע��.
    /// </summary>
    public string Comment
    {
        get => (string)GetValue(CommentProperty);
        set => SetValue(CommentProperty, value);
    }
}
