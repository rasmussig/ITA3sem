User user1 = new User("Alice");
User user2 = new User("Alice");
User user3 = new User("Bob");

Console.WriteLine("Hash Code of user1: " + user1.GetHashCode());
Console.WriteLine("Hash Code of user2: " + user2.GetHashCode());
Console.WriteLine("Hash Code of user3: " + user3.GetHashCode());

Console.WriteLine("user1 == user2: " + (user1 == user2));  // Reference equality
Console.WriteLine("user1.Equals(user2): " + user1.Equals(user2));  // Value equality

Console.WriteLine("user1 == user3: " + (user1 == user3));
Console.WriteLine("user1.Equals(user3): " + user1.Equals(user3));