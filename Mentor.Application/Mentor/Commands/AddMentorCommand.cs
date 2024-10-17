using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Application.Commands
{
    public class AddMentorCommand :  IRequest<IActionResult>
    {
        public string Id { get; set; }  // Dodaj polje Id
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        
    }
}