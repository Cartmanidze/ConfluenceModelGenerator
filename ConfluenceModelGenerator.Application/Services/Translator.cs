using ConfluenceModelGenerator.Application.Services.Interfaces;
using Flurl;
using Flurl.Http;

namespace ConfluenceModelGenerator.Application.Services;

public class Translator : ITranslator
{
    public async Task<string> TranslateAsync(string value, CancellationToken token)
    {
        var url = new Url("https://libretranslate.com/translate");

        var response = await url.PostJsonAsync(new
        {
            q = value,
            source = "en",
            target = "ru",
            format = "text",
            api_key = ""
        }, token);

        var result = await response.GetStringAsync();

        return result;
    }
}