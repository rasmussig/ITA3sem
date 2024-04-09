using LinkedList;

User kristian = new User("Kristian", 3);
User mads = new User("Mads", 2);
User torill = new User("Torill", 1);
User kell = new User("Kell", 6);
User henrik = new User("Henrik", 5);
User klaus = new User("Klaus", 4);

SortedUserLinkedList list = new SortedUserLinkedList();

// Tilføjer brugere til listen. Som bliver sorteret med Add-metoden
list.Add(kristian);
list.Add(mads);
list.Add(torill);
list.Add(kell);
list.Add(henrik);
list.Add(klaus);

Console.WriteLine("Antal brugere i listen: " + list.CountUsers());
Console.WriteLine("Liste af brugere: " + list);
Console.WriteLine("Er mads på listen ??: " + list.Contains(mads));

list.RemoveUser(mads);
list.RemoveFirst(); 

Console.WriteLine("Antal brugere i listen efter fjernelse: " + list.CountUsers());
Console.WriteLine("Liste af brugere efter fjernelse: " + list);

Console.WriteLine("Er kristian på listen??: " + list.Contains(kristian));
Console.WriteLine("Er mads stadig på listen??: " + list.Contains(mads));