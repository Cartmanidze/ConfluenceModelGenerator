using ConfluenceModelGenerator.Application.Models;

namespace ConfluenceModelGenerator.Application.Services.Interfaces;

public interface IMetadataParser<TMetadata> where TMetadata : IMetadata
{
    Task<List<TMetadata>> ParseAsync(DataForParse dataForParse, CancellationToken token);
}