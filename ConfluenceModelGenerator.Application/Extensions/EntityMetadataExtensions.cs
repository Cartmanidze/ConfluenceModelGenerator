using ConfluenceModelGenerator.Application.Models;

namespace ConfluenceModelGenerator.Application.Extensions;

internal static class EntityMetadataExtensions
{
    internal static EntityMetadata SetValue(this EntityMetadata entityMetadata, string key, string value)
    {
        switch (key)
        {
            case "Наименование атрибута":
                entityMetadata.Name = value;
                break;
            case "Тип":
                entityMetadata.Type = value;
                break;
            case "Обязательный":
                entityMetadata.IsRequired = string.Equals(value, "да", StringComparison.OrdinalIgnoreCase);
                break;
            case "Описание атрибута":
                entityMetadata.Description = value;
                break;
            default:
                throw new ArgumentException();
        }

        return entityMetadata;
    }
}