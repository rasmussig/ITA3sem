using System.Data;
using Model;


using (var db = new BoardContext())
{
    // Opretter en ny bruger
    var user = new User("Rasmus", 22); 
    var user2 = new User("Mads", 22);

    // Opretter en ny opgave og tilknytter brugeren
    // var todo = new Todo("Spis Burger","Mad", false, user); 
    // var todo2 = new Todo("Spis PIZAA","Mad", false, user2);

    // Opretter et nyt board og tilføjer opgaven til dette
    var board = new Board();
    // board.Todos.Add(todo); 
    

    // Tilføjer boardet og gemmer ændringerne
    db.Boards.Add(board);
    db.SaveChanges();
}


