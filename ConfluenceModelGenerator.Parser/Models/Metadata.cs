namespace ConfluenceModelGenerator.Parser.Models;

public class Metadata
{
    public List<DescriptionMetadata> Descriptions { get; } = new();

    public Dictionary<string, string> Values { get; } = new();
}