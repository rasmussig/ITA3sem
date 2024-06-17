namespace Model
{
    public class Board
    {
        public Board()
        {
        }

        public long BoardId { get; set; }

        // En liste af Todo'er
        public List<Todo> Todos {get; set;} = new List<Todo>();
    }

}