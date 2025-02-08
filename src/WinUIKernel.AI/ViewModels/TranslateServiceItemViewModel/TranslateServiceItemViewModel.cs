// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.AgentKernel;
using Richasy.WinUIKernel.Share.ViewModels;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 翻译服务项目视图模型.
/// </summary>
public sealed partial class TranslateServiceItemViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TranslateServiceItemViewModel"/> class.
    /// </summary>
    public TranslateServiceItemViewModel(
        TranslateProviderType providerType)
    {
        ProviderType = providerType;
        Name = GetProviderName();
    }

    /// <summary>
    /// 设置配置.
    /// </summary>
    /// <param name="config">配置内容.</param>
    public void SetConfig(TranslateClientConfigBase config)
    {
        Config = config;
        CheckCurrentConfig();
    }

    /// <summary>
    /// 检查当前配置是否有效.
    /// </summary>
    public void CheckCurrentConfig()
        => IsCompleted = Config?.IsValid() ?? false;

    private string GetProviderName()
    {
        return ProviderType switch
        {
            TranslateProviderType.Tencent => "腾讯云翻译",
            TranslateProviderType.Baidu => "百度翻译",
            TranslateProviderType.Azure => "Azure / Bing Translate",
            TranslateProviderType.Google => "Google Translate",
            TranslateProviderType.Youdao => "有道翻译",
            TranslateProviderType.Ali => "阿里云翻译",
            TranslateProviderType.Volcano => "火山翻译",
            _ => throw new NotImplementedException(),
        };
    }
}
