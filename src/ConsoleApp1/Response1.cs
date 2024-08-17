using System.Text.Json.Serialization;

public record Response1
{
    [JsonPropertyName("result")]
    public required string Result { get; init; }
}
