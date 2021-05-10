using System;
using System.Linq;
using TodoAppExercise.Models;


namespace TodoAppExercise.Data
{
    public class DBInitializer
    {
        public static void Initialize(TodoContext context)
        {
            if (context.TodoItems.Any())
            {
                return; //DB has already been seeded
            }

            TodoItem todoItem = new TodoItem { ItemName = "Add something to the Todo List", Toggled = false, Deleted = false, DateTimeCreated = DateTime.Now };

            context.TodoItems.Add(todoItem);
            context.SaveChanges();
         }
    }
}
