using Hashing;

public class HashSetLinearProbing : HashSet {
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength) {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int probe; // Variabel til at holde styr på sondéringsindgangen.

        int code = HashValue(x); // Beregn hashværdien for det givne objekt.

        // Tjek om det første element på den hashede position er null.
        if (buckets[code] == null)
        {
            return false; // Hvis det er, er x ikke i tabellen, så returner false.
        }
        // Tjek om det første element på den hashede position er x.
        else if (buckets[code].Equals(x))
        {
            return true; // Hvis det er, er x i tabellen, så returner true.
        }
        // Hvis det første element på den hashede position ikke er x, find det næste ledige sted til sondéringsindgangen.
        else
        {
            // Sæt sondéringsindgangen til næste position efter den hashede position.
            if (code == (buckets.Length - 1))
            {
                probe = 0; // Hvis vi er nået til slutningen af arrayet, skal sondéringsindgangen gå til starten.
            }
            else
            {
                probe = code + 1; // Ellers skal sondéringsindgangen være næste position.
            }
        }

        // Søg videre i tabellen indtil vi når tilbage til start.
        while (probe != code)
        {
            // Tjek om sondéringsindgangen er tom eller indeholder DELETED.
            if (buckets[probe] == null)
            {
                return false; // Hvis det er tilfældet, er x ikke i tabellen, så returner false.
            }
            // Tjek om sondéringsindgangen indeholder x.
            else if (buckets[probe].Equals(x))
            {
                return true; // Hvis det er, er x i tabellen, så returner true.
            }
            // Hvis ingen af de tidligere betingelser er opfyldt, fortsæt sondøringen.
            else
            {
                // Sæt sondéringsindgangen til næste position.
                if (probe == (buckets.Length - 1))
                {
                    probe = 0; // Hvis vi er nået til slutningen af arrayet, skal sondéringsindgangen gå til starten.
                }
                else
                {
                    probe++; // Ellers skal sondéringsindgangen være næste position.
                }
            }
        }

        return false; // Hvis vi når tilbage til start uden at finde x, er x ikke i tabellen, så returner false.
    }


    public bool Add(Object x)
    {
        // Tjek om x allerede eksisterer i tabellen ved at kalde Contains-metoden.
        if (Contains(x))
        {
            return false; // Hvis x allerede findes, returneres false (ingen tilføjelse udført).
        }

        int probe; // Variabel til at holde styr på sondéringsindgangen.

        int code = HashValue(x); // Beregn hashværdien for det givne objekt.

        // Hvis den hashede position eller dens næste position er tom, tilføj x på den hashede position.
        if ((buckets[code] == null) || buckets[code].Equals(State.DELETED))
        {
            buckets[code] = x; // Tilføj x til den hashede position.
            currentSize++; // Forøg størrelsen af tabellen.
            return true; // Returner true for at angive, at tilføjelsen blev udført.
        }

        // Hvis den hashede position ikke er tom, find det næste ledige sted til sondéringsindgangen.
        else
        {
            // Sæt sondéringsindgangen til næste position efter den hashede position.
            if (code == (buckets.Length - 1))
            {
                probe = 0; // Hvis vi er nået til slutningen af arrayet, skal sondéringsindgangen gå til starten.
            }
            else
            {
                probe = code + 1; // Ellers skal sondéringsindgangen være næste position.
            }
        }

        // Søg videre i tabellen indtil vi når tilbage til start.
        while (probe != code)
        {
            // Hvis sondéringsindgangen eller dens næste position er tom, tilføj x på sondéringsindgangen.
            if ((buckets[probe] == null) || buckets[probe].Equals(State.DELETED))
            {
                buckets[probe] = x; // Tilføj x til sondéringsindgangen.
                currentSize++; // Forøg størrelsen af tabellen.
                return true; // Returner true for at angive, at tilføjelsen blev udført.
            }
            // Hvis sondéringsindgangen allerede indeholder x, returneres false (ingen tilføjelse udført).
            else if (buckets[probe].Equals(x))
            {
                return false; // Returner false for at angive, at x allerede eksisterer i tabellen.
            }
            // Hvis ingen af de tidligere betingelser er opfyldt, fortsæt sondøringen.
            else
            {
                // Sæt sondéringsindgangen til næste position.
                if (probe == (buckets.Length - 1))
                {
                    probe = 0; // Hvis vi er nået til slutningen af arrayet, skal sondéringsindgangen gå til starten.
                }
                else
                {
                    probe++; // Ellers skal sondéringsindgangen være næste position.
                }
            }
        }

        return false; // Hvis vi når tilbage til start uden at tilføje x, returneres false (ingen tilføjelse udført).
    }


    public bool Remove(Object x)
    {
        int probe; // Variabel til at holde styr på sondéringsindgangen.

        int code = HashValue(x); // Beregn hashværdien for det givne objekt.

        // Tjek om det første element på den hashede position er null.
        if (buckets[code] == null)
        {
            return false; // Hvis det er, er x ikke i tabellen, så returner false.
        }

        // Tjek om det første element på den hashede position er x.
        else if (buckets[code].Equals(x))
        {
            buckets[code] = State.DELETED; // Sæt elementet til DELETED for at markere det som slettet.
            currentSize--; // Formindsk størrelsen af tabellen.
            return true; // Returner true for at angive, at fjernelsen blev udført.
        }

        // Hvis det første element på den hashede position ikke er x, find det næste ledige sted til sondéringsindgangen.
        else
        {
            // Sæt sondéringsindgangen til næste position efter den hashede position.
            if (code == (buckets.Length - 1))
            {
                probe = 0; // Hvis vi er nået til slutningen af arrayet, skal sondéringsindgangen gå til starten.
            }
            else
            {
                probe = code + 1; // Ellers skal sondéringsindgangen være næste position.
            }
        }

        // Søg videre i tabellen indtil vi når tilbage til start.
        while (probe != code)
        {
            // Tjek om sondéringsindgangen er tom, eller hvis elementet på sondéringsindgangen er markeret som DELETED.
            if (buckets[probe] == null)
            {
                return false; // Hvis det er tilfældet, så er x ikke i tabellen, så returner false.
            }
            // Tjek om elementet på sondéringsindgangen er x.
            else if (buckets[probe].Equals(x))
            {
                buckets[probe] = State.DELETED; // Sæt elementet til DELETED for at markere det som slettet.
                currentSize--; // Formindsk størrelsen af tabellen.
                return true; // Returner true for at angive, at fjernelsen blev udført.
            }
            // Hvis ingen af de tidligere betingelser er opfyldt, skal vi fortsætte med at sondere.
            else
            {
                // Sæt sondéringsindgangen til næste position.
                if (probe == (buckets.Length - 1))
                {
                    probe = 0; // Hvis vi er nået til slutningen af arrayet, skal sondéringsindgangen gå til starten.
                }
                else
                {
                    probe++; // Ellers skal sondéringsindgangen være næste position.
                }
            }
        }

        return false; // Hvis vi når tilbage til start uden at finde x, så er x ikke i tabellen, så returner false.
    }


    public int Size() {
        return currentSize;
    }

    private int HashValue(Object x) {
        int h = x.GetHashCode();
        if (h < 0) {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public override String ToString() {
        String result = "";
        for (int i = 0; i < buckets.Length; i++) {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ? 
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
