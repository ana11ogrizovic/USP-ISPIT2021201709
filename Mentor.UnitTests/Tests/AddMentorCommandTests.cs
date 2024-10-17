using Mentor.UnitTests.Builders.Dto;
using Xunit;

namespace Mentor.UnitTests.Tests
{
    public class AddMentorCommandTests
    {
        [Fact]
        public void Execute_ReturnsCorrectMessage_WhenAddingMentor()
        {
            // Arrange
            var mentorDto = new AddMentorDto("Milos", "Matematika");
            var command = new AddMentorCommand(mentorDto);

            // Act
            var result = command.Execute();

            // Assert
            Assert.Equal("Mentor Milos za predmet Matematika je dodat.", result);
            Console.WriteLine("Test Execute_ReturnsCorrectMessage_WhenAddingMentor prošao!");
        }

        [Fact]
        public void AddMentorDto_CanBeCreated_WithValidData()
        {
            // Arrange
            var name = "Milos";
            var subject = " Matematika ";

            // Act
            var mentorDto = new AddMentorDto(name, subject);

            // Assert
            Assert.Equal(name, mentorDto.Name);
            Assert.Equal(subject, mentorDto.Subject);
            Console.WriteLine("Test AddMentorDto_CanBeCreated_WithValidData prošao!");
        }
    }
}