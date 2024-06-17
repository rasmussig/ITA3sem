public class User {
    public string Name { get; set; }
    public User(string name) {
        Name = name;
    }
    public override int GetHashCode() {
        return Name.GetHashCode();
    }

    public override bool Equals(object obj) {
        if (obj is User user) {
            return Name == user.Name;
        }
        return false;
    }
}