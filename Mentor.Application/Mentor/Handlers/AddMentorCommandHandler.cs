using MediatR;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Mentor.Application.Commands;

namespace MongoDB.Driver
{
    public abstract class WriteErrorCategory
    {
        public static ServerErrorCategory DuplicateKey { get; set; }
    }
}

public class AddMentorCommandHandler : IRequestHandler<AddMentorCommand, IActionResult>
{
    private readonly IMongoDatabase _database;
    private readonly IValidator<AddMentorCommand> _validator;

    public AddMentorCommandHandler(IMongoDatabase database, IValidator<AddMentorCommand> validator)
    {
        _database = database;
        _validator = validator;
    }

    public async Task<IActionResult> Handle(AddMentorCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new BadRequestObjectResult(new
            {
                Success = false,
                Errors = validationResult.Errors.Select(e => e.ErrorMessage)
            });
        }

        var mentorsCollection = _database.GetCollection<Mentor.Domain.Entities.Mentor>("Mentors");

        // Proveri da li mentor već postoji
        var existingMentor = await mentorsCollection.Find(m => m.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (existingMentor != null)
        {
            return new ConflictObjectResult(new
            {
                Success = false,
                Message = "Mentor sa ovim ID-em već postoji. ID mora biti jedinstven."
            });
        }

        // Kreiraj novog mentora
        var mentor = new Mentor.Domain.Entities.Mentor
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        try
        {
            await mentorsCollection.InsertOneAsync(mentor, cancellationToken: cancellationToken);
            return new OkObjectResult(new { Success = true, Message = "Mentor added successfully!" });
        }
        catch (MongoWriteException ex) when (ex.WriteError.Category == MongoDB.Driver.WriteErrorCategory.DuplicateKey)
        {
            return new ConflictObjectResult(new
            {
                Success = false,
                Message = "Došlo je do greške: ID mentora mora biti jedinstven."
            });
        }
    }
}
