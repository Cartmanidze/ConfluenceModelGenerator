using System.Text;
using ConfluenceModelGenerator.Application.Extensions;
using ConfluenceModelGenerator.Application.Models;
using ConfluenceModelGenerator.Application.Services.Interfaces;
using Flurl;
using Flurl.Http;

namespace ConfluenceModelGenerator.Application.Services;

public class Translator : ITranslator
{
    public async Task<string> TranslateAsync(string value, CancellationToken token)
    {
        var url = new Url("https://api.reverso.net/translate/v1/translation");

        var response = await url.PostJsonAsync(new
        {
            format = "text",
            from = "rus",
            input = value,
            options = new {sentenceSplitter = true, origin =  "translation.web", contextResults =  true, languageDetection = true },
            to = "eng"
        }, token);

        var jsonResponse = await response.GetJsonAsync<TranslateResult>();

        var result = new StringBuilder();

        if (jsonResponse.Translation.Length > 0)
        {
            var translation = jsonResponse.Translation[0];
            
            foreach (var translationPart in translation.Split(' ', '-', ')', '(', ';', ':', '.'))
            {
                if (!string.IsNullOrWhiteSpace(translationPart))
                {
                    result.Append(translationPart.FirstCharToUpper().Trim()); 
                }
            }
        }

        return result.ToString();
    }
}