using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ConfluenceModelGenerator.Application.Models;

namespace ConfluenceModelGenerator.Application.Services;

public class EnumListMetadataParser : MetadataParserBase<EnumMetadata>
{
    protected override async Task<List<EnumMetadata>> ProtectedGetMetadataAsync(IParentNode document, string selector, CancellationToken token)
    {
        var translator = new Translator();
        
        var result = new List<EnumMetadata>();
        
        var list = document.QuerySelector<IHtmlOrderedListElement>(selector);

        var items = list!.TextContent.Split(';');

        var count = 1;
        
        foreach (var item in items)
        {
            var name = await translator.TranslateAsync(item, token);
            
            var value = count.ToString();

            result.Add(new EnumMetadata{Name = name, Value = value, Description = item});
            
            count++;
        }

        return result;
    }
}