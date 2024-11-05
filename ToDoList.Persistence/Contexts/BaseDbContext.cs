using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ToDoList.Domain.Entities;
namespace ToDoList.Persistence.Contexts;
public class BaseDbContext : IdentityDbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<Category> Categories { get; set; }
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration): base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}