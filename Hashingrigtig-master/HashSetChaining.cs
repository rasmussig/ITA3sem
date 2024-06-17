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

        int h = HashValue(x); // Beregn hashv�rdien for det givne objekt

        Node bucket = buckets[h]; // Hent den aktuelle bucket p� hashv�rdien
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x)) // Tjek om det nuv�rende element i bucket matcher x
            {
                found = true; // Hvis ja, s�t found til true
            }
            else
            {
                bucket = bucket.Next; // Ellers g� videre til n�ste element i bucket
            }
        }

        if (!found)
        {
            // Tilf�j det nye element som det f�rste element i bucket
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            currentSize++;
        }

        return !found; // Returner true hvis elementet blev tilf�jet, ellers false
    }

    private void ReHash()
    {
        // Gem en kopi af det gamle array og nulstil antallet af elementer
        Node[] oldbuckets = buckets;
        currentSize = 0;
        // Opret et nyt array med dobbelt st�rrelse
        buckets = new Node[2 * buckets.Length];

        // Gennemg� hvert element i det gamle array
        for (int i = 0; i < oldbuckets.Length; i++)
        {
            Node temp = oldbuckets[i];
            // Gennemg� alle elementer i k�den for hvert element i det gamle array
            while (temp != null)
            {
                // Tilf�j hvert element til det nye array ved at kalde Add-metoden
                Add(temp.Data);
                temp = temp.Next;
            }
        }
    }


    public bool Remove(Object x)
    {
        // F�rst kontrolleres det, om x findes i hashtabellen.
        if (!Contains(x))
        {
            // Hvis x ikke findes, returneres falsk (ingen fjernelse udf�rt).
            return false;
        }

        // Beregn hashv�rdien for objektet x.
        int h = HashValue(x);

        // Boolean variabel til at spore, om elementet blev fundet og fjernet.
        Boolean found = false;

        // En reference til det foreg�ende element i k�den.
        Node before = null!;

        // Hent det f�rste element i k�den i den givne hash-bucket.
        Node bucket = buckets[h];

        // Hvis der ikke er nogen k�de i den angivne bucket, returneres falsk.
        if (bucket == null)
        {
            return false;
        }

        // Hvis det f�rste element i k�den matcher x, fjernes det.
        if (bucket.Data.Equals(x))
        {
            found = true;
            // Opdater hashtabellens reference til det n�ste element i k�den.
            buckets[h] = bucket.Next;
            // Formindsk st�rrelsen af hashtabellen.
            currentSize--;
            // Returner, da fjernelsen er fuldf�rt.
            return found;
        }

        // Hvis det f�rste element ikke er det, vi leder efter, skal vi kigge igennem resten af k�den.
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                // Hvis det aktuelle element matcher x, fjernes det.
                found = true;
                // Opdater det foreg�ende elements reference til det n�ste element i k�den.
                before.Next = bucket.Next;
                // Formindsk st�rrelsen af hashtabellen.
                currentSize--;
            }
            else
            {
                // Hvis det aktuelle element ikke er det, vi leder efter, bev�ger vi os videre til det n�ste element i k�den.
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
