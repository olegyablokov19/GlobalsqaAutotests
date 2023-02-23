namespace BDD;

public class SampleData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public int ExperienceInYears { get; set; }

    public static SampleData CreateSampleData(string name, string email, string website, int experienceInYears)
    {
        var sampleData = new SampleData()
        {
            Name = name,
            Email = email,
            Website = website,
            ExperienceInYears = experienceInYears,
        };
        return sampleData;
    }
}