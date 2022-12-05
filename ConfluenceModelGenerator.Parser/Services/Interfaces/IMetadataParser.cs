using ConfluenceModelGenerator.Parser.Models;

namespace ConfluenceModelGenerator.Parser.Services.Interfaces;

public interface IMetadataParser
{
    Task<List<Metadata>> ParseAsync(DataForParse dataForParse, CancellationToken token);
}