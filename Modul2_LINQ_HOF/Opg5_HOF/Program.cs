using System;
using System.Collections.Generic;
using System.Linq;

        Person[] people = new Person[]
        {
            new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
            new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
            new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
            new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
            new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
            new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
        };

        // Opgave 5.1: Højere Ordens Funktion
        // Der laves en ny sorterings-funktion hvor der sammenlignes på alder
        var PeopleSortAge = BubbleSort.CreateSorter((person1, person2) => person1.Age - person2.Age);
        // Den nye funktion bruges til at sortere et array
        var sortedPeople = PeopleSortAge(people);
        // Det sorterede array udskrives med LINQ så vi kan se at det virker
        Console.WriteLine("\nOpgave 5.1:");
        sortedPeople.ToList().ForEach(p => Console.WriteLine(p.Age + " " + p.Name));
        
public class BubbleSort
{
    // Bytter om på to elementer i et array
    private static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Laver sortering på array med Bubble Sort. 
    // compareFn bruges til at sammeligne to personer med.
   public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                // Laver en ombytning, hvis to personer står forkert sorteret
                if (compareFn(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }

    public static Func<Person[], Person[]> CreateSorter(Func<Person, Person, int> compareFn)
    {
        return (array) =>
        {
            Person[] newArray = (Person[])array.Clone();
            BubbleSort.Sort(newArray, compareFn);
            return newArray;
        };
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}

