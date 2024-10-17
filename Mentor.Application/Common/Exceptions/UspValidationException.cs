namespace Mentor.Application.Common.Exceptions;

public class UspValidationException : BaseException
{
    public IDictionary<string, string[]> Failures { get; }

    public UspValidationException(IDictionary<string, string[]> failures) 
        : base("One or more validation failures have occurred.", failures)
    {
        Failures = failures ?? new Dictionary<string, string[]>();
    }
}