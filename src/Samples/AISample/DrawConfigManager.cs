// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.AgentKernel;
using Richasy.AgentKernel.Models;
using Richasy.WinUIKernel.Share.Toolkits;
using Windows.Storage;

namespace AISample;

/// <summary>
/// 绘图服务配置管理器.
/// </summary>
public sealed class DrawConfigManager : DrawConfigManagerBase
{
    /// <inheritdoc/>
    protected override AIServiceConfig? ConvertToConfig(DrawClientConfigBase? config) => throw new NotImplementedException();

    /// <inheritdoc/>
    protected override async Task<DrawClientConfiguration> OnInitializeAsync()
    {
        if (File.Exists(Path.Combine(ApplicationData.Current.LocalFolder.Path, "drawConfig.json")))
        {
            return await GlobalDependencies.Kernel.GetRequiredService<IFileToolkit>()
            .ReadLocalDataAsync("drawConfig.json", JsonGenContext.Default.DrawClientConfiguration);
        }

        return new DrawClientConfiguration();
    }

    /// <inheritdoc/>
    protected override async Task OnSaveAsync(DrawClientConfiguration configuration)
    {
        await GlobalDependencies.Kernel.GetRequiredService<IFileToolkit>()
            .WriteLocalDataAsync("drawConfig.json", configuration, JsonGenContext.Default.DrawClientConfiguration);
    }
}
