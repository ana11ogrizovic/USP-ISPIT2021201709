using MediatR;
using Mentor.Application.Subject.Commands;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Mentor.Application.Subject.Handlers
{
    public class AddSubjectCommandHandler : IRequestHandler<AddSubjectCommand, int>
    {
        private readonly IMongoCollection<Domain.Entities.Subject> _subjects;

        public AddSubjectCommandHandler(IMongoDatabase database)
        {
            _subjects = database.GetCollection<Domain.Entities.Subject>("Subjects");
        }

        public async Task<int> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = new Domain.Entities.Subject
            {
                SubjectId = request.SubjectId, // Postavi SubjectId
                Name = request.Name,
                Description = request.Description,
                Type = request.Type
            };

            await _subjects.InsertOneAsync(subject, cancellationToken: cancellationToken);
            return subject.SubjectId; // Vraća SubjectId
        }
    }
}