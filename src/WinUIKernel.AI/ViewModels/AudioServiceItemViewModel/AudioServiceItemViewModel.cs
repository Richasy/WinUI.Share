// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.AgentKernel;
using Richasy.WinUIKernel.Share.ViewModels;
using WinRT;
using Richasy.AgentKernel.Models;
using Richasy.AgentKernel.Audio;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 音频服务项目视图模型.
/// </summary>
[GeneratedBindableCustomProperty]
public sealed partial class AudioServiceItemViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AudioServiceItemViewModel"/> class.
    /// </summary>
    public AudioServiceItemViewModel(
        AudioProviderType providerType)
    {
        ProviderType = providerType;
        Name = GetProviderName();

        var serverModels = WinUIKernelAIExtensions.Kernel
            .GetRequiredService<IAudioService>()
            .GetPredefinedModels();
        ServerModels.Clear();
        serverModels.ToList().ForEach(p => ServerModels.Add(new AudioModelItemViewModel(p)));
        IsServerModelVisible = ServerModels.Count > 1;
    }

    /// <summary>
    /// 设置配置.
    /// </summary>
    /// <param name="config">配置内容.</param>
    public void SetConfig(AudioClientConfigBase config)
    {
        Config = config;
        CheckCurrentConfig();
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
    public bool IsModelExist(AudioModel model)
        => ServerModels.Any(p => p.Id == model.Id);

    private string GetProviderName()
    {
        return ProviderType switch
        {
            AudioProviderType.OpenAI => "Open AI",
            AudioProviderType.AzureOpenAI => "Azure Open AI",
            AudioProviderType.Azure => "Azure Speech",
            AudioProviderType.Edge => "Edge Speech",
            AudioProviderType.Windows => "Windows Speech",
            _ => throw new NotImplementedException(),
        };
    }
}
