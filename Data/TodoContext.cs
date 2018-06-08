using System;
using Microsoft.EntityFrameworkCore;
using QuickStartWebApi.Models;

namespace QuickStartWebApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItemModel> TodoItems { get; set; }
    }
}
