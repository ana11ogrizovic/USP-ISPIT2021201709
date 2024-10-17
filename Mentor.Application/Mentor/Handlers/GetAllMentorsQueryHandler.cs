using MediatR;
using Mentor.Application.Common.Dto;
using Mentor.Application.Mentor.Queries;
using MongoDB.Driver;

namespace Mentor.Application.Commands;

public class GetAllMentorsQueryHandler : IRequestHandler<GetAllMentorsQuery, List<MentorDetailsDto>>
{
    private readonly IMongoCollection<Domain.Entities.Mentor> _mentors;

    public GetAllMentorsQueryHandler(IMongoDatabase database)
    {
        _mentors = database.GetCollection<Domain.Entities.Mentor>("Mentors");
    }

    public async Task<List<MentorDetailsDto>> Handle(GetAllMentorsQuery request, CancellationToken cancellationToken)
    {
        var mentors = await _mentors.Find(_ => true).ToListAsync();

        return mentors.Select(m => new MentorDetailsDto()
        {
            FirstName = m.FirstName,
            LastName = m.LastName
        }).ToList();
    }
}