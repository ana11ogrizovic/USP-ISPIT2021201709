using MediatR;
using Mentor.Application.Common.Dto;

namespace Mentor.Application.Subject.Queries;

public class GetSubjectByIdQuery : IRequest<SubjectDetailsDto>
{
    public int Id { get; }

    public GetSubjectByIdQuery(int id)
    {
        Id = id;
    }
}