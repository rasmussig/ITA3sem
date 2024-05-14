var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// lav et arary som indeholder Kunder indeholder som minimum navn, id, email-adresse og type (“erhverv” eller “privat”).

Kunde[] kunder = new Kunde[]
{
    new Kunde {Id = 1, Navn = "Jens", Email = "Jens@gmail.com", Type = "Erhverv"},
    new Kunde {Id = 2, Navn = "Hans", Email = "Hans@gmail.com, Type = "Privat"}
    
};



app.Run();
