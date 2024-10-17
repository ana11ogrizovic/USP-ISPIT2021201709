namespace Mentor.API.Services;

public interface ISubjectService
{
    Task<string> Get();
    
    Task<string> Create();
}