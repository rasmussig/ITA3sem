
User user1 = new User("Alice");
User user2 = new User("Mallory");
User user3 = new User("Karl");


var HashUser1 = user1.GetHashCode();
var HashUser2 = user2.GetHashCode();
var HashUser3 = user3.GetHashCode();

Console.WriteLine($"HashUser1: {HashUser1}");
Console.WriteLine($"HashUser2: {HashUser2}");
Console.WriteLine($"HashUser3: {HashUser3}");

Console.WriteLine(HashUser1 == user1.GetHashCode());
Console.WriteLine(HashUser1.Equals(user1.GetHashCode()));

Console.WriteLine(user1.Equals(user3));
Console.WriteLine(user1 == user3);
