using Model;
// TIPS OG TRICKS I BUNDEN:
// https://eaaa.instructure.com/courses/19516/pages/opgaver-5?module_item_id=653564

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");
    
    // Create User
    Console.WriteLine("Opretter User");
    db.Add(new User ("Rasmus"));
    db.SaveChanges();

    // Read User
    Console.WriteLine("Find den sidste user");
    var lastUser = db.Users
        .OrderBy(user => user.UserId)
        .Last();
    Console.WriteLine($"Id for user: {lastUser.UserId}");

    // Create Task, and put user on
    Console.WriteLine("Indsæt et nyt task");
    var user = db.Users.FirstOrDefault();
    db.Add(new TodoTask("En opgave der skal løses", false, "Køkkenet", user));
    db.SaveChanges();

    // Read
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");

    // Update text for task
    Console.WriteLine("Find en task og lav ændringer til den");
    var taskToUpdate = db.Tasks.Where(task => task.TodoTaskId == 3).FirstOrDefault();
    Console.WriteLine($"Task.Text før opdatering {taskToUpdate.Text}");
    taskToUpdate.Text = "Opdateret task";
    db.SaveChanges();

    // Opdater task med user
    Console.WriteLine("Sæt user på task efter oprettelse");
    var task = db.Tasks.Where(task => task.TodoTaskId == 5).FirstOrDefault();
    User userToConnectToTask = db.Users.Where(user => user.UserId == 2).FirstOrDefault();
    task.User = userToConnectToTask;
    db.SaveChanges();
    

    // --Delete en bestemt task
    // Console.WriteLine("Delete en bestemt task");
    // var taskToDelete = db.Tasks.Where(task => task.TodoTaskId == 1).First();
    // Console.WriteLine($"TaskId som slettes {taskToDelete.Text}");
    // db.Remove(taskToDelete);
    // db.SaveChanges();

    // --Delete laveste ID Task
    // Console.WriteLine("Delete laveste taskId");
    // var taskToDeleteLast = db.Tasks.OrderBy(task => task.TodoTaskId).First();
    // Console.WriteLine($"Task som skal slettes: {taskToDeleteLast.Text} \n  \tTasken har Id: {taskToDeleteLast.TodoTaskId}");
    // db.Remove(taskToDeleteLast);
    // db.SaveChanges();
    // var taskWithHighestId = db.Tasks.OrderBy(task => task.TodoTaskId).First();
    // Console.WriteLine($"Den nye task med laveste Id, har ID: {taskWithHighestId.TodoTaskId}");

    // --Delete user with highest ID
    // Console.WriteLine("Delete user with highest ID");
    // var userToDelete = db.Users.OrderBy(user => user.UserId).Last();
    // Console.WriteLine($"User som slettes: {userToDelete.Name} \n  \tUseren har Id: {userToDelete.UserId}");
    // db.Remove(userToDelete);
    // db.SaveChanges();


} 

