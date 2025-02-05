// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.WinUIKernel.Share.Base;

namespace AISample;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : WindowBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(typeof(TestPage));
    }
}
