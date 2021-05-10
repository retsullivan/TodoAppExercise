using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppExercise.Data;
using TodoAppExercise.Models;
using Microsoft.EntityFrameworkCore.Proxies;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;

namespace TodoAppExercise.Pages
{
    public class IndexModel : PageModel { 

    
        private readonly ILogger<IndexModel> _logger;
        private readonly TodoContext _context;

        public IndexModel(ILogger<IndexModel> logger, TodoContext context)
        {
            _logger = logger;
            _context = context;
        }
        public List <TodoItem> myTodoItems { get; set; }

        public async Task OnGetAsync()
        {
            myTodoItems = await _context.TodoItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddItem(string itemName)
        {
            TodoItem newItem = new TodoItem {ItemName = itemName, Toggled = false, Deleted = false, DateTimeCreated = DateTime.Now } ;
            _context.TodoItems.Add(newItem);
            await _context.SaveChangesAsync();
            myTodoItems = await _context.TodoItems.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostToggle(int itemId)
        {
            var item = await _context.TodoItems.FindAsync(itemId);

            if (item != null)
            {
                item.Toggled = !item.Toggled;
                await _context.SaveChangesAsync();
            }
            
            myTodoItems = await _context.TodoItems.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int itemId)
        {
            var item = await _context.TodoItems.FindAsync(itemId);

            if (item != null)
            {
                item.Deleted = true;
                await _context.SaveChangesAsync();
            }

            myTodoItems = await _context.TodoItems.ToListAsync();
            return Page();
        }



    }
}
