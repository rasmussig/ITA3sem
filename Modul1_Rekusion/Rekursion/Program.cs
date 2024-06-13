﻿// Modul 1 - Rekursion
// https://eaaa.instructure.com/courses/19516/pages/opgaver-1?module_item_id=640295

using System.Formats.Asn1;

Console.WriteLine(Opgave0.areal(3)); // Output skal være 6
Console.WriteLine(Opgave3.Faculty(5)); // Output skal være '120'.
Console.WriteLine(Opgave4_1.EculidsSFD(12, 18)); // Output skal være '6'.
Console.WriteLine(Opgave4_2.potens(5, 5)); // Output skal være '3125'.
Console.WriteLine(Opgave4_3.ingenGange(6, 6)); // Output skal være '36'.
Console.WriteLine(Opgave4_4.reverseString("ABCDEF")); // Output skal være '36'.
Console.WriteLine(Opgave6.Fibonacci(7)); // Output skal være '13'.
Opgave5.ScanDir("C:\\Users\\Rasmu\\.templateengine");


// Opgave 0 - Trekants figurer har en rekursiv struktur
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

//Opg 3: Beregn fakultet
// Termineringsregel: 0! = 1
// Rekurrensregel: n! = n * (n - 1)! hvor n > 0.
class Opgave3 {
    public static int Faculty(int n) {
        int resultat;

        if (n == 0) { // Termineringsregel: 0! = 1
            resultat = 1;
        } else {
            resultat = n * Faculty(n - 1); // Rekurrensregel: n! = n * (n - 1)!
        }
        return resultat;
    }
}

//Opg 4_1: Største Fælles Divisor
class Opgave4_1
{
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


//Opg 4_2: Beregn et tal i n'te potens
class Opgave4_2
{
    public static int potens(int n, int p)
    {
        if (p == 0)
        {
            return 1;
        }
        else
        {
            return potens(n, p - 1) * n;
        }
    }
}

//Opg 4_3: Gang 2 tal sammen uden at bruge gange.
class Opgave4_3
{
    public static int ingenGange(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            return 0;
        }
        else if (a == 1)
        {
            return b;
        }
        else if (b == 1)
        {
            return a;
        }
        else
        {
            return ingenGange(a - 1, b) + b;
        }
    }
}

//Opg 4_4: Vend en streng om.
class Opgave4_4
{
    public static string reverseString(string text)
    {
        //Termineringsregl: Hvis strengen er 0 eller 1, returner blot strengen
        if (text.Length <= 1)
        {
            return text;
        }
        else
        {
            // Rekursionsregl: Sæt det sidste tegn i strengen forrest, og giv rest af strengen
            // som input til (Rekursions)funktionen.  
            return text[text.Length - 1] + reverseString(text.Substring(0, text.Length - 1));
        }
    }
}

//Opg 5: Printer ikke mappe-navnet, jeg fatter ik hva der foregår mere
class Opgave5
{
    public static void ScanDir(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();

        foreach (FileInfo file in files)
        {
            Console.WriteLine(file.Name);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            ScanDir(subdir.FullName);
        }
    }
}

/*Fibonacci-sekvens med rekursion
Skriv en rekursiv metode til at generere det n'te tal i Fibonacci-sekvensen. 
Fibonacci-sekvensen starter med 0 og 1, og hvert efterfølgende tal er summen af de to foregående tal.
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 osv.
*/
class Opgave6
    {
        public static int Fibonacci(int n)
        {
            if (n <= 1) // Termineringsregel
                return n;
            else // Rekurrensregel
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

