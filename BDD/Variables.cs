using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BDD;

public class Variables
{
    //This is taken from TestAutomation solution Variables class;
    //I implemented JSON binding differently in Hooks class
   /* private static readonly Lazy<Config> Configuration = new(() =>
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string pathToJsonFile = currentDirectory + @"..\..\..\..\appsettings.json";
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(pathToJsonFile);
        return configurationBuilder.Build().Get<Config>();
    });*/

    public static string SelectDropDownUrl = $"{Hooks.Hooks.Config.BaseUrl}/demo-site/select-dropdown-menu/";
    public static string SubmitDataUrl = $"{Hooks.Hooks.Config.BaseUrl}/samplepagetest/";
    public static string ProgressBar = $"{Hooks.Hooks.Config.BaseUrl}/demo-site/progress-bar/";
    public static string DatePicker = $"{Hooks.Hooks.Config.BaseUrl}/demo-site/datepicker/";
}