

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
            const int NameAlignment = -9;
            const int ValueAlignment = 7;
            Console.WriteLine($"Three classical Pythagorean means of {a} and {b}:");
            Console.WriteLine($"|{"Arithmetic",NameAlignment}|{0.5 * (a + b),ValueAlignment:F3}|");
            Console.WriteLine($"|{"Geometric",NameAlignment} {Math.Sqrt(a * b),ValueAlignment:F3}");
            Console.WriteLine($"|{"Hramonic",NameAlignment}|{2 / (1 / a + 1 /b),ValueAlignment:F3}|");


            // Expected output:
            // Three classical Pythagorean means of 3 and 4:
            // |Arithmetic|  3.500|
            // |Geometric|  3.464|
            // |Harmonic |  3.429|
        }
    }
}