namespace Mentor.UnitTests.Builders.Dto;

public class AddMentorDto
{
    public string Name { get; set; }
    public string Subject { get; set; }

    public AddMentorDto(string name, string subject)
    {
        Name = name;
        Subject = subject;
    }
}