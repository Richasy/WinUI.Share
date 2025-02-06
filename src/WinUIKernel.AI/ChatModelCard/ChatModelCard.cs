﻿// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using Richasy.WinUIKernel.AI.ViewModels;
using Richasy.WinUIKernel.Share.Base;
using Richasy.WinUIKernel.Share.Toolkits;
using System.ComponentModel;

namespace Richasy.WinUIKernel.AI;

/// <summary>
/// 聊天模型卡片控件.
/// </summary>
public sealed partial class ChatModelCard : LayoutControlBase<ChatModelItemViewModel>
{
    private Button _moreButton;
    private TextBlock _nameBlock;
    private TextBlock _idBlock;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatModelCard"/> class.
    /// </summary>
    public ChatModelCard() => DefaultStyleKey = typeof(ChatModelCard);

    /// <inheritdoc/>
    protected override void OnApplyTemplate()
    {
        _moreButton = GetTemplateChild("MoreButton") as Button;
        _nameBlock = GetTemplateChild("NameBlock") as TextBlock;
        _idBlock = GetTemplateChild("IdBlock") as TextBlock;
        if (_moreButton is not null)
        {
            _moreButton.Flyout = CreateMoreFlyout();
        }

        if (_nameBlock is not null)
        {
            _nameBlock.Text = ViewModel?.Name;
        }

        if (_idBlock is not null)
        {
            _idBlock.Text = ViewModel?.Id;
        }
    }

    /// <inheritdoc/>
    protected override void OnControlUnloaded()
    {
        if (ViewModel != null)
        {
            ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }
    }

    /// <inheritdoc/>
    protected override void OnViewModelChanged(ChatModelItemViewModel? oldValue, ChatModelItemViewModel? newValue)
    {
        if (oldValue is not null)
        {
            oldValue.PropertyChanged -= OnViewModelPropertyChanged;
        }

        if (newValue is not null)
        {
            newValue.PropertyChanged += OnViewModelPropertyChanged;
        }

        if (_moreButton is not null && newValue is not null && _moreButton.Flyout is MenuFlyout mf)
        {
            foreach (var item in mf.Items.OfType<MenuFlyoutItem>())
            {
                if (item.Tag.ToString() == nameof(ViewModel.ModifyCommand))
                {
                    item.Command = newValue.ModifyCommand;
                }
                else if (item.Tag.ToString() == nameof(ViewModel.DeleteCommand))
                {
                    item.Command = newValue.DeleteCommand;
                }
            }
        }

        if (_nameBlock is not null)
        {
            _nameBlock.Text = newValue?.Name;
        }

        if (_idBlock is not null)
        {
            _idBlock.Text = newValue?.Id;
        }
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ViewModel.Name) && _nameBlock is not null)
        {
            _nameBlock.Text = ViewModel?.Name;
        }
        else if (e.PropertyName == nameof(ViewModel.Id) && _idBlock is not null)
        {
            _idBlock.Text = ViewModel?.Id;
        }
    }

    private MenuFlyout CreateMoreFlyout()
    {
        var flyout = new MenuFlyout();
        var resourceToolkit = WinUIKernelAIExtensions.Kernel.GetRequiredService<IResourceToolkit>();
        flyout.Items.Add(new MenuFlyoutItem
        {
            Text = resourceToolkit.GetLocalizedString("Edit"),
            MinWidth = 160,
            Icon = new FluentIcons.WinUI.SymbolIcon { Symbol = FluentIcons.Common.Symbol.Edit },
            Tag = nameof(ViewModel.ModifyCommand),
            Command = ViewModel.ModifyCommand,
        });

        flyout.Items.Add(new MenuFlyoutItem
        {
            Text = resourceToolkit.GetLocalizedString("Delete"),
            MinWidth = 160,
            Icon = new FluentIcons.WinUI.SymbolIcon { Symbol = FluentIcons.Common.Symbol.Delete, Foreground = resourceToolkit.GetThemeBrush("SystemFillColorCriticalBrush") },
            Tag = nameof(ViewModel.DeleteCommand),
            Command = ViewModel.DeleteCommand,
        });

        return flyout;
    }
}
