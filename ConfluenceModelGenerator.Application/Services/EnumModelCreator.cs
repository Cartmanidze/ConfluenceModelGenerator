using System.Text;
using ConfluenceModelGenerator.Application.Models;
using ConfluenceModelGenerator.Application.Services.Interfaces;

namespace ConfluenceModelGenerator.Application.Services;

public class EnumModelCreator : IModelCreator
{
    public async Task<string> CreateAsync(string path, CancellationToken token)
    {
        var parser = new EnumTableMetadataParser();

        var dataForParse = new DataForParse("https://docs.reo.ru/pages/viewpage.action?pageId=45255786",
            "https://docs.reo.ru/login.action", "#login-container > div > form",
            "#main-content > div:nth-child(5) > table", "user", "pass");

        var metadataItems = await parser.ParseAsync(dataForParse, token);

        if (metadataItems == null || metadataItems.Count == 0)
        {
            return null;
        }
        
        var sb = new StringBuilder();
        sb.Append(@"
namespace GeneratedNamespace
{
    public enum TechnologyTypes
    {
        
");

        foreach (var metadataItem in metadataItems)
        {
            sb.AppendLine(@$"	/// <summary>
            /// {metadataItem.Description}
            /// </summary>");
            
            sb.AppendLine($"{metadataItem.Name} = {metadataItem.Value},");
            
        }
        
        
        sb.AppendLine(@"    }
}");

        var result = sb.ToString();


        return result;
    }
    
}