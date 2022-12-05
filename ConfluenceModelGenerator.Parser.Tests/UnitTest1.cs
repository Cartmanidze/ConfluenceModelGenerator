using ConfluenceModelGenerator.Parser.Models;
using ConfluenceModelGenerator.Parser.Services;

namespace ConfluenceModelGenerator.Parser.Tests;

public class ParserTests
{
    [Fact]
    public async Task Parser_test()
    {
        var parser = new EntityMetadataParser();
        
        await parser.ParseAsync(new DataForParse(null, null, null, null, null), CancellationToken.None);
    }
}