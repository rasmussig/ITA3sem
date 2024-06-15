using Microsoft.Net.Http.Headers;

namespace Model
{
    public class Todo
    {
        public Todo(string title, bool done, User user) {
            this.Title = title;
            this.Done = done;
            this.User = user;
        }

         public Todo(string title, bool done) {
            this.Title = title;
            this.Done = done;
        }  

        public long TodoId { get; set; }
        public string? Title { get; set; }
        public bool Done { get; set; }
        public long? UserId {get ; set;}
        public User? User {get; set;}

    }
}