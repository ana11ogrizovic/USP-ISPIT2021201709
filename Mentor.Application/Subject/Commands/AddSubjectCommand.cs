using MediatR;

namespace Mentor.Application.Subject.Commands;

public class AddSubjectCommand : IRequest<int>
{
    public int SubjectId { get; set; }  // Ako se SubjectId postavlja ručno
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}