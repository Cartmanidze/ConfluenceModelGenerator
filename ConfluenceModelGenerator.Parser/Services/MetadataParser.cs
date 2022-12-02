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

        await InnerSubmitAsync(context, dataForParse, token);
        
        var document = await context.OpenAsync(url, token);
        
        var tableSelector = "#main-content > div:nth-child(5) > table > tbody";
        
        var metadata = new Metadata();
        
        InnerGetValues(document, tableSelector, metadata);

        return new Metadata();
    }
    
    private static void InnerGetDescriptions(IParentNode document, string descriptionSelector, Metadata metadata)
    {
        var table = document.QuerySelector<IHtmlTableSectionElement>(descriptionSelector)!;

        var isHeader = true;
        
        var count = 0;

        var keysByNumbers = new Dictionary<int, string>();

        foreach (var row in table.Rows)
        {
            foreach (var cell in row.Cells)
            {
                if (isHeader)
                {
                    keysByNumbers.Add(count, cell.TextContent);
                }
                else
                {
                    var key = keysByNumbers[count];
                }

                count++;
            }

            if (isHeader)
            {
                isHeader = false;
            }

            count = 0;
        }
    }

    private static void InnerGetValues(IParentNode document, string tableSelector, Metadata metadata)
    {
        var metadataItems = new List<Metadata>();
        
        var table = document.QuerySelector<IHtmlTableSectionElement>(tableSelector);

        var isHeader = true;
        
        var count = 0;

        var keys = Array.Empty<string>();

        foreach (var row in table!.Rows)
        {
            foreach (var cell in row.Cells)
            {
                if (isHeader)
                {
                    metadata.Values.Add(cell.TextContent, null);
                    
                    keys[count] = cell.TextContent;
                }
                else
                {
                    metadata.Values[keys[count]] = cell.TextContent;
                }

                count++;
            }

            if (isHeader)
            {
                isHeader = false;
            }


            count = 0;
        }
    }

    private static async Task InnerSubmitAsync(IBrowsingContext context, DataForParse dataForParse, CancellationToken token)
    {
        var document = await context.OpenAsync("https://docs.reo.ru/login.action", token);
        
        var form = document.QuerySelector<IHtmlFormElement>("#login-container > div > form");
        
        var resultDocument = await form!.SubmitAsync(new { os_username = "user", os_password = "pass" });
    }
}