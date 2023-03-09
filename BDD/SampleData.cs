using BDD.Pages;
using OpenQA.Selenium;

namespace BDD;

public class SampleData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public int ExperienceInYears { get; set; }
    public string FunctionalTesting { get; set; } = "Functional Testing";
    public string AutomationTesting { get; set; } = "Automation Testing";
    public string ManualTesting { get; set; } = "Manual Testing";
    public string GraduateEducation { get; set; } = "Graduate";
    public string PostGraduateEducation { get; set; } = "Post Graduate";
    public string OtherEducation { get; set; } = "Other";
    public string Comment { get; set; }

    public static SampleData CreateSampleData()
    {
        var sampleData = new SampleData()
        {
            Name = "Oleg",
            Email = "myemail@mail.com",
            Website = "https://www.google.de/",
            ExperienceInYears = 6,
            Comment = "Some Comment",
        };
        return sampleData;
    }
}