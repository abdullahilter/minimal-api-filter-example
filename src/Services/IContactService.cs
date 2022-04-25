using MinimalApiFilterExample.Models;

namespace MinimalApiFilterExample.Services;

public interface IContactService
{
    Task<bool> CreateAsync(Contact contact);

    Task<Contact?> GetAsync(Guid id);

    Task<IEnumerable<Contact>> GetAllAsync();

    Task<bool> UpdateAsync(Contact contact);

    Task<bool> DeleteAsync(Guid id);
}