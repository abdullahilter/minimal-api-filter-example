namespace MinimalApiFilterExample.Models;

public class Contact
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; init; } = default!;

    public string Surname { get; init; } = default!;

    public string UserName { get; init; } = default!;

    public string EmailAddress { get; init; } = default!;

    public DateTime DateOfBirth { get; set; }
}