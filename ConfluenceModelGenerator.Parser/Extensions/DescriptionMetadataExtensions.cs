using ConfluenceModelGenerator.Parser.Models;

namespace ConfluenceModelGenerator.Parser.Extensions;

internal static class DescriptionMetadataExtensions
{
    internal static Metadata SetValue(this Metadata metadata, string key, string value)
    {
        switch (key)
        {
            case "Наименование атрибута":
                metadata.Name = value;
                break;
            case "Тип":
                metadata.Type = value;
                break;
            case "Обязательный":
                metadata.IsRequired = value == "Да";
                break;
            case "Описание атрибута":
                metadata.Description = value;
                break;
        }

        throw new ArgumentException();
    }
}