using HtmlAgilityPack;

class Program
{
    private static void PrintQuestions(List<string> questions)
    {
        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine(i + ". " + questions[i]);
        }
    }

    static async Task Main(string[] args)
    {
        string url = "https://easyoffer.ru/rating/c_sharp_developer?page=3";

        using (var client = new HttpClient())
        {
            string html = await client.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var questions = new List<string>();

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//table/tbody/tr/td/a"))
            {
                questions.Add(node.InnerText);
            }
            questions.Sort();
            PrintQuestions(questions);
        }
    }
}