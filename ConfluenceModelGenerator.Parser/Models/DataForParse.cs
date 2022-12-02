using System.Text.Json.Serialization;

namespace ConfluenceModelGenerator.Parser.Models;

public class DataForParse
{
    public DataForParse(string mainUrl, string loginUrl, string formSelector, string descriptionTableSelector, string valuesTableSelector)
    {
        MainUrl = mainUrl;
        LoginUrl = loginUrl;
        FormSelector = formSelector;
        DescriptionTableSelector = descriptionTableSelector;
        ValuesTableSelector = valuesTableSelector;
    }

    [JsonInclude]
    public string MainUrl { get; private set; }

    [JsonInclude]
    public string LoginUrl { get; private set; }
    
    [JsonInclude]
    public string FormSelector { get; private set; }
    
    [JsonInclude]
    public string DescriptionTableSelector { get; private set; }

    [JsonInclude]
    public string ValuesTableSelector { get; private set; }


}