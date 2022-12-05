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
                        metadata.Name = await translator.TranslateAsync(cell.TextContent, token);

                        metadata.Description = cell.TextContent;
                    }
                    else
                    {
                        continue;
                    }

                    count++;
                }
            }
            
            if (isHeader)
            {
                isHeader = false;
            }
            else
            {
                result.Add(metadata);
            }

            count = 0;

        }

        return result;
    }
}