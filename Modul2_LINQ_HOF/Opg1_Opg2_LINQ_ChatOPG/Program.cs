﻿﻿using System;
using System.Linq;

// Definerer og initialiserer people arrayet
Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};

//1.1 Beregn det gennemsnitlige alder for alle personer.
var averageAge = people.Average(person => person.Age);
Console.WriteLine("Den gennemsnitlige alder " + averageAge);

//1.2 Tæl hvor mange personer der har et navn, der starter med "J".
var personsStartingWithJ = people.Count(person => person.Name.StartsWith("J"));
Console.WriteLine("Så mange personer starter med J: " + personsStartingWithJ);

//1.3 Find den yngste person.
var youngestPerson = people.OrderBy(person => person.Age).First();
// var youngestAge = people.Min(person => person.Age);
// var youngestPerson = people.Where(person => person.Age == youngestAge);
// foreach (var person in youngestPerson) 
// {
//     Console.WriteLine($"{person.Name} alder: {person.Age}");
// }


Console.WriteLine("Den yngeste person er: " + youngestPerson.Name + " Alder: " + youngestPerson.Age);

//2.1 Find og udskriv alle personer, hvis navn indeholder "sen".
var peopleWithSen = people.Where(person => person.Name.Contains("sen"));
Console.WriteLine("Personer med 'sen' i navnet");
foreach (var person in peopleWithSen)
{
    Console.WriteLine($"{person.Name}");
}   

//2.2 Vælg alle som er 25 år eller ældre og udskriv dem i faldende orden efter alder.
var peopleUnder25 = people.Where(person => person.Age < 25)
                    .OrderByDescending(person => person.Age);
foreach (var person in peopleUnder25) 
{
    Console.WriteLine($"{person.Name} alder: {person.Age}");
}

//2.3 Lav et nyt array med navnene på personer, hvis telefonnummer indeholder "123"
var peopleWith123 = people.Where(person => person.Phone.Contains("123"))
                        .ToArray();
foreach (var person in peopleWith123) 
{
    Console.WriteLine($"{person.Name},\t {person.Age} år,\t Tlf: {person.Phone}");
}

//2.4 Generér en string med navnene på de personer, der er præcis 22 år gamle, adskilt med semikolon.
var people22 = people.Where(person => person.Age == 22);
foreach (var person in people22)
{
    Console.WriteLine($"{person.Name} alder: {person.Age}");
}

// Person klassen definition
class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string Phone { get; set; } = "";
}