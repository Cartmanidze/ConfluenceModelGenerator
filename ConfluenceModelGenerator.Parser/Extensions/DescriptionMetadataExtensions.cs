using ConfluenceModelGenerator.Parser.Models;

namespace ConfluenceModelGenerator.Parser.Extensions;

internal static class DescriptionMetadataExtensions
{
    internal static DescriptionMetadata SetValue(this DescriptionMetadata descriptionMetadata, string key, string value)
    {
        switch (key)
        {
            case "Наименование атрибута":
                descriptionMetadata.Name = value;
                break;
            case "Тип":
                descriptionMetadata.Type = value;
                break;
            case "Обязательный":
                descriptionMetadata.IsRequired = value == "Да";
                break;
            case "Описание атрибута":
                descriptionMetadata.Description = value;
                break;
        }

        throw new ArgumentException();
    }
}