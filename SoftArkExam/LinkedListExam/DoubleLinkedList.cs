using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Previous { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class DoublyLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
    }

    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void RemoveFirst()
    {
        if (head == null)
        {
            // List is empty, nothing to remove
            return;
        }

        head = head.Next;

        if (head != null)
        {
            head.Previous = null;
        }
        else
        {
            // List became empty after removal
            tail = null;
        }
    }

    public void RemoveLast()
    {
        if (tail == null)
        {
            // List is empty, nothing to remove
            return;
        }

        tail = tail.Previous;

        if (tail != null)
        {
            tail.Next = null;
        }
        else
        {
            // List became empty after removal
            head = null;
        }
    }

    public void PrintList()
    {
        Node<T> current = head;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }
    // HERFRA EKSTRA OPGAVER:

    // En add metode, hvor User bliver tilføjet så listen er sorteret efter alder
    public void AddSorted(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Age > newNode.Data.Age)
                {
                    if (current == head)
                    {
                        AddFirst(newNode.Data);
                    }
                    else
                    {
                        newNode.Previous = current.Previous;
                        newNode.Next = current;
                        current.Previous.Next = newNode;
                        current.Previous = newNode;
                    }

                    return;
                }

                current = current.Next;
            }

            AddLast(newNode.Data);
        }
    }

    // Contains
    // Tjekker om listen indeholder en bestemt user
    public bool Contains(T data)
    {
        Node<T> current = head;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

// Fjerner en user fra listen
    public void RemoveUser(T data)
    {
        Node<T> current = head;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (current == head)
                {
                    RemoveFirst();
                }
                else if (current == tail)
                {
                    RemoveLast();
                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }
            }

            current = current.Next;
        }
    }


}
