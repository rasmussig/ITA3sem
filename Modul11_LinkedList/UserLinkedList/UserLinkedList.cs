namespace LinkedList
{
    class Node
    {
    
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
        }

        // AddLast
        public void AddLast(User user)
        {
            Node node = new Node(user, null);
            if (first == null)
            {
                first = node;
            }
            else
            {
                // Sætte en variabel til at holde den sidste node
                Node last = first;
                // Gå igennem listen indtil vi finder den sidste node
                while (last.Next != null)
                {
                    last = last.Next;
                }
                // Sæt den sidste nodes Next til den nye node
                last.Next = node;
            }
        }

        public User RemoveFirst()
        {
            // TODO: Implement!
            if (first == null) // Hvis listen er tom
            {
                return null;
            }

            else
            {
                Node node = first;  // Gemmer første node i en variabel
                first = first.Next; // Første node bliver nu den næste node i listen
                return node.Data;   // Returnere data fra den første node (Den slettede node) 
            }
            return null;
        }

        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        //RemoveLast
        public User RemoveLast()
        {
            if (first == null) // Hvis listen er tom
            {
                return null;
            }

            else if (first.Next == null) // Hvis der kun er en node i listen
            {
                Node node = first;
                first = null;
                return node.Data;
            }

            else
            {
                Node node = first;
                Node previous = null;

                // Gå igennem listen indtil vi finder den sidste node
                while (node.Next != null)
                {
                    previous = node;
                    node = node.Next;
                }
                
                // Sæt den næstsidste node.Next til null, for at fjerne den sidste node
                previous.Next = null;
                return node.Data;
            }
        }

        public User GetFirst()
        {
            return first.Data;
        }

        public User GetLast()
        {
            for (Node node = first; node != null; node = node.Next)
            // Startværdi: node = first;
            // Betingelse: node != null;
            // Iteration: node = node.Next
            {
                if (node.Next == null)
                {
                    return node.Data;
                }
            }
            // TODO: Implement
            return null!;
        }

        public int CountUsers()
        {
            int count = 0; // Variabel til at holde antal

            for (Node node = first; node != null; node = node.Next)
            {
                count += 1;
            }

            // TODO: Implement
            return count;
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }

        public bool Contains(User user)
        { 
            for (Node node = first; node != null; node = node.Next) 
            {
                // Console.WriteLine(node.Data.Name); // --logger "console;verbosity=detailed" 
                if (node.Data.Name == user.Name) 
                {
                    Console.WriteLine($"Brugeren {user.Name} findes i listen: ");
                    return true;
                }
            }

            return false;
        }

        //Listen er tom
        public bool IsEmpty()
        {
            if (first == null)
            {
                return true;
            }
            return false;
        }

        //Average age
        // public double AverageAge()
        // {
        //     double sum = 0;
        //     int count = 0;

        //     for (Node node = first; node != null; node = node.Next)
        //     {
        //         sum += node.Data.Age;
        //         count++;
        //     }

        //     return sum / count;
        // }

        // // CountUsers, men hvor mange som er en bestemt alder
        // public int CountUsers(int age) 
        // {
        //     int count = 0;

        //     for (Node node = first; node != null; node = node.Next)
        //     {
        //         if (node.Data.Age == age)
        //         {
        //             count++;
        //         }
        //     }

        //     return count;
        // }

        // // CountUsers, men hvor mange som er over en bestemt alder
        // public int CountUsersOver(int age) 
        // {
        //     int count = 0;

        //     for (Node node = first; node != null; node = node.Next)
        //     {
        //         if (node.Data.Age > age)
        //         {
        //             count++;
        //         }
        //     }

        //     return count;
        // }
        
    }
}