namespace ConfluenceModelGenerator.Application.Models;

public class EntityMetadata : IMetadata
{
    public string Name { get; set; }
    
    public string Type { get; set; }
    
    public bool IsRequired { get; set; }
    
    public string Description { get; set; }
}