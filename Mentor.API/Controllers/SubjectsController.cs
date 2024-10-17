using FluentValidation;
using MediatR;
using Mentor.Application.Common.Exceptions;
using Mentor.Application.Subject.Commands;
using Mentor.Application.Subject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<AddSubjectCommand> _validator;

    public SubjectsController(IMediator mediator, IValidator<AddSubjectCommand> validator)
    {
        _mediator = mediator;
        _validator = validator;
    }
    // POST: api/subjects
    [HttpPost]
    public async Task<IActionResult> AddSubject([FromBody] AddSubjectCommand command)
    {
        // Validacija
        var validationResult = await _validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(g => g.Key, g => g.ToArray());

            return BadRequest(new { Errors = errors });
        }

        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    // GET: api/subjects/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubjectById(int id)
    {
        var query = new GetSubjectByIdQuery(id);
        var subject = await _mediator.Send(query);
        return Ok(subject);
    }

    // GET: api/subjects
    [HttpGet]
    public async Task<IActionResult> GetAllSubjects()
    {
        var query = new GetAllSubjectsQuery();
        var subjects = await _mediator.Send(query);
        return Ok(subjects);
    }

}