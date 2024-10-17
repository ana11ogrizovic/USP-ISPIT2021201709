using MediatR;
using Mentor.Application.Common.Dto;

namespace Mentor.Application.Mentor.Queries;

public class GetAllMentorsQuery : IRequest<List<MentorDetailsDto>>
{
}