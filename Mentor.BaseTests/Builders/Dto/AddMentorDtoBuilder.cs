using Mentor.Application.Common.Dto;

namespace Mentor.BaseTests.Builders.Dto;

public class AddMentorDtoBuilder
{
    private readonly MentorDetailsDto _mentorDto;
    
    public AddMentorDtoBuilder() 
    { 
        _mentorDto = new MentorDetailsDto();
    }
    
    public AddMentorDtoBuilder WithId(string id) 
    { 
        _mentorDto.Id = id; 
        return this;
    }

    public AddMentorDtoBuilder WithFirstName(string firstName)
    { 
        _mentorDto.FirstName = firstName; 
        return this;
    }
    
    public AddMentorDtoBuilder WithLastName(string lastName) 
    { 
        _mentorDto.LastName = lastName; 
        return this;
    }
    
    public MentorDetailsDto Build() 
    { 
        return _mentorDto;
    }
}