using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BDD.Hooks;

public class Variables
{
    //private static Config _configuration;
    private static readonly Lazy<Config> Configuration = new(() =>
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
        return configurationBuilder.Build().Get<Config>();
    });

    public static string SelectDropDownUrl = $"{Configuration.Value.BaseUrl}/demo-site/select-dropdown-menu/";
    public static string SubmitDataUrl = $"{Configuration.Value.BaseUrl}/samplepagetest/";
    public static string ProgressBar = $"{Configuration.Value.BaseUrl}/demo-site/progress-bar/";
    // ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
    // configurationBuilder.AddJsonFile("appsettings.json");
    // IConfigurationRoot configuration = configurationBuilder.Build();
    // configuration.Bind(_config);
}