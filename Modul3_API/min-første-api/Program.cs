using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Opgave 2
app.MapGet("/api/hello", () => new { Message = "Hello world!" });
app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!"});

//Opgave 3
app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}! Your fucking {age} years old"});


//Opgave 4
String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};


//Endpoint der retunere fugtarray
app.MapGet("/api/frugter", () => frugter );

//Endpoint der retunere bestemt frugt udfra index
app.MapGet("/api/frugter/{index}", (int index) => frugter[index]);

//ANDEN LØSNING
/* app.MapGet("/api/frugter/{index}", (int index) =>
{
    // Tjekker om index er indenfor arrayets grænser
    if (index >= 0 && index < frugter.Length)
    {
        return Results.Ok(frugter[index]);
    }
    else
    {
        // Returnerer en 404 NotFound hvis index er udenfor array-længde
        return Results.NotFound("Frugt ikke fundet på den angivne indeks.");
    }
}); */

//Endpoint der retunere tilfældig frugt
app.MapGet("/api/frugter/random", ()=>  {
var random = new Random();
int randomIndex = random.Next(0, frugter.Length);
return frugter[randomIndex]; });


//Opgave 5 og 6 
app.MapPost("/api/fruit", (Fruit fruit) =>
{
    if(string.IsNullOrWhiteSpace(fruit.name)) {
        return Results.BadRequest("Ugyldig input");
    }

    Array.Resize(ref frugter, frugter.Length + 1 );
    frugter[frugter.Length -1 ] = fruit.name; 

    //Måske alternativ?
    //frugter = frugter.Append(fruit.Name).ToArray();

    Console.WriteLine($"Tilføjet frugt: {fruit.name}");

    return Results.Ok(frugter);
});


app.Run(); 
record Fruit(string name);


