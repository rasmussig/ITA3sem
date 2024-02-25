using System.Data;
using Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");
    
    // Create
    Console.WriteLine("Indsæt et nyt task");
    //db.Add(new TodoTask("En opgave der skal løses", false));
    db.SaveChanges();

    // Read
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");

    //Update
    Console.WriteLine("Opdater en task");

    var taskToUpdate = db.Tasks.Where(task => task.TodoTaskId == 5).FirstOrDefault();
    Console.WriteLine($"Task.Text før opdatering {taskToUpdate.Text}");
    taskToUpdate.Text = "Opdateret task";
    db.SaveChanges();
    Console.WriteLine($"{taskToUpdate}");
    Console.WriteLine($"Task.Text Efter opdatering {taskToUpdate.Text}");

    //Delete
    Console.WriteLine("Delete en task");

    var taskToDelete = db.Tasks.Where(task => task.TodoTaskId == 9).FirstOrDefault();
    Console.WriteLine($"Task.TodoTaskId som slettes er: {taskToDelete.TodoTaskId}");
    db.Tasks.Remove(taskToDelete);
    db.SaveChanges();

}