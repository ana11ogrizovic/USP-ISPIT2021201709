using Mentor.UnitTests.Builders.Dto;

public class AddMentorCommand
{
    public AddMentorDto MentorDto { get; }

    public AddMentorCommand(AddMentorDto mentorDto)
    {
        MentorDto = mentorDto;
    }

    public string Execute()
    {
        // Simuliraj izvršenje komande
        return $"Mentor {MentorDto.Name} za predmet {MentorDto.Subject} je dodat.";
    }
}