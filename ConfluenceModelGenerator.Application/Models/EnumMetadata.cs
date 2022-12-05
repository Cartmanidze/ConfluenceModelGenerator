namespace ConfluenceModelGenerator.Application.Models;

public class EnumMetadata : IMetadata
{
    public string Name { get; set; }
    
    public string Description { get; set; }

    public string Value { get; set; }
}