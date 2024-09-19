using System;

namespace WpfApp1
{
    class Program
    {
        static string SprPlec(string pesel)
        {
            int cyfraPlec = int.Parse(pesel[9].ToString());

            if (cyfraPlec % 2 == 0)
                return "Kobieta";
            else
                return "Mężczyzna";
        }
        static bool SprawdzPesel(string pesel)
        {
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += int.Parse(pesel[i].ToString()) * wagi[i];
            }

            int kontrolnaCyfra = (10 - (suma % 10)) % 10;
            return kontrolnaCyfra == int.Parse(pesel[10].ToString());
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Podaj PESEL:");
            string pesel = Console.ReadLine();
            if (pesel.Length != 11 || !long.TryParse(pesel, out _))
            {
                Console.WriteLine("Nieprawidłowy PESEL.");
                return;
            }
            string plec = SprPlec(pesel);
            Console.WriteLine($"Płeć: {plec}");

            if (SprawdzPesel(pesel))
            {
                Console.WriteLine("Numer pesel jest poprawny");
            }
            else
            {
                Console.WriteLine("Numer pesel jest niepoprawny");
            }
        }
    }
}