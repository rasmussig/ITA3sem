using Hashing;

public class HashSetChaining : HashSet
{
    private Node[] buckets;
    private int currentSize;

    private class Node
    {
        public Node(Object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public Object Data { get; set; }
        public Node Next { get; set; }
    }

    public HashSetChaining(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int h = HashValue(x);
        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }
        return found;
    }

    public bool Add(Object x)
    {
        // Tjek om arrayet er blevet initialiseret
        if (buckets.Length > 0)
        {
            // Tjek om load-faktoren overstiger 0.75
            if ((double)currentSize / buckets.Length >= 0.75) //loadfactor
            {
                ReHash(); // Hvis ja, kald rehash-metoden
            }
        }

        int h = HashValue(x); // Beregn hashværdien for det givne objekt

        Node bucket = buckets[h]; // Hent den aktuelle bucket på hashværdien
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x)) // Tjek om det nuværende element i bucket matcher x
            {
                found = true; // Hvis ja, sæt found til true
            }
            else
            {
                bucket = bucket.Next; // Ellers gå videre til næste element i bucket
            }
        }

        if (!found)
        {
            // Tilføj det nye element som det første element i bucket
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            currentSize++;
        }

        return !found; // Returner true hvis elementet blev tilføjet, ellers false
    }

    private void ReHash()
    {
        // Gem en kopi af det gamle array og nulstil antallet af elementer
        Node[] oldbuckets = buckets;
        currentSize = 0;
        // Opret et nyt array med dobbelt størrelse
        buckets = new Node[2 * buckets.Length];

        // Gennemgå hvert element i det gamle array
        for (int i = 0; i < oldbuckets.Length; i++)
        {
            Node temp = oldbuckets[i];
            // Gennemgå alle elementer i kæden for hvert element i det gamle array
            while (temp != null)
            {
                // Tilføj hvert element til det nye array ved at kalde Add-metoden
                Add(temp.Data);
                temp = temp.Next;
            }
        }
    }


    public bool Remove(Object x)
    {
        // Først kontrolleres det, om x findes i hashtabellen.
        if (!Contains(x))
        {
            // Hvis x ikke findes, returneres falsk (ingen fjernelse udført).
            return false;
        }

        // Beregn hashværdien for objektet x.
        int h = HashValue(x);

        // Boolean variabel til at spore, om elementet blev fundet og fjernet.
        Boolean found = false;

        // En reference til det foregående element i kæden.
        Node before = null!;

        // Hent det første element i kæden i den givne hash-bucket.
        Node bucket = buckets[h];

        // Hvis der ikke er nogen kæde i den angivne bucket, returneres falsk.
        if (bucket == null)
        {
            return false;
        }

        // Hvis det første element i kæden matcher x, fjernes det.
        if (bucket.Data.Equals(x))
        {
            found = true;
            // Opdater hashtabellens reference til det næste element i kæden.
            buckets[h] = bucket.Next;
            // Formindsk størrelsen af hashtabellen.
            currentSize--;
            // Returner, da fjernelsen er fuldført.
            return found;
        }

        // Hvis det første element ikke er det, vi leder efter, skal vi kigge igennem resten af kæden.
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                // Hvis det aktuelle element matcher x, fjernes det.
                found = true;
                // Opdater det foregående elements reference til det næste element i kæden.
                before.Next = bucket.Next;
                // Formindsk størrelsen af hashtabellen.
                currentSize--;
            }
            else
            {
                // Hvis det aktuelle element ikke er det, vi leder efter, bevæger vi os videre til det næste element i kæden.
                before = bucket;
                bucket = bucket.Next;
            }
        }
        // Returner, om elementet blev fundet og fjernet.
        return found;
    }

    private int HashValue(Object x)
    {
        int h = x.GetHashCode();
        if (h < 0)
        {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public int Size()
    {
        return currentSize;
    }

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];
            if (temp != null)
            {
                result += i + "\t";
                while (temp != null)
                {
                    result += temp.Data + " (h:" + HashValue(temp.Data) + ")\t";
                    temp = temp.Next;
                }
                result += "\n";
            }
        }
        return result;
    }
}
