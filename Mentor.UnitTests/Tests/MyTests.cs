using Xunit;

namespace Mentor.UnitTests.Tests;

public class SimpleTests
{
    [Fact]
    public void Should_Return_True()
    {
        // Proveravamo da li true jeste true
        Assert.True(true);
    }

    [Fact]
    public void Should_Return_False()
    {
        // Proveravamo da li false nije true
        Assert.False(false);
    }
}