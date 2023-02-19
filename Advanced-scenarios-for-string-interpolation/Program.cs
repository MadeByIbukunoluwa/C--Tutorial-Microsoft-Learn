

using Microsoft.VisualBasic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TeleprompterConsole
{
    public class stringInterpolation
    {
        static void Main()
        {
            double a = 3;
            double b = 4;
            double CalculateHypotenuse(double leg1, double leg2) => Math.Sqrt(leg1 * leg1 + leg2 * leg2);
            var date = new DateTime(1731, 11, 25);
            Console.WriteLine($"Area of the right triangle with legs of {a} and {b} is {0.5 * a * b}");
            Console.WriteLine($"Length of the hypotenuse of the right triangle with legs of {a} and {b} is {CalculateHypotenuse(a, b)}");
            Console.WriteLine($"On {date:dddd,MMMM dd,yyyy} Leonrad Euler introduced the letter e to denote {Math.E:F5} in a letter to denote Christian Goldbach");
            // string interpolation with alignment
            const int NameAlignment = -9;
            const int ValueAlignment = 7;
            Console.WriteLine($"Three classical Pythagorean means of {a} and {b}:");
            Console.WriteLine($"|{"Arithmetic",NameAlignment}|{0.5 * (a + b),ValueAlignment:F3}|");
            Console.WriteLine($"|{"Geometric",NameAlignment} {Math.Sqrt(a * b),ValueAlignment:F3}");
            Console.WriteLine($"|{"Harmonic",NameAlignment}|{2 / (1 / a + 1 / b),ValueAlignment:F3}|");


            // Expected output:
            // Three classical Pythagorean means of 3 and 4:
            // |Arithmetic|  3.500|
            // |Geometric|  3.464|
            // |Harmonic |  3.429|
            // include braces in a reislt string ans construct a verabtim interpolated string
            var xs = new int[] { 1, 2, 7, 9 };
            var ys = new int[] { 7, 9, 12 };
            Console.WriteLine($"Find the intersection of the {{{string.Join(", ", xs)}}} and {{{string.Join(", ", ys)}}} sets.");
            var userName = "Jane";
            var stringWithEscapes = $"C:\\Users\\{userName}\\Documents";
            var verbatimInterpolated = $@"C:\Users\{userName}\Documents";
            Console.WriteLine(stringWithEscapes);
            Console.WriteLine(verbatimInterpolated);
            //using the ternary operator in an interpolation expression
            var rand = new Random();
            for(int i = 0; i < 7;i++)
            {
                Console.WriteLine($"Coin flip:{(rand.NextDouble() < 0.5 ? "heads" : "tails")}");
            }
            //By default, an interpolated string uses the current culture defined by the CultureInfo.CurrentCulture property for all formatting operations.
            //Use implicit conversion of an interpolated string to a System.FormattableString instance and call its ToString(IFormatProvider) method
            //to create a culture-specific result string. The following example shows how to do that:
            var cultures = new System.Globalization.CultureInfo[]
            {
                System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
                System.Globalization.CultureInfo.GetCultureInfo("nl-NL"),
                System.Globalization.CultureInfo.InvariantCulture
            };

            var Date = DateTime.Now;
            var Number = 31_415_926.536;
            FormattableString message = $"{Date,20}{Number,20:N3}";
            foreach(var culture in cultures)
            {
                var cultureSpeciificMessage = message.ToString(culture);
                Console.WriteLine($"{culture.Name,-10}{cultureSpeciificMessage}");
            }
        }
    }
}