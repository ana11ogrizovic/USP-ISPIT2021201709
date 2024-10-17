namespace Mentor.Application.Common.Dto
{
    public class EditMentorDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; }
     

        public EditMentorDto(string firstName, string lastName)
        {
          
            FirstName = firstName;
            LastName = lastName;
        }

        public EditMentorDto()
        {
            throw new NotImplementedException();
        }
    }
}