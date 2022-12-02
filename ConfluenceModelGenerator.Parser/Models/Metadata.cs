namespace ConfluenceModelGenerator.Parser.Models;

public class Metadata
{
    public List<DescriptionMetadata> Descriptions { get; } = new();

    public Dictionary<string, object> Values { get; } = new();
}