using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://easyoffer.ru/rating/c_sharp_developer?page=1";

        HttpClient client = new HttpClient();
        string html = await client.GetStringAsync(url);

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);

        List<string> questions = new List<string>();

        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//table/tbody/tr/td/a"))
        {
            questions.Add(node.InnerText);
        }

        foreach (string question in questions)
        {
            Console.WriteLine(question);
        }
    }
}