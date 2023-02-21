

namespace LinqFaroShuffle
{
    //we can write our own Extension methods to add our own custom functionality to LINQ queries
    public static class Extensions
    {
        public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();
            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }

    public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        var firstIter = first.GetEnumerator();
        var secondIter = second.GetEnumerator();

        while (firstIter.MoveNext() && secondIter.MoveNext())
        {
            if (!firstIter.Current.Equals(secondIter.Current))
            {
                return false;
            }
        }
        return true;
    }
        // We can create an extension method, for this query to have the ability to log to a .txt file when we create a query .
        // First run generated a really large .txt file and it had't even finished execution
        public static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
        {
            using (var writer = File.AppendText("/Users/ibukunoluwaakintobi/Documents/log.txt"))
            {
                writer.WriteLine($"Executing Query {tag}");
            }
            return sequence;
        }
}
}