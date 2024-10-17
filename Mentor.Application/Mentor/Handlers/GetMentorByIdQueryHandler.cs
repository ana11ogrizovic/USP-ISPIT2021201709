using MediatR;
using Mentor.Application.Common.Dto;
using Mentor.Application.Mentor.Queries;
using MongoDB.Driver;

namespace Mentor.Application.Commands;

public class GetMentorByIdQueryHandler : IRequestHandler<GetMentorByIdQuery, MentorDetailsDto>
{
    private readonly IMongoCollection<Domain.Entities.Mentor> _mentors;

    public GetMentorByIdQueryHandler(IMongoDatabase database)
    {
        _mentors = database.GetCollection<Domain.Entities.Mentor>("Mentors");
    }

    public async Task<MentorDetailsDto> Handle(GetMentorByIdQuery request, CancellationToken cancellationToken)
    {
        var mentor = await _mentors.Find(m => m.Id == request.Id).FirstOrDefaultAsync();

        if (mentor == null) return null;

        return new MentorDetailsDto()
        {
            FirstName = mentor.FirstName,
            LastName = mentor.LastName
        };
    }
}