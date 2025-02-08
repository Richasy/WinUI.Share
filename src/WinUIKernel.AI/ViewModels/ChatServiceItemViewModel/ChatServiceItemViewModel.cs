﻿// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Richasy.AgentKernel;
using Richasy.AgentKernel.Chat;
using Richasy.AgentKernel.Models;
using Richasy.WinUIKernel.AI.Chat;
using Richasy.WinUIKernel.Share.Base;
using Richasy.WinUIKernel.Share.ViewModels;
using WinRT;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// AI服务项目视图模型.
/// </summary>
[GeneratedBindableCustomProperty]
public partial class ChatServiceItemViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatServiceItemViewModel"/> class.
    /// </summary>
    public ChatServiceItemViewModel(
        ChatProviderType providerType)
    {
        ProviderType = providerType;
        Name = GetProviderName();

        var serverModels = WinUIKernelAIExtensions.Kernel
            .GetRequiredService<IChatService>(providerType.ToString())
            .GetPredefinedModels();
        ServerModels.Clear();
        serverModels.ToList().ForEach(p => ServerModels.Add(new ChatModelItemViewModel(p)));
        IsServerModelVisible = ServerModels.Count > 0;
        CheckCustomModelsCount();
    }

    /// <summary>
    /// 检查当前配置是否有效.
    /// </summary>
    public void CheckCurrentConfig()
        => IsCompleted = Config?.IsValid() ?? false;

    /// <summary>
    /// 模型是否已存在于列表之中.
    /// </summary>
    /// <param name="model">模型.</param>
    /// <returns>是否存在.</returns>
    public bool IsModelExist(ChatModel model)
        => CustomModels.Any(p => p.Id == model.Id) || ServerModels.Any(p => p.Id == model.Id);

    /// <summary>
    /// 添加自定义模型.
    /// </summary>
    /// <param name="model">模型.</param>
    public void AddCustomModel(ChatModel model)
    {
        if (IsModelExist(model))
        {
            return;
        }

        CustomModels.Add(new ChatModelItemViewModel(model, DeleteCustomModel));
        Config.CustomModels ??= [];
        Config.CustomModels.Add(model);
        CheckCustomModelsCount();
        CheckCurrentConfig();
    }

    /// <summary>
    /// 获取设置控件.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ChatServiceConfigControlBase GetSettingControl()
    {
        return ProviderType switch
        {
            ChatProviderType.Moonshot
                or ChatProviderType.ZhiPu
                or ChatProviderType.LingYi
                or ChatProviderType.DeepSeek
                or ChatProviderType.OpenRouter
                or ChatProviderType.Groq
                or ChatProviderType.Mistral
                or ChatProviderType.TogetherAI
                or ChatProviderType.Perplexity
                or ChatProviderType.SiliconFlow
                or ChatProviderType.Hunyuan
                or ChatProviderType.Spark
                or ChatProviderType.XAI
                or ChatProviderType.Doubao
                or ChatProviderType.Qwen => new BasicChatSettingControl { ViewModel = this },
            ChatProviderType.Anthropic
                or ChatProviderType.Ollama
                or ChatProviderType.AzureAI
                or ChatProviderType.Gemini => new EndpointChatSettingControl { ViewModel = this },
            ChatProviderType.AzureOpenAI => new AzureOpenAIChatSettingControl { ViewModel = this },
            ChatProviderType.OpenAI => new OpenAIChatSettingControl { ViewModel = this },
            ChatProviderType.Ernie => new ErnieChatSettingControl { ViewModel = this },
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// 创建自定义模型.
    /// </summary>
    /// <returns><see cref="Task"/>.</returns>
    [RelayCommand]
    private async Task CreateCustomModelAsync()
    {
        var dialog = new CustomChatModelDialog();
        var dialogResult = await dialog.ShowAsync();
        if (dialogResult == ContentDialogResult.Primary)
        {
            var model = dialog.Model;
            if (model == null)
            {
                return;
            }

            if (IsModelExist(model))
            {
                this.Get<INotificationViewModel>()
                    .ShowTipCommand.Execute((WinUIKernelAIExtensions.ResourceToolkit.GetLocalizedString("ModelAlreadyExist"), InfoType.Error));
                return;
            }

            AddCustomModel(model);
        }
    }

    [RelayCommand]
    private async Task InitializeAsync()
    {
        var config = await this.Get<IChatConfigManager>().GetChatConfigAsync(ProviderType);
        if (config != null)
        {
            SetConfig(config);
        }
    }

    /// <summary>
    /// 设置配置.
    /// </summary>
    /// <param name="config">配置内容.</param>
    private void SetConfig(ChatClientConfigBase config)
    {
        Config = config;
        if (config?.IsCustomModelNotEmpty() ?? false)
        {
            CustomModels.Clear();
            config.CustomModels.ToList().ForEach(p => CustomModels.Add(new ChatModelItemViewModel(p, DeleteCustomModel)));
            CheckCustomModelsCount();
        }

        CheckCurrentConfig();
    }

    private void DeleteCustomModel(ChatModelItemViewModel model)
    {
        CustomModels.Remove(model);
        Config.CustomModels?.Remove(model.Data);
        CheckCustomModelsCount();
        CheckCurrentConfig();
    }

    private void CheckCustomModelsCount()
        => IsCustomModelsEmpty = CustomModels.Count == 0;

    private string GetProviderName()
    {
        return ProviderType switch
        {
            ChatProviderType.OpenAI => "Open AI",
            ChatProviderType.AzureOpenAI => "Azure Open AI",
            ChatProviderType.AzureAI => "Azure AI",
            ChatProviderType.Gemini => "Gemini",
            ChatProviderType.Anthropic => "Anthropic",
            ChatProviderType.DeepSeek => "Deep Seek",
            ChatProviderType.SiliconFlow => "硅基流动",
            ChatProviderType.OpenRouter => "Open Router",
            ChatProviderType.Moonshot => "月之暗面",
            ChatProviderType.ZhiPu => "智谱 AI",
            ChatProviderType.LingYi => "零一万物",
            ChatProviderType.Qwen => "通义千问",
            ChatProviderType.Ernie => "文心一言",
            ChatProviderType.Hunyuan => "腾讯混元",
            ChatProviderType.Spark => "讯飞星火",
            ChatProviderType.TogetherAI => "Together AI",
            ChatProviderType.Groq => "Groq",
            ChatProviderType.Perplexity => "Perplexity",
            ChatProviderType.Mistral => "Mistral AI",
            ChatProviderType.Ollama => "Ollama",
            ChatProviderType.Doubao => "字节豆包",
            ChatProviderType.XAI => "xAI",
            _ => throw new NotImplementedException(),
        };
    }
}
