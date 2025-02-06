// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using Richasy.AgentKernel.Models;
using Richasy.WinUIKernel.Share.Base;
using Richasy.WinUIKernel.Share.Toolkits;
using Richasy.WinUIKernel.Share.ViewModels;

namespace Richasy.WinUIKernel.AI;

/// <summary>
/// Custom chat model dialog.
/// </summary>
public sealed partial class CustomChatModelDialog : ContentDialog
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomChatModelDialog"/> class.
    /// </summary>
    public CustomChatModelDialog()
    {
        InitializeComponent();
        Title = this.Get<IResourceToolkit>().GetLocalizedString("CreateCustomModel");
        this.Get<IAppToolkit>().ResetControlTheme(this);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomChatModelDialog"/> class.
    /// </summary>
    public CustomChatModelDialog(ChatModel model, bool isIdEnabled = true)
        : this()
    {
        Title = this.Get<IResourceToolkit>().GetLocalizedString("ModifyCustomModel");
        ModelNameBox.Text = model.Name;
        ModelIdBox.Text = model.Id;
        ModelIdBox.IsEnabled = isIdEnabled;
    }

    /// <summary>
    /// 获取或设置模型.
    /// </summary>
    public ChatModel Model { get; private set; }

    private void OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        var modelName = ModelNameBox.Text?.Trim() ?? string.Empty;
        var modelId = ModelIdBox.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(modelName) || string.IsNullOrEmpty(modelId))
        {
            args.Cancel = true;
            this.Get<INotificationViewModel>().ShowTipCommand.Execute((this.Get<IResourceToolkit>().GetLocalizedString("ModelNameOrIdCanNotBeEmpty"), InfoType.Error));
            return;
        }

        Model = new ChatModel(modelId, modelName);
    }
}
