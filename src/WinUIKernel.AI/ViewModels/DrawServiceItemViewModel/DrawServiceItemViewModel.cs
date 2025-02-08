// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.AgentKernel.Draw;
using Richasy.AgentKernel.Models;
using Richasy.AgentKernel;
using Richasy.WinUIKernel.Share.ViewModels;
using WinRT;

namespace Richasy.WinUIKernel.AI.ViewModels;

/// <summary>
/// 绘图服务项目视图模型.
/// </summary>
[GeneratedBindableCustomProperty]
public sealed partial class DrawServiceItemViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DrawServiceItemViewModel"/> class.
    /// </summary>
    public DrawServiceItemViewModel(
        DrawProviderType providerType)
    {
        ProviderType = providerType;
        Name = GetProviderName();

        var serverModels = WinUIKernelAIExtensions.Kernel
            .GetRequiredService<IDrawService>()
            .GetPredefinedModels();
        ServerModels.Clear();
        serverModels.ToList().ForEach(p => ServerModels.Add(new DrawModelItemViewModel(p)));
        IsServerModelVisible = ServerModels.Count > 1;
    }

    /// <summary>
    /// 设置配置.
    /// </summary>
    /// <param name="config">配置内容.</param>
    public void SetConfig(DrawClientConfigBase config)
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
    public bool IsModelExist(DrawModel model)
        => ServerModels.Any(p => p.Id == model.Id);

    private string GetProviderName()
    {
        return ProviderType switch
        {
            DrawProviderType.OpenAI => "Open AI",
            DrawProviderType.AzureOpenAI => "Azure Open AI",
            DrawProviderType.Hunyuan => "混元生图",
            DrawProviderType.Spark => "星火绘图",
            DrawProviderType.Ernie => "文心生图",
            _ => throw new NotImplementedException(),
        };
    }
}
