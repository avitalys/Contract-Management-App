using System.Text.Json.Serialization;

namespace webapi.Enums
{
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContractType
    {
        Visitor = 0,
        Basic = 1,
        Advanced = 2,
        Premium = 3
    }
}