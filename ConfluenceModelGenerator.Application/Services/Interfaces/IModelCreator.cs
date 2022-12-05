namespace ConfluenceModelGenerator.Application.Services.Interfaces;

public interface IModelCreator
{
    Task<string> CreateAsync(string path, CancellationToken token);
}