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
        int probe; // Variabel til at holde styr p� sond�ringsindgangen.

        int code = HashValue(x); // Beregn hashv�rdien for det givne objekt.

        // Tjek om det f�rste element p� den hashede position er null.
        if (buckets[code] == null)
        {
            return false; // Hvis det er, er x ikke i tabellen, s� returner false.
        }
        // Tjek om det f�rste element p� den hashede position er x.
        else if (buckets[code].Equals(x))
        {
            return true; // Hvis det er, er x i tabellen, s� returner true.
        }
        // Hvis det f�rste element p� den hashede position ikke er x, find det n�ste ledige sted til sond�ringsindgangen.
        else
        {
            // S�t sond�ringsindgangen til n�ste position efter den hashede position.
            if (code == (buckets.Length - 1))
            {
                probe = 0; // Hvis vi er n�et til slutningen af arrayet, skal sond�ringsindgangen g� til starten.
            }
            else
            {
                probe = code + 1; // Ellers skal sond�ringsindgangen v�re n�ste position.
            }
        }

        // S�g videre i tabellen indtil vi n�r tilbage til start.
        while (probe != code)
        {
            // Tjek om sond�ringsindgangen er tom eller indeholder DELETED.
            if (buckets[probe] == null)
            {
                return false; // Hvis det er tilf�ldet, er x ikke i tabellen, s� returner false.
            }
            // Tjek om sond�ringsindgangen indeholder x.
            else if (buckets[probe].Equals(x))
            {
                return true; // Hvis det er, er x i tabellen, s� returner true.
            }
            // Hvis ingen af de tidligere betingelser er opfyldt, forts�t sond�ringen.
            else
            {
                // S�t sond�ringsindgangen til n�ste position.
                if (probe == (buckets.Length - 1))
                {
                    probe = 0; // Hvis vi er n�et til slutningen af arrayet, skal sond�ringsindgangen g� til starten.
                }
                else
                {
                    probe++; // Ellers skal sond�ringsindgangen v�re n�ste position.
                }
            }
        }

        return false; // Hvis vi n�r tilbage til start uden at finde x, er x ikke i tabellen, s� returner false.
    }


    public bool Add(Object x)
    {
        // Tjek om x allerede eksisterer i tabellen ved at kalde Contains-metoden.
        if (Contains(x))
        {
            return false; // Hvis x allerede findes, returneres false (ingen tilf�jelse udf�rt).
        }

        int probe; // Variabel til at holde styr p� sond�ringsindgangen.

        int code = HashValue(x); // Beregn hashv�rdien for det givne objekt.

        // Hvis den hashede position eller dens n�ste position er tom, tilf�j x p� den hashede position.
        if ((buckets[code] == null) || buckets[code].Equals(State.DELETED))
        {
            buckets[code] = x; // Tilf�j x til den hashede position.
            currentSize++; // For�g st�rrelsen af tabellen.
            return true; // Returner true for at angive, at tilf�jelsen blev udf�rt.
        }

        // Hvis den hashede position ikke er tom, find det n�ste ledige sted til sond�ringsindgangen.
        else
        {
            // S�t sond�ringsindgangen til n�ste position efter den hashede position.
            if (code == (buckets.Length - 1))
            {
                probe = 0; // Hvis vi er n�et til slutningen af arrayet, skal sond�ringsindgangen g� til starten.
            }
            else
            {
                probe = code + 1; // Ellers skal sond�ringsindgangen v�re n�ste position.
            }
        }

        // S�g videre i tabellen indtil vi n�r tilbage til start.
        while (probe != code)
        {
            // Hvis sond�ringsindgangen eller dens n�ste position er tom, tilf�j x p� sond�ringsindgangen.
            if ((buckets[probe] == null) || buckets[probe].Equals(State.DELETED))
            {
                buckets[probe] = x; // Tilf�j x til sond�ringsindgangen.
                currentSize++; // For�g st�rrelsen af tabellen.
                return true; // Returner true for at angive, at tilf�jelsen blev udf�rt.
            }
            // Hvis sond�ringsindgangen allerede indeholder x, returneres false (ingen tilf�jelse udf�rt).
            else if (buckets[probe].Equals(x))
            {
                return false; // Returner false for at angive, at x allerede eksisterer i tabellen.
            }
            // Hvis ingen af de tidligere betingelser er opfyldt, forts�t sond�ringen.
            else
            {
                // S�t sond�ringsindgangen til n�ste position.
                if (probe == (buckets.Length - 1))
                {
                    probe = 0; // Hvis vi er n�et til slutningen af arrayet, skal sond�ringsindgangen g� til starten.
                }
                else
                {
                    probe++; // Ellers skal sond�ringsindgangen v�re n�ste position.
                }
            }
        }

        return false; // Hvis vi n�r tilbage til start uden at tilf�je x, returneres false (ingen tilf�jelse udf�rt).
    }


    public bool Remove(Object x)
    {
        int probe; // Variabel til at holde styr p� sond�ringsindgangen.

        int code = HashValue(x); // Beregn hashv�rdien for det givne objekt.

        // Tjek om det f�rste element p� den hashede position er null.
        if (buckets[code] == null)
        {
            return false; // Hvis det er, er x ikke i tabellen, s� returner false.
        }

        // Tjek om det f�rste element p� den hashede position er x.
        else if (buckets[code].Equals(x))
        {
            buckets[code] = State.DELETED; // S�t elementet til DELETED for at markere det som slettet.
            currentSize--; // Formindsk st�rrelsen af tabellen.
            return true; // Returner true for at angive, at fjernelsen blev udf�rt.
        }

        // Hvis det f�rste element p� den hashede position ikke er x, find det n�ste ledige sted til sond�ringsindgangen.
        else
        {
            // S�t sond�ringsindgangen til n�ste position efter den hashede position.
            if (code == (buckets.Length - 1))
            {
                probe = 0; // Hvis vi er n�et til slutningen af arrayet, skal sond�ringsindgangen g� til starten.
            }
            else
            {
                probe = code + 1; // Ellers skal sond�ringsindgangen v�re n�ste position.
            }
        }

        // S�g videre i tabellen indtil vi n�r tilbage til start.
        while (probe != code)
        {
            // Tjek om sond�ringsindgangen er tom, eller hvis elementet p� sond�ringsindgangen er markeret som DELETED.
            if (buckets[probe] == null)
            {
                return false; // Hvis det er tilf�ldet, s� er x ikke i tabellen, s� returner false.
            }
            // Tjek om elementet p� sond�ringsindgangen er x.
            else if (buckets[probe].Equals(x))
            {
                buckets[probe] = State.DELETED; // S�t elementet til DELETED for at markere det som slettet.
                currentSize--; // Formindsk st�rrelsen af tabellen.
                return true; // Returner true for at angive, at fjernelsen blev udf�rt.
            }
            // Hvis ingen af de tidligere betingelser er opfyldt, skal vi forts�tte med at sondere.
            else
            {
                // S�t sond�ringsindgangen til n�ste position.
                if (probe == (buckets.Length - 1))
                {
                    probe = 0; // Hvis vi er n�et til slutningen af arrayet, skal sond�ringsindgangen g� til starten.
                }
                else
                {
                    probe++; // Ellers skal sond�ringsindgangen v�re n�ste position.
                }
            }
        }

        return false; // Hvis vi n�r tilbage til start uden at finde x, s� er x ikke i tabellen, s� returner false.
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
