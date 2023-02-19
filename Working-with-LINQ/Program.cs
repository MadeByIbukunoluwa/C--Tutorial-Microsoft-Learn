//https:\//learn.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq
using System;
using System.Collections.Generic;
using System.Linq;
using LinqFaroShuffle;

public class Program
{
     static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                           from r in Ranks().LogQuery("Rank Generation")
                           select new { Suits = s, Rank = r }).LogQuery("Starting Deck");
        //foreach(var card in startingDeck)
        //{
        //    Console.WriteLine(card);
        //}
        foreach(var c in startingDeck)
        {
            Console.WriteLine(c);
        }
        var top = startingDeck.Take(26);
        var bottom = startingDeck.Skip(26);
        var shuffle = top.InterleaveSequenceWith(bottom);

        foreach (var c in shuffle)
        {
            Console.WriteLine(c);
        }
        var times = 0;
        shuffle = startingDeck;
        do
        {
            //shuffle = shuffle.Take(26)
            //    .LogQuery("Top Half")
            //    .InterleaveSequenceWith(shuffle.Skip(26)
            //    .LogQuery("Bottom Half"))
            //    .LogQuery("Shuffle"); ;


            shuffle = shuffle.Skip(26)
                .LogQuery("Bottom Half")
                .InterleaveSequenceWith(shuffle.Take(26)
                .LogQuery("Top Half"))
                .LogQuery("Shuffle");


            foreach(var card in shuffle)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine(Environment.NewLine);
            times++;
            Console.WriteLine(times);
        } while (!startingDeck.SequenceEqual(shuffle));
        Console.WriteLine(times);
    }
    static IEnumerable<string> Suits()
    {
        yield return "clubs";
        yield return "diamonds";
        yield return "hearts";
        yield return "spades";
    }

    static IEnumerable<string> Ranks()
    {
        yield return "two";
        yield return "three";
        yield return "four";
        yield return "five";
        yield return "six";
        yield return "seven";
        yield return "eight";
        yield return "nine";
        yield return "ten";
        yield return "jack";
        yield return "queen";
        yield return "king";
        yield return "ace";
    }

}








