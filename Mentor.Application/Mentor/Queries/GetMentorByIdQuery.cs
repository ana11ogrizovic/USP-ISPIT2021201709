using MediatR;
using Mentor.Application.Common.Dto;

namespace Mentor.Application.Mentor.Queries;

public class GetMentorByIdQuery : IRequest<MentorDetailsDto>
{
    public string Id { get; }

    public GetMentorByIdQuery(string id)
    {
        Id = id;
    }
}