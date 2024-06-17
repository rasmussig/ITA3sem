var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


// Tilføj en liste af Quiz objekter
var quizzes = new List<Quiz>
{
    new Quiz
    {
        Id = 1,
        Spørgsmål = "Hvad er hovedstaden i Frankrig?",
        Svarmuligheder = new Svar[]
        {
            new Svar { Tekst = "Paris", ErKorrekt = true },
            new Svar { Tekst = "Berlin", ErKorrekt = false },
            new Svar { Tekst = "Rome", ErKorrekt = false }
        },
        KorrektSvarIndex = 0
    },
    new Quiz
    {
        Id = 2,
        Spørgsmål = "Hvem skrev 'To Kill a Mockingbird'?",
        Svarmuligheder = new Svar[]
        {
            new Svar { Tekst = "Mark Twain", ErKorrekt = false },
            new Svar { Tekst = "Harper Lee", ErKorrekt = true },
            new Svar { Tekst = "Ernest Hemingway", ErKorrekt = false }
        },
        KorrektSvarIndex = 1
    }
};

// GET - Henter alle quizzes, men ikke om et svar er korrekt
app.MapGet("api/questions", () => quizzes.Select(q => new
{
    q.Id,
    q.Spørgsmål,
    Svarmuligheder = q.Svarmuligheder.Select(a => a.Tekst),
}));

// GET /api/questions/{id}: Henter et bestemt spørgsmål og dets svarmuligheder, men ikke hvilket svar der er det rigtige
app.MapGet("api/questions/{id}", (int id) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);
    if (quiz == null)
    {
        return Results.NotFound("Spørgsmålet findes ikke");
    }
    return Results.Ok(new
    {
        quiz.Id,
        quiz.Spørgsmål,
        Svarmuligheder = quiz.Svarmuligheder.Select(a => a.Tekst),
    });
});

// POST /api/questions/{id}/validate: Her kan postes et spørgsmåls-id og en svarmulighed, og så får man at vide, om svaret er rigtigt eller forkert
app.MapPost("api/questions/{id}/validate", (int id, Svar svar) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);
    if (quiz == null)
    {
        return Results.NotFound("Spørgsmålet findes ikke");
    }

    if (quiz.Svarmuligheder[quiz.KorrektSvarIndex].Tekst == svar.Tekst)
    {
        return Results.Ok("Rigtigt svar");
    }
    return Results.Ok("Forkert svar");
});

// TEST POSTEN I POSTMAN -> POST -> BODY -> RAW -> JSON
//  { "Tekst" : "Paris" }

app.Run();

public class Quiz
{
    public int Id { get; set; }
    public string Spørgsmål { get; set; }
    public Svar[] Svarmuligheder { get; set; } = new Svar[4];
    public int KorrektSvarIndex { get; set; }
}

public class Svar
{
    public string Tekst { get; set; }
    public bool ErKorrekt { get; set; }
}