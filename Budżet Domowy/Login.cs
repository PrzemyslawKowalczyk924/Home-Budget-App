using System;

namespace Budżet_Domowy
{
    partial class Program
    {
        struct Login
        {
            public string nazwaUrzytkownika;
            public string hasło;
            public void Zaloguj()
            {
                Console.WriteLine("Podaj nazwę użytkownika:");
                nazwaUrzytkownika = Console.ReadLine();
                Console.WriteLine("Podaj hasło:");
                hasło = Console.ReadLine();
                while (nazwaUrzytkownika != "Pikej" || hasło != "qwerty")
                {
                    Console.WriteLine("Błędne hasło lub nazwa użytkownika");
                    Console.WriteLine("Podaj nazwę użytkownika:");
                    nazwaUrzytkownika = Console.ReadLine();
                    Console.WriteLine("Podaj hasło:");
                    hasło = Console.ReadLine();
                }
                if (nazwaUrzytkownika == "Pikej" && hasło == "qwerty")
                {
                    Console.WriteLine("Zalogowano pomyślnie");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
