using ConfluenceModelGenerator.Parser.Models;

namespace ConfluenceModelGenerator.Parser.Services.Interfaces;

public interface IMetadataParser
{
    Task<Metadata> ParseAsync(DataForParse dataForParse, CancellationToken token);
}