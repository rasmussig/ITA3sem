namespace Model
{
    public class User
    {
        public User() { } // Parameterløs konstruktor

        public User(string name, int age) {
            this.Name = name;
            this.Age = age;
        }     
        public long UserId { get; set; } // Primær-nøgle
        public int? Age { get; set; }
        public string? Name { get; set; }
    }
}