namespace ConfluenceModelGenerator.Parser.Tests;

public class ParserTests
{
    [Fact]
    public async Task Parser_test()
    {
        var parser = new Parser();
        
        await parser.ParseAsync(CancellationToken.None);
    }
}