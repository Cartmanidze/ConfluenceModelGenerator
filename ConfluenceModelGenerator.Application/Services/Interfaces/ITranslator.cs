namespace ConfluenceModelGenerator.Application.Services.Interfaces;

public interface ITranslator
{
    Task<string> TranslateAsync(string value, CancellationToken token);
}