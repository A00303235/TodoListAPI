﻿using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<ToDoItem> ToDoItems { get; set; } 
}
