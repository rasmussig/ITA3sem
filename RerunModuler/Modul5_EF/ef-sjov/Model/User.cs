namespace Model {
    public class User {
        public User(string name) {
            this.Name = name;
        }

        public int UserId { get; set; }
        public string? Name {get; set;}
    }
}