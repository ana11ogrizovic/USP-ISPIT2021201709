using MediatR;
using Mentor.Application.Commands;
using Mentor.Application.Mentor.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorController : ControllerBase
{
    private readonly IMediator _mediator;

    public MentorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddMentor([FromBody] AddMentorCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
        
        
    }
    
    // GET: api/mentors
    [HttpGet]
    public async Task<IActionResult> GetAllMentors()
    {
        var query = new GetAllMentorsQuery();
        var mentors = await _mediator.Send(query);
        return Ok(mentors);
    }

    // GET: api/mentors/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMentorById(string id)
    {
        var query = new GetMentorByIdQuery(id);
        var mentor = await _mediator.Send(query);
        if (mentor == null) return NotFound();
        return Ok(mentor);
    }
    
    
}