namespace Mentor.API.Services;

public class MentorService : IMentorService
{
    public async Task<string>Get() => "Ana";

    public async Task<string> Create() => "Created!";
}