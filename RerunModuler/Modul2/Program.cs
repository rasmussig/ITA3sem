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

//Opgave 1_1 - Beregn samlede alder for personerne
var sumAlder = people.Sum(person => person.Age);
Console.WriteLine("Den samlede alder er: " + sumAlder);

//Opgave 1_2 - Tæl hvor mange som hedder Nielsen
var numNielsen = people.Count(person => person.Name.Contains("Nielsen"));
Console.WriteLine("Så mange navne indeholder 'Nielsen': " + numNielsen);

//Opgave 1_3 - Find den ældeste person
var oldestPerson = people.OrderByDescending(person => person.Age).First();
Console.WriteLine("Den ældeste person er: " + oldestPerson.Name + " Hans alder er: " + oldestPerson.Age);

//Opgave 2 - LINQ på Array
var personWithThisNumber = people.First(person => person.Phone == "+4543215687");
Console.WriteLine(personWithThisNumber.Name);

var everyoneOver30 = people.Where(person => person.Age > 30);
foreach (var person in everyoneOver30) {
    Console.Write(person.Name +"  +  ");
}

//Opgave 2_3 - Udskriv nyt array, men fjern "+45" fra telefonnummer
var updatedPeople = people.Select(p => new Person
        {
            Name = p.Name,
            Age = p.Age,

            // Fjerner "+45" fra starten af telefonnummeret, hvis det er til stede
            Phone = p.Phone.Replace("+45", "")
            });

        // Udskriver det opdaterede array for at bekræfte ændringerne
        foreach (var person in updatedPeople)
        {
            Console.WriteLine($"{person.Name},\t {person.Age} år,\t Tlf: {person.Phone}");
        }

//Opgave 2_4 - Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma
var peopleUnder30 = people.Where(p => p.Age < 30)
                          .Select(p => new
                          {
                              p.Name,
                              p.Phone
                          });

foreach (var person in peopleUnder30)
{
    Console.WriteLine($"Navn: {person.Name}, Tlf: {person.Phone}");
}


class Person {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}