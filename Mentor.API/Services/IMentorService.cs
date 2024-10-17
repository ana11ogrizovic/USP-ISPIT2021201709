namespace Mentor.API.Services;

public interface IMentorService
{
    Task<string> Get();
    
    Task<string> Create();
}