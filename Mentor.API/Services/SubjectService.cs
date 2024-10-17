namespace Mentor.API.Services;

public interface SubjectService : ISubjectService
{
    public async Task<string>Get() => "Ana";

    public async Task<string> Create() => "Created!";
}