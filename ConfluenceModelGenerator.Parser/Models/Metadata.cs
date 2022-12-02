namespace ConfluenceModelGenerator.Parser.Models;

public class Metadata
{
    public string Name { get; set; }
    
    public string Type { get; set; }
    
    public bool IsRequired { get; set; }
    
    public string Description { get; set; }

    public string Value { get; set; }
}