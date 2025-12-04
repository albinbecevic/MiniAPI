using MiniAPI;
using Microsoft.EntityFrameworkCore;
using MiniAPI.Models;
using MiniAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

// Sample data test to test url
TaskRepository.CreateTask(new TaskModel
{
    Title = "Sample Task 1",
    Description = "This is the first task",
    DueDate = "2025-12-02"
});

TaskRepository.CreateTask(new TaskModel
{
    Title = "Sample Task 2",
    Description = "Another test task",
    DueDate = "2025-12-03"
});

app.Run();
