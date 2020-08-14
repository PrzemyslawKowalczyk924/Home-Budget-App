using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Budżet_Domowy
{
    class Class1
    {
        public struct Login
        {
            public string nazwaUrzytkownika;
            public string hasło;
            
            public StrukturaKonta Zaloguj(ref List<StrukturaKonta> listaKont,
                                          ref StrukturaKonta wbudowaneAcc,
                                          ref StrukturaKonta createNewMember,
                                          ref ArrayList arrayList
                                          )
            {
                
                Console.WriteLine("Podaj nazwę użytkownika:");
                nazwaUrzytkownika = Console.ReadLine();
                Console.WriteLine("Podaj hasło:");
                hasło = Console.ReadLine();




                foreach (var singleAccount in listaKont)
                {
                    Console.WriteLine(singleAccount.nazwa);
                    Console.WriteLine(singleAccount.nazwaWydatku);
                    if (nazwaUrzytkownika == singleAccount.nazwa && hasło == singleAccount.hasło)
                    {
                        Console.WriteLine("Zalogowano pomyślnie");
                        Console.ReadKey();
                        Console.Clear();
                        return singleAccount;
                    }
                }

                Console.WriteLine("Błędne hasło lub nazwa użytkownika");
                Console.WriteLine("Naciśnij dowolony klawisz, aby kontynuować...");
                Console.ReadKey();
                Console.Clear();
                return Zaloguj(ref listaKont, ref wbudowaneAcc, ref createNewMember, ref arrayList);
            }
        }

        public struct StrukturaKonta
        {
            public string nazwa;
            public string hasło;

            public string nazwaWydatku;
            public string dataWydatku;
            public decimal kwotaWydatku;

            public void MakeAcc()
            {
                Console.WriteLine("Stwórz nazwę konta:");
                nazwa = Console.ReadLine();
                Console.WriteLine("Stwórz hasło:");
                hasło = Console.ReadLine();
                Console.WriteLine($"Brawo, konto {nazwa} zostało utworzone!");
                Console.ReadKey();
                Console.Clear();
            }

            public List<StrukturaKonta> MakeList()
            {
                List<StrukturaKonta> wewnętrznaLista = new List<StrukturaKonta>();
                return wewnętrznaLista;
            }

            public StrukturaKonta MakeCost(List<StrukturaKonta> listaKont)
            {
                StrukturaKonta wydatek = new StrukturaKonta();
                Console.WriteLine("Podaj nazwę wydatku:");
                wydatek.nazwaWydatku = Console.ReadLine();
                Console.WriteLine("Podaj kwotę wydatku:");
                wydatek.kwotaWydatku = decimal.Parse(Console.ReadLine());
                listaKont.Add(wydatek);
                return wydatek;
            }

        }

        public struct StrukturaWydatku
        {
            public string nazwa;
            public string data;
            public double kwota;
        }

        public enum TypWydatku
        {
            Zakupy = 0,
            Rachunki = 1,
            CzasWolny = 2,
        }
        public enum DashBoardCommand
        {
            ListaWydatków = 1,
            DodajWydatek = 2,
            UsuńWydatek = 3,
            DodajUżytkownika = 4,
            Wyloguj = 5,
            Zakończ = 6,
        }

        public static StrukturaKonta StwórzKonto(ref ArrayList arrayList)
        {
            List<StrukturaKonta> stwórzKont3 = new List<StrukturaKonta>();
            StrukturaKonta logIpass3 = new StrukturaKonta();
            Console.WriteLine("Podaj nazwę nowego konta:");
            logIpass3.nazwa = Console.ReadLine();
            Console.WriteLine("Podaj hasło do nowego konta:");
            logIpass3.hasło = Console.ReadLine();
            stwórzKont3.Add(logIpass3);
            Console.WriteLine($"Konto: {logIpass3.nazwa}, zostało dodane do listy.");
            Console.WriteLine($"Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
            return logIpass3;
        }


    }

    public struct Struktura
    {
        public string nazwa;
        public string hasło;

        public string nazwaWydatku;
        public double kwotaWydatku;
    }

}
