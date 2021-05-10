using Microsoft.EntityFrameworkCore;
using TodoAppExercise.Models;

namespace TodoAppExercise.Data
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext>options): base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<TodoItem>().ToTable("TodoItem");
        }

    }
}
