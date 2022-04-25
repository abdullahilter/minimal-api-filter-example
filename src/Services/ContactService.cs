using Microsoft.EntityFrameworkCore;
using MinimalApiFilterExample.Models;

namespace MinimalApiFilterExample.Services;

public class ContactService : IContactService
{
    private readonly ExampleContext _context;

    public ContactService(ExampleContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        ArgumentNullException.ThrowIfNull(contact, nameof(contact));

        _context.Contacts.Remove(contact);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        var contacts = await _context.Contacts.ToListAsync();

        return contacts;
    }

    public async Task<Contact?> GetAsync(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        return contact;
    }

    public async Task<bool> UpdateAsync(Contact contact)
    {
        _context.Contacts.Update(contact);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}