using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Åben op for "CORS" i din API.
// Læs om baggrunden her: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseCors(AllowCors);

// Array til at holde vores tasks - Simuleret in-memory db.
TodoTask[] TaskData = Array.Empty<TodoTask>();

// GET /api/tasks - Henter alle Todo-opgaver
app.MapGet("/api/tasks", () => TaskData);

// GET /api/tasks/{id} - Henter en specifik Todo-opgave
app.MapGet("/api/tasks/{id}", (int id) =>
{
    var task = TaskData.FirstOrDefault(t => t.Id == id);
    if (task != null)
    {
        return Results.Ok(task);
    }
    return Results.NotFound("Todo-opgave ikke fundet.");
});

// POST /api/tasks - Opretter en ny Todo-opgave
app.MapPost("/api/tasks", (TodoTask newTask) =>
{
    int newId;
    if (TaskData.Length > 0)
    {
        newId = TaskData.Max(t => t.Id) + 1;
    }
    else
    {
        newId = 1;
    }

    var taskToAdd = new TodoTask(newId, newTask.Text, newTask.Done);

    //Brug append ? eller Resize i stedet for?
    var taskList = TaskData.ToList();
    taskList.Add(taskToAdd);
    TaskData = taskList.ToArray();

    return Results.Created($"/api/tasks/{taskToAdd.Id}", taskToAdd);
});


// PUT /api/tasks/{id} - Opdaterer en eksisterende Todo-opgave
app.MapPut("/api/tasks/{id}", (int id, TodoTask updatedTask) =>
{
    var taskIndex = Array.FindIndex(TaskData, t => t.Id == id);

    if (taskIndex != -1)
    {
        var updatedTodoTask = new TodoTask(TaskData[taskIndex].Id, updatedTask.Text, updatedTask.Done);
        TaskData[taskIndex] = updatedTodoTask;
        return Results.NoContent();
    }
    return Results.NotFound("Todo-opgave ikke fundet.");
});

// DELETE /api/tasks/{id} - Sletter en specifik Todo-opgave
app.MapDelete("/api/tasks/{id}", (int id) =>
{
    var taskIndex = Array.FindIndex(TaskData, t => t.Id == id);
    if (taskIndex != -1)
    {
        var taskList = TaskData.ToList();
        taskList.RemoveAt(taskIndex);
        TaskData = taskList.ToArray();
        return Results.NoContent();
    }
    return Results.NotFound("Todo-opgave ikke fundet.");
});

app.Run();

record TodoTask(int Id, string Text, bool Done);
