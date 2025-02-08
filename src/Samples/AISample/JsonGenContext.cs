// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Richasy.AgentKernel;
using System.Text.Json.Serialization;

namespace AISample;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(ChatClientConfiguration))]
internal sealed partial class JsonGenContext : JsonSerializerContext
{
}
