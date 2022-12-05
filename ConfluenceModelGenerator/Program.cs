// See https://aka.ms/new-console-template for more information

using ConfluenceModelGenerator.Application.Services;

Console.WriteLine("Start!");

new EnumModelCreator().CreateAsync(null, CancellationToken.None).GetAwaiter().GetResult();

Console.WriteLine("End!");