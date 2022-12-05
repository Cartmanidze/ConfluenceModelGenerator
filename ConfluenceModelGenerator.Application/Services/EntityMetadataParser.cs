using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ConfluenceModelGenerator.Application.Extensions;
using ConfluenceModelGenerator.Application.Models;

namespace ConfluenceModelGenerator.Application.Services;

public class EntityMetadataParser : MetadataParserBase<EntityMetadata>
{
    protected override Task<List<EntityMetadata>> ProtectedGetMetadataAsync(IParentNode document, string selector, CancellationToken token)
    {
        var metadataItems = new List<EntityMetadata>();
        
        var table = document.QuerySelector<IHtmlTableElement>(selector)!;

        var isHeader = true;
        
        var count = 0;

        var keysByNumbers = new Dictionary<int, string>();

        foreach (var row in table.Rows)
        {
            var metadata = new EntityMetadata();
            
            foreach (var cell in row.Cells)
            {
                if (isHeader)
                {
                    keysByNumbers.Add(count, cell.TextContent);
                }
                else
                {
                    var key = keysByNumbers[count];

                    metadata.SetValue(key, cell.TextContent);
                }

                count++;
            }

            if (isHeader)
            {
                isHeader = false;
            }
            else
            {
                metadataItems.Add(metadata);
            }

            count = 0;
        }

        return Task.FromResult(metadataItems);
    }
}