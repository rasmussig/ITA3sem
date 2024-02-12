using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Liste til at holde vores tasks - Simuleret in-memory db.
List<TodoTask> todoTasks = new List<TodoTask>();

// GET /api/tasks - Henter alle Todo-opgaver
app.MapGet("/api/tasks", () => todoTasks);

// GET /api/tasks/{id} - Henter en specifik Todo-opgave
app.MapGet("/api/tasks/{id}", (int id) =>
{
    foreach (var task in todoTasks)
    {
        if (task.Id == id)
        {
            return Results.Ok(task);
        }
    }
    return Results.NotFound("Todo-opgave ikke fundet.");
});

// POST /api/tasks - Opretter en ny Todo-opgave
app.MapPost("/api/tasks", (TodoTask newTask) =>
{
    int newId;
    if (todoTasks.Any())
    {
        newId = todoTasks.Max(t => t.Id) + 1;
    }
    else
    {
        newId = 1;
    }

    var taskToAdd = new TodoTask(newId, newTask.Text, newTask.Done);
    todoTasks.Add(taskToAdd);

    return Results.Created($"/api/tasks/{taskToAdd.Id}", taskToAdd);
});

// PUT /api/tasks/{id} - Opdaterer en eksisterende Todo-opgave
app.MapPut("/api/tasks/{id}", (int id, TodoTask updatedTask) =>
{
    for (int i = 0; i < todoTasks.Count; i++)
    {
        if (todoTasks[i].Id == id)
        {
            var taskToUpdate = todoTasks[i];
            var updatedTodoTask = new TodoTask(taskToUpdate.Id, updatedTask.Text, updatedTask.Done);
            todoTasks[i] = updatedTodoTask;
            return Results.NoContent();
        }
    }
    return Results.NotFound("Todo-opgave ikke fundet.");
});

// DELETE /api/tasks/{id} - Sletter en specifik Todo-opgave
app.MapDelete("/api/tasks/{id}", (int id) =>
{
    for (int i = 0; i < todoTasks.Count; i++)
    {
        if (todoTasks[i].Id == id)
        {
            todoTasks.RemoveAt(i);
            return Results.NoContent();
        }
    }
    return Results.NotFound("Todo-opgave ikke fundet.");
});

app.Run();

record TodoTask(int Id, string Text, bool Done);
