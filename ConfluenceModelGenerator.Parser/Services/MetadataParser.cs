using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ConfluenceModelGenerator.Parser.Models;
using ConfluenceModelGenerator.Parser.Services.Interfaces;

namespace ConfluenceModelGenerator.Parser.Services;

public class MetadataParser : IMetadataParser
{
    public async Task<Metadata> ParseAsync(DataForParse dataForParse, CancellationToken token)
    {
        const string url = "https://docs.reo.ru/pages/viewpage.action?pageId=45255786";

        var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
        
        var context = BrowsingContext.New(config);

        await SubmitAsync(context, dataForParse, token);
        
        var document = await context.OpenAsync(url, token);
        
        var tableSelector = "#main-content > div:nth-child(5) > table > tbody";
        
        var table = document.QuerySelector<IHtmlTableSectionElement>(tableSelector)!;

        foreach (var row in table.Rows)
        {
            foreach (var cell in row.Cells)
            {
                var localCell = cell;
            }
        }

        return new Metadata();
    }
    
    private static async Task SubmitAsync(IBrowsingContext context, DataForParse dataForParse, CancellationToken token)
    {
        var document = await context.OpenAsync("https://docs.reo.ru/login.action", token);
        
        var form = document.QuerySelector<IHtmlFormElement>("#login-container > div > form");
        
        var resultDocument = await form!.SubmitAsync(new { os_username = "user", os_password = "pass" });
    }
}