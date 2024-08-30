// Copyright (c) Richasy. All rights reserved.

using System;
using Microsoft.UI.Xaml.Data;

namespace Richasy.WinUI.Share.Converters;

/// <summary>
/// 图标变体转换器.
/// </summary>
public sealed class BoolToIconVariantConverter : IValueConverter
{
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
        {
            return FluentIcons.Common.IconVariant.Regular;
        }

        var isFilled = (bool)value;
        return isFilled ? FluentIcons.Common.IconVariant.Filled : FluentIcons.Common.IconVariant.Regular;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}
