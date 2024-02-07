using System.Runtime.InteropServices;

var badWords = new string[] { "shit", "fuck", "idiot" };
var filterBadWords = CreateWordReplacerFn(badWords, "kage");
Console.WriteLine(filterBadWords("Sikke en gang shit")); // Udskriver: "Sikke en gang kage"

var filterWords = CreateWordFilterFn(badWords);
Console.WriteLine(filterWords("Du er en idiot")); // Udskriver: "Du er en"


static Func<string, string> CreateWordFilterFn(string[] words)
{
    return (text) =>
        {
            //Splitter text i indivudelle ord, baseret på mellemrum, og retunere en liste af disse
            var wordsList = text.Split(' ').ToList();

            //Ord der ikke matcher input arrayet, bliver ikke en del af filteredWords-listen
            var filteredWords = wordsList.Where(word => !words.Contains(word)).ToList();

            //Samlerne ordene fra filterdWords tilbage til en streng. 
            return String.Join(" ", filteredWords);
        };
    }

static Func<string, string> CreateWordReplacerFn(string[] words, string replacementWord)
{
    return text =>
    {
        var wordslist = text.Split(' ').ToList();

        //IF- Else-statement, der gennemgår ordene i wordslist-listen.
        var replacedWords = wordslist.Select (word =>
        {
            //Hvis listen indeholder ord fra input-words[] udskift med replacementWord
            if(words.Contains(word))
            {
                return replacementWord;
            } 
            //Ellers retuner ordet.
            else 
            {
                return word;
            }

        }).ToList();

        return String.Join(" ", replacedWords);
    };
}