namespace ConfluenceModelGenerator.Application.Models;

public class DataForParse
{
    public DataForParse(string mainUrl, string loginUrl, string formSelector, string tableSelector,
        string login, string password)
    {
        MainUrl = mainUrl;
        LoginUrl = loginUrl;
        FormSelector = formSelector;
        TableSelector = tableSelector;
        Login = login;
        Password = password;
    }
    
    public string MainUrl { get; set; }
    
    public string LoginUrl { get; set; }
    
    public string FormSelector { get; set; }
    
    public string TableSelector { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}