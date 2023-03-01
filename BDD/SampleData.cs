namespace BDD;

public class SampleData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public int ExperienceInYears { get; set; }
    public bool FunctionalTesting { get; set; }
    public bool AutomationTesting { get; set; }
    public bool ManualTesting { get; set; }
    public bool GraduateEducation { get; set; }
    public bool PostGraduateEducation { get; set; }
    public bool OtherEducation { get; set; }
    public string Comment { get; set; }

    public static SampleData CreateSampleData(string name, string email, string website, int experienceInYears)
    {
        var sampleData = new SampleData()
        {
            Name = name,
            Email = email,
            Website = website,
            ExperienceInYears = experienceInYears,
            ManualTesting = true,
            AutomationTesting = true,
            PostGraduateEducation = true,
            Comment = "Some Comment",
        };
        return sampleData;
    }
}