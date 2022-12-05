using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ConfluenceModelGenerator.Application.Models;
using ConfluenceModelGenerator.Application.Services.Interfaces;

namespace ConfluenceModelGenerator.Application.Services;

public abstract class MetadataParserBase<TMetadata> : IMetadataParser<TMetadata>
    where TMetadata : IMetadata
{
    public virtual async Task<List<TMetadata>> ParseAsync(DataForParse dataForParse, CancellationToken token)
    {
        var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies();
        
        var context = BrowsingContext.New(config);

        await InnerSubmitAsync(context, dataForParse, token);
        
        var document = await context.OpenAsync(dataForParse.MainUrl, token);
        
        var metadataItems = await ProtectedGetMetadataAsync(document, dataForParse.TableSelector, token);
        
        return metadataItems;
    }

    protected abstract Task<List<TMetadata>> ProtectedGetMetadataAsync(IParentNode document, string selector, CancellationToken token);

    private static async Task InnerSubmitAsync(IBrowsingContext context, DataForParse dataForParse, CancellationToken token)
    {
        var document = await context.OpenAsync(dataForParse.LoginUrl, token);

        var form = document.QuerySelector<IHtmlFormElement>(dataForParse.FormSelector);

        if (form == null)
        {
            return;
        }
        
        await form!.SubmitAsync(new { os_username = dataForParse.Login, os_password = dataForParse.Password });
    }
}