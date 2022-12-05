using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ConfluenceModelGenerator.Application.Models;

namespace ConfluenceModelGenerator.Application.Services;

public class EnumTableMetadataParser : MetadataParserBase<EnumMetadata>
{
    protected override async Task<List<EnumMetadata>> ProtectedGetMetadataAsync(IParentNode document, string selector, CancellationToken token)
    {
        var translator = new Translator();
        
        var result = new List<EnumMetadata>();
        
        var table = document.QuerySelector<IHtmlTableElement>(selector);

        var keys = new List<string>();

        var isHeader = true;

        var count = 0;
        
        foreach (var row in table!.Rows)
        {
            var metadata = new EnumMetadata();
            
            foreach (var cell in row.Cells)
            {
                if (isHeader)
                {
                    keys.Add(cell.TextContent);
                }
                else
                {
                    if (keys[count] == "Id")
                    {
                        metadata.Value = cell.TextContent;
                    }
                    else if (keys[count] == "Name")
                    {
                        metadata.Name = cell.TextContent;

                        metadata.Description = await translator.TranslateAsync(cell.TextContent, token);
                    }
                    else
                    {
                        continue;
                    }

                    result.Add(metadata);
                    
                    count++;
                }
            }
            
            if (isHeader)
            {
                isHeader = false;
            }

            count = 0;

        }

        return result;
    }
}