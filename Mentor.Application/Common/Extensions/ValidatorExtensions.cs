using FluentValidation.Results;

namespace Mentor.Application.Common.Extensions;

public static class ValidationExtensions
{
    public static IDictionary<string, string[]> ToGroup(this IEnumerable<ValidationFailure> validationFailures)
    {
        return validationFailures
            .GroupBy(failure => failure.PropertyName, failure => failure.ErrorMessage)
            .ToDictionary(group => group.Key, group => group.ToArray());
    }
}