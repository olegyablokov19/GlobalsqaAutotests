using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BDD;

public class Variables
{
    public static string SelectDropDownUrl = $"{Hooks.Hooks.Config.BaseUrl}/demo-site/select-dropdown-menu/";
    public static string SubmitDataUrl = $"{Hooks.Hooks.Config.BaseUrl}/samplepagetest/";
    public static string ProgressBar = $"{Hooks.Hooks.Config.BaseUrl}/demo-site/progress-bar/";
    public static string DatePicker = $"{Hooks.Hooks.Config.BaseUrl}/demo-site/datepicker/";
}