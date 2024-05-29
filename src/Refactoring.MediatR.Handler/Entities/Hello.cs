namespace Refactoring.MediatR.Handler.Entities;

public class Hello
{
    public string Name { get; init; } = string.Empty;

    public override string ToString()
    {
        return Name;
    }
}