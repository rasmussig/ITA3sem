using System;

// En interface, som definerer de grundlæggende metoder, som alle mapper skal implementere.
public interface Map<K, V>
{
    // Metode til at hente værdien associeret med en given nøgle.
    public V Get(K key);

    // Metode til at tilføje eller erstatte værdien associeret med en given nøgle.
    public V Put(K key, V value);

    // Metode til at fjerne en nøgle-værdi-par fra mappet baseret på den givne nøgle.
    public V Remove(K key);

    // Metode til at kontrollere om mappet er tomt.
    public bool IsEmpty();

    // Metode til at returnere størrelsen af mappet, dvs. antallet af nøgle-værdi-par.
    public int Size();
}

// En implementering af Map-interfacet ved brug af en hashmappe-struktur.
public class HashMap<K, V> : Map<K, V>
{
    private Node start; // En reference til det første element i hashmap'ens linkede liste.
    private int size; // Antallet af nøgle-værdi-par i hashmap'et.

    // En indre klasse, der repræsenterer et element i den linkede liste.
    private class Node
    {
        public Node()
        {
        }

        public Node next { get; set; } // En reference til det næste element i den linkede liste.
        public K key { get; set; } // Nøglen, der er associeret med noden.
        public V value { get; set; } // Værdien, der er associeret med noden.
    }

    // Konstruktøren, der initialiserer en tom hashmap.
    public HashMap()
    {
        // Sentinel (tomt listehoved, der ikke indeholder data)
        start = new Node();
        size = 0;
    }

    // Metode til at hente værdien associeret med en given nøgle.
    public V Get(K key)
    {
        Node node = start.next;
        V? result = default(V);

        while (node != null)
        {
            if (node.key != null && node.key.Equals(key))
            {
                result = node.value;
                return result;
            }
            else
            {
                node = node.next;
            }
        }
        return result!; // Returner den fundne værdi, eller null hvis nøglen ikke blev fundet.
    }

    // Metode til at tjekke om hashmap'et er tomt.
    public Boolean IsEmpty()
    {
        return size == 0;
    }

    // Metode til at tilføje eller erstatte værdien associeret med en given nøgle.
    public V Put(K key, V value)
    {
        Node current = start;
        Node previous = null!;

        // Gennemgå hashmap'et for at finde den eksisterende nøgle
        while (current != null)
        {
            if (current.key != null && current.key.Equals(key))
            {
                V old = current.value;
                current.value = value; // Erstat den eksisterende værdi med den nye værdi
                return old; // Returner den gamle værdi
            }
            else
            {
                previous = current;
                current = current.next;
            }
        }

        // Hvis nøglen ikke blev fundet, tilføjes den som et nyt element i hashmap'et
        Node node = new Node();
        node.value = value;
        node.key = key;
        node.next = current!;
        previous.next = node;
        size++;
        return default(V)!; // Returner null (ingen eksisterende værdi blev erstattet)
    }

    // Metode til at fjerne en nøgle-værdi-par fra hashmap'et baseret på den givne nøgle.
    public V Remove(K key)
    {
        Node current = start;
        Node previous = null!;
        Boolean found = false;

        // Gennemgå hashmap'et for at finde den nøgle, der skal fjernes
        while (current.next != null && !found)
        {
            if (key!.Equals(current.key))
            {
                found = true;
            }
            else
            {
                previous = current;
                current = current.next;
            }
        }

        // Hvis nøglen blev fundet, fjernes den fra hashmap'et
        if (found)
        {
            if (previous == null)
            {
                start = current.next!; // Opdater startreferencen hvis den første node skal fjernes
            }
            else
            {
                previous.next = current.next!; // Fjern noden ved at opdatere reference til det næste element
            }
        }
        size--;
        return current.value; // Returner værdien, der blev fjernet
    }

    // Metode til at returnere en strengrepræsentation af hashmap'et.
    public override String ToString()
    {
        String s = "Dictionary:\n";
        Node n = start.next;

        // Gennemgå hashmap'et og sammensæt en streng, der repræsenterer hvert nøgle-værdi-par
        while (n != null)
        {
            s = s + "k: " + n.key + " ";
            s = s + "v: " + n.value + "\n";
            n = n.next;
        }
        return s; // Returner den sammensatte strengrepræsentation af hashmap'et
    }

    // Metode til at returnere størrelsen af hashmap'et.
    public int Size()
    {
        return size;
    }
}
