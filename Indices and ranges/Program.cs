

namespace indicesandranges
{
  public class Program
    {
        public static void Main(string[] args)
        {
            string[] words = new string[]
               {
                "The","quick","brown","fox","jumps","over","the","lazy","dog"
               };
            Console.WriteLine($"The last word is {words[^1]}");
            string[] quickBrownFox = words[1..4];
            // the last one that is the one at index four is not included 
            foreach (var word in quickBrownFox)
                Console.WriteLine($"<{word} >");
            string[] lazyDog = words[^2..^0];
            foreach (var word in lazyDog)
                Console.WriteLine($"<{word}>");
            // All the words in the words string array 
            string[] allWords = words[..];
            //All the words in the string array till the third index 
            string[] firstPhrase = words[..4];
            // All the words in the string array from the sixth index to the end of the array
            string[] lastPhrase = words[6..];
            foreach(var word in allWords)
                Console.WriteLine($"<{word}>");
            foreach(var word in firstPhrase)
                Console.WriteLine($"<{word}>");
            foreach(var word in lastPhrase)
                Console.WriteLine($"<{word}>");
            // You can also declare ranges and indices as variables 
            Index the = ^3;
            Console.WriteLine(words[the]);
            Range phrase = 1..4;
            string[] text = words[phrase];
            foreach (var word in text)
                Console.WriteLine($"<{word}>");
            int[] numbers = Enumerable.Range(0, 100).ToArray();
            int x = 12;
            int y = 25;
            int z = 36;

            Console.WriteLine($"{numbers[^x]} is the same as {numbers[numbers.Length - x]}");
            Console.WriteLine($"{numbers[x..y].Length} is the same as {y - x}");

            Console.WriteLine("numbers[x..y] and numbers[y..z] are consecutive and disjoint");

            Span<int> x_y = numbers[x..y];
            Span<int> y_z = numbers[y..z];
            Console.WriteLine($"\tnumbers[x..y] is {x_y[0]} through {x_y[^1]}, numbers[y..z] is {y_z[0]} through {y_z[^1]}");


            //This is the implicit way of creating a range 
            Range implicitRange = 3..^5;
            // This is the explicit way of creating a range 
            Range explicitRange = new (
                start: new Index(value: 3, fromEnd: false),
                end: new Index(value: 5, fromEnd: true));
            if (implicitRange.Equals(explicitRange))
            {
                Console.WriteLine($"The implicit range '{implicitRange}' equals the explicit range {explicitRange}");
            }

            var jaggedArray = new int[10][]
            {
                new int[10] {0,1,2,3,4,5,6,7,8,9,},
                new int[10] { 10,11,12,13,14,15,16,17,18,19 },
                new int[10] { 20,21,22,23,24,25,26,27,28,29 },
                new int[10] { 30,31,32,33,34,35,36,37,38,39 },
                new int[10] { 40,41,42,43,44,45,46,47,48,49 },
                new int[10] { 50,51,52,53,54,55,56,57,58,59 },
                new int[10] { 60,61,62,63,64,65,66,67,68,69 },
                new int[10] { 70,71,72,73,74,75,76,77,78,79 },
                new int[10] { 80,81,82,83,84,85,86,87,88,89 },
                new int[10] { 90,91,92,93,94,95,96,97,98,99 },
            };

            var selectedRows = jaggedArray[3..^3];

            foreach(var row in selectedRows)
            {
                var selectedColumns = row[2..^2];
                foreach (var cell in selectedColumns)
                {
                    Console.Write($"{cell},");
                }
            }

            int[] sequence = Sequence(1000);

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = start..(start + 10);
                var (min, max, average) = MovingAverage(sequence, r);

                Console.WriteLine($"From {r.Start} to {r.End}: \tMin :{min},tMax:{max}, tAverage:{average}");
            }

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = ^(start + 10)..^start;
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}:  \tMin: {min},\tMax: {max},\tAverage: {average}");
            }
            (int min, int max, double Average) MovingAverage(int[] subSequence, Range range) =>
                (
                subSequence[range].Min(),
                subSequence[range].Max(),
                subSequence[range].Average()
                );
            int[] Sequence(int count) => Enumerable.Range(0, count).Select(x => (int)(Math.Sqrt(x) * 100)).ToArray();

            var arrayOfFiveItems = new[] { 1, 2, 3, 4, 5 };

            var firstThreeItems = arrayOfFiveItems[..3];

            firstThreeItems[0] = 11;

            Console.WriteLine(string.Join(",", firstThreeItems));
            Console.WriteLine(string.Join(",", arrayOfFiveItems));
        }
    }
}