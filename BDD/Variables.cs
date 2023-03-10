using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BDD;

public class Variables
{
    private string path = Directory.GetCurrentDirectory();
    private static readonly Lazy<Config> Configuration = new(() =>
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string pathToJsonFile = currentDirectory + @"..\..\..\..\appsettings.json";
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(pathToJsonFile);
        return configurationBuilder.Build().Get<Config>();
    });

    public static string SelectDropDownUrl = $"{Configuration.Value.BaseUrl}/demo-site/select-dropdown-menu/";
    public static string SubmitDataUrl = $"{Configuration.Value.BaseUrl}/samplepagetest/";
    public static string ProgressBar = $"{Configuration.Value.BaseUrl}/demo-site/progress-bar/";
}