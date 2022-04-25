using Microsoft.EntityFrameworkCore;
using MinimalApiFilterExample.Models;

namespace MinimalApiFilterExample;

public class ExampleContext : DbContext
{
    public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
    {

    }

    public DbSet<Contact> Contacts { get; set; }
}