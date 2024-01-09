using Microsoft.EntityFrameworkCore;

namespace Todo.Api;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options) { }

    public DbSet<TodoItem> Todos => Set<TodoItem>();
}

public record TodoItem (int Id, string Title, bool IsCompleted);