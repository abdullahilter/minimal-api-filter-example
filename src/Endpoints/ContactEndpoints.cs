using FluentValidation;
using MinimalApiFilterExample.Filters;
using MinimalApiFilterExample.Models;
using MinimalApiFilterExample.Services;

namespace MinimalApiFilterExample.Endpoints;

public static class ContactEndpoints
{
    public static void MapContactEndpoints(this WebApplication app)
    {
        app.MapPost("contacts", CreateAsync).AddFilter<ValidatorFilter<Contact>>();
        app.MapGet("contacts", GetAllAsync);
        app.MapGet("contacts/{id:guid}", GetAsync);
        app.MapDelete("contacts/{id:guid}", DeleteAsync);
    }

    public static async Task<IResult> CreateAsync(
        Contact contact,
        IValidator<Contact> validator,
        IContactService contactService,
        CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(contact, cancellationToken);

        if (false == result.IsValid)
            return Results.BadRequest(result.Errors.Select(s => s.ErrorMessage));

        await contactService.CreateAsync(contact);

        return Results.Created($"/contacts/{contact.Id}", contact);
    }

    public static async Task<IResult> GetAllAsync(IContactService contactService)
    {
        var contacts = await contactService.GetAllAsync();

        return Results.Ok(contacts);
    }

    public static async Task<IResult> GetAsync(Guid id, IContactService contactService)
    {
        var contact = await contactService.GetAsync(id);

        if (contact is null)
            return Results.NotFound();

        return Results.Ok(contact);
    }

    public static async Task<IResult> DeleteAsync(Guid id, IContactService contactService)
    {
        var result = await contactService.DeleteAsync(id);

        if (false == result)
            return Results.NotFound();

        return Results.NoContent();
    }
}