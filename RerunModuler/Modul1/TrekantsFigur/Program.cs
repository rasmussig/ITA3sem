// See https://aka.ms/new-console-template for more information
using System.Formats.Asn1;
using System.Runtime.InteropServices;

Console.WriteLine(Opgave0.areal(3)); // Forventet output 6
Console.WriteLine(Opgave3.Faculty(5)); // Output skal være '120'.
Console.WriteLine(Opgave4_1.EculidsSFD(252, 105)); // Output skal være '21'
Console.WriteLine(Opgave4_2.ntePotens(5,4)); // Output skal være '625'

//Trekantsfigurer
class Opgave0 {
public static int areal (int bredde) {
    int resultat;

    if (bredde == 1) {
        resultat = 1;
    } else {
        resultat = bredde + areal(bredde - 1);
    }
    return resultat;
}
}

// Fakultet
class Opgave3 {
    public static int Faculty(int n) {
       int resultat;

       if(n == 0) {
        resultat = 1;
       } else {
        resultat = n * Faculty(n - 1);
       }
       return resultat;
    }
}

// Finder største fælles divisor
class Opgave4_1 {
    public static int EculidsSFD(int a, int b) {
        if (b <= a && a % b == 0) {
            return b;
        } else if(b > a) {
            return EculidsSFD (b, a); 
        } else {
            return EculidsSFD(b, a % b);
        }
    }
}

// Et tal opløftet i potens
class Opgave4_2 {
    public static int ntePotens (int n, int p) {
        if ( p == 0) {
            return 1;
        } else {
              return ntePotens (n, p - 1) * n;
        }
    }
}

// To tal ganger med hinanden uden at bruge gange
