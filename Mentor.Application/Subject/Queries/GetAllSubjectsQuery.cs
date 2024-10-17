using MediatR;
using Mentor.Application.Common.Dto;

namespace Mentor.Application.Subject.Queries;

    public class GetAllSubjectsQuery : IRequest<List<SubjectDetailsDto>>
    {
    }
