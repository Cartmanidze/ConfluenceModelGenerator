using System.Text.Json.Serialization;

namespace ConfluenceModelGenerator.Parser.Models;

public class DescriptionMetadata
{
    public DescriptionMetadata(string name, string type, bool isRequired, string description)
    {
        Name = name;
        Type = type;
        IsRequired = isRequired;
        Description = description;
    }
    
    [JsonInclude]
    public string Name { get; private set; }

    [JsonInclude]
    public string Type { get; private set; }

    [JsonInclude]
    public bool IsRequired { get; private set; }

    [JsonInclude]
    public string Description { get; private set; }
}