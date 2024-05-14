public class User
{
    public string Name { get; set; }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    
    public User(string name)
    {
        Name = name;
    }

}