using System.Text.Json.Serialization;

namespace webapi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PackageType
    {
        Default = 0,
        Small = 1,
        Medium = 2,
        Large = 3
    }
}