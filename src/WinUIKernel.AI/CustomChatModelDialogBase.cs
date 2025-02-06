// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using Richasy.AgentKernel.Models;

namespace Richasy.WinUIKernel.AI;

/// <summary>
/// 自定义聊天模型对话框基类.
/// </summary>
public abstract class CustomChatModelDialogBase : ContentDialog
{
    /// <summary>
    /// 获取或设置模型.
    /// </summary>
    public ChatModel Model { get; protected set; }

    /// <summary>
    /// 设置模型.
    /// </summary>
    /// <param name="model"></param>
    public void SetModel(ChatModel model) => Model = model;
}
