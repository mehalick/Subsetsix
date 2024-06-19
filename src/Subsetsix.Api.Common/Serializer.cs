using System.Text.Json.Serialization;

namespace Subsetsix.Api.Common;

[JsonSerializable(typeof(List<ItemsListResponseItem>))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class Serializer : JsonSerializerContext
{ }