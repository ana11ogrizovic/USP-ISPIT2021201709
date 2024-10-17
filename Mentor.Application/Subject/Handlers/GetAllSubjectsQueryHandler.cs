using MediatR;
using Mentor.Application.Common.Dto;
using Mentor.Application.Subject.Queries;
using MongoDB.Driver;

namespace Mentor.Application.Subject.Handlers;

public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, List<SubjectDetailsDto>>
{
    private readonly IMongoCollection<Domain.Entities.Subject> _subjects;

    public GetAllSubjectsQueryHandler(IMongoDatabase database)
    {
        _subjects = database.GetCollection<Domain.Entities.Subject>("Subjects");
    }

    public async Task<List<SubjectDetailsDto>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
    {
        var subjects = await _subjects.Find(_ => true).ToListAsync();

        return subjects.Select(s => new SubjectDetailsDto()
        {
            SubjectId = s.SubjectId,
            Name = s.Name,
            Description = s.Description,
            Type = s.Type
        }).ToList();
    }
}