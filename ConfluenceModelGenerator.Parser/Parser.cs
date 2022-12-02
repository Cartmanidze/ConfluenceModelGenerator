
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ConfluenceModelGenerator.Parser;

public class Parser
{
    public async Task ParseAsync(CancellationToken token)
    {
        const string url = "https://docs.reo.ru/pages/viewpage.action?pageId=45255786";

        var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
        
        var context = BrowsingContext.New(config);

        await SubmitAsync(context, token);
        
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
    }

    private async Task SubmitAsync(IBrowsingContext context, CancellationToken token)
    {
        var document = await context.OpenAsync("https://docs.reo.ru/login.action", token);
        
        var form = document.QuerySelector<IHtmlFormElement>("#login-container > div > form");
        
        var resultDocument = await form!.SubmitAsync(new { os_username = "user", os_password = "pass" });
    }
}