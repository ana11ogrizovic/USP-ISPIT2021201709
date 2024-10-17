using MediatR;
using Mentor.Application.Common.Dto;
using Mentor.Application.Subject.Queries;
using MongoDB.Driver;

namespace Mentor.Application.Subject.Handlers;

public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, SubjectDetailsDto>
{
    private readonly IMongoCollection<Domain.Entities.Subject> _subjects;

    public GetSubjectByIdQueryHandler(IMongoDatabase database)
    {
        _subjects = database.GetCollection<Domain.Entities.Subject>("Subjects");
    }

    public async Task<SubjectDetailsDto> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        var subject = await _subjects.Find(s => s.SubjectId == request.Id).FirstOrDefaultAsync();

        if (subject == null) return null;

        return new SubjectDetailsDto()
        {
            SubjectId = subject.SubjectId,
            Name = subject.Name,
            Description = subject.Description,
            Type = subject.Type
        };
    }
}