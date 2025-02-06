// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Richasy.AgentKernel.Models;
using Richasy.WinUIKernel.Share.ViewModels;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 聊天模型项视图模型.
/// </summary>
public sealed partial class ChatModelItemViewModel : ViewModelBase<ChatModel>
{
    private readonly Action<ChatModelItemViewModel>? _deleteAction;

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _id;

    [ObservableProperty]
    private bool _isSelected;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatModelItemViewModel"/> class.
    /// </summary>
    public ChatModelItemViewModel(ChatModel model, Action<ChatModelItemViewModel>? deleteAction = null)
        : base(model)
    {
        Name = model.Name!;
        Id = model.Id!;
        _deleteAction = deleteAction;
    }

    [RelayCommand]
    private async Task ModifyAsync()
    {
        var dialog = new CustomChatModelDialog(Data);
        var dialogResult = await dialog.ShowAsync();
        if (dialogResult == ContentDialogResult.Primary)
        {
            Name = dialog.Model.Name ?? string.Empty;
            Id = dialog.Model.Id ?? string.Empty;
        }
    }

    [RelayCommand]
    private void Delete()
        => _deleteAction?.Invoke(this);

    partial void OnNameChanged(string value)
    {
        if (Data.Name != value)
        {
            Data.Name = value;
        }
    }

    partial void OnIdChanged(string value)
    {
        if (Data.Id != value)
        {
            Data.Id = value;
        }
    }
}
