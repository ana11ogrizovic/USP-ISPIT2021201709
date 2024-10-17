using Mentor.Application.Common.Dto;
using Mentor.BaseTests.Builders.Dto;

namespace Mentor.BaseTests.Builders.Commands;

public class AddMentorCommandBuilder
{
    private MentorDetailsDto _dto = new AddMentorDtoBuilder().Build();

    public AddMentorCommandBuilder WithDto(MentorDetailsDto dto)
    {
        _dto = dto;
        return this;
    }
}