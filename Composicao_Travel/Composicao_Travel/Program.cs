using Composicao_Travel.Entities;
using System;

namespace Composicao_Travel
{
    class Program
    {
        static void Main(string[] args)
        {
            Comment c1 = new Comment("Have a nice trip!");
            Comment c2 = new Comment("Wow That's Awesome!");
            Post p1 = new Post(
                DateTime.Parse("21/06/2018 13:05:44"),
                "Traveling to New Zealand",
                "I'm going to visit this wonderful country",
                12);
            p1.addComment(c1);
            p1.addComment(c2);

            Comment c3 = new Comment("Good Night");
            Comment c4 = new Comment("May the Force be with you");
            Post p2 = new Post(
                DateTime.Now,
                "Good night guys",
                "See you tomorrow",
                5);
            p2.addComment(c3);
            p2.addComment(c4);

            Console.WriteLine(p1);
            Console.WriteLine();
            Console.WriteLine(p2);
        }
    }
}
