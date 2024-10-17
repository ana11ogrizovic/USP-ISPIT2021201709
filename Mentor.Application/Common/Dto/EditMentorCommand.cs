using MediatR;

namespace Mentor.Application.Common.Dto
{
    public class EditMentorCommand : IRequest<bool> // ili IActionResult, u zavisnosti od tvojih potreba
    {
        public EditMentorDto MentorDto { get; }

        public EditMentorCommand(EditMentorDto mentorDto)
        {
            MentorDto = mentorDto;
        }
    }
}