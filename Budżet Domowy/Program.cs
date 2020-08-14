using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using static Budżet_Domowy.Class1;

namespace Budżet_Domowy
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();

            Login panelSterowania = new Login();

            List<StrukturaKonta> listaKont = new List<StrukturaKonta>();
            StrukturaKonta wbudowaneAcc = InicjujWbudowaneAcc(listaKont);
            StrukturaKonta createNewMember = new StrukturaKonta();
            createNewMember.nazwa = "Przemek";
            createNewMember.hasło = "Kowalczyk";
            createNewMember.nazwaWydatku = "Apteka";
            createNewMember.kwotaWydatku = 120;
            listaKont.Add(createNewMember);

            var konto = panelSterowania.Zaloguj(ref listaKont, ref wbudowaneAcc, ref createNewMember, ref arrayList);

            List<StrukturaWydatku> listaWydatków = ZainicjujListę();
            List<StrukturaWydatku> listaNewMembera = new List<StrukturaWydatku>();

            bool koniec = false;

            while (!koniec)
            {
                 DashBoard(ref listaWydatków, ref koniec, ref panelSterowania, ref wbudowaneAcc, ref listaKont,
                           ref createNewMember, ref konto, ref listaNewMembera, ref arrayList);
            }

        }

        public static StrukturaKonta WbudowaneKonto(ArrayList arrayList)
        {
            List<StrukturaKonta> stwórzKonto = new List<StrukturaKonta>();
            StrukturaKonta logIpass = new StrukturaKonta();
            logIpass.nazwa = "Pikej";
            logIpass.hasło = "qwerty";
            stwórzKonto.Add(logIpass);
            StrukturaKonta wydatek = new StrukturaKonta();
            wydatek.nazwaWydatku = "Apteka";
            wydatek.kwotaWydatku = 120;
            StrukturaKonta wydatek2 = new StrukturaKonta();
            wydatek2.nazwaWydatku = "Pizza";
            wydatek2.kwotaWydatku = 55;
            StrukturaKonta wydatek3 = new StrukturaKonta();
            wydatek3.nazwaWydatku = "Diamenty";
            wydatek3.kwotaWydatku = 10000;
            stwórzKonto.Add(wydatek);
            stwórzKonto.Add(wydatek2);
            stwórzKonto.Add(wydatek3);
            arrayList.Add(stwórzKonto);
            return logIpass;
        }

        private static StrukturaKonta InicjujWbudowaneAcc(List<StrukturaKonta> listaKont)
        {
            StrukturaKonta wbudowaneAcc = new StrukturaKonta();
            wbudowaneAcc.nazwa = "Pikej";
            wbudowaneAcc.hasło = "qwerty";
            listaKont.Add(wbudowaneAcc);
            return wbudowaneAcc;
        }

        private static List<StrukturaWydatku> ZainicjujListę()
        {
            List<StrukturaWydatku> listaWydatków = new List<StrukturaWydatku>();
            StrukturaWydatku wydatek01 = new StrukturaWydatku();
            wydatek01.data = DateTime.UtcNow.ToShortDateString();
            wydatek01.nazwa = "Zakupy w Biedrze";
            wydatek01.kwota = 122;
            var wydatek02 = new StrukturaWydatku();
            wydatek02.data = DateTime.UtcNow.ToShortDateString();
            wydatek02.nazwa = "Lidl";
            wydatek02.kwota = 100;
            var wydatek03 = new StrukturaWydatku();
            wydatek03.data = DateTime.UtcNow.ToShortDateString();
            wydatek03.nazwa = "Opłacenie rachunków";
            wydatek03.kwota = 120;
            listaWydatków.Add(wydatek01);
            listaWydatków.Add(wydatek02);
            listaWydatków.Add(wydatek03);
            return listaWydatków;
        }

        public static void DashBoard(ref List<StrukturaWydatku> listaWydatków,
                                     ref bool koniec,
                                     ref Login panelSterowania,
                                     ref StrukturaKonta wbudowaneAcc,
                                     ref List<StrukturaKonta> listaKont,
                                     ref StrukturaKonta createNewMember,
                                     ref StrukturaKonta konto,
                                     ref List<StrukturaWydatku> listaNewMembera,
                                     ref ArrayList arrayList
                                     )
        {
            Console.WriteLine("Witaj w Twoim Budżecie Domowym!");
            Console.ReadKey();
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1 - Lista wydatków");
            Console.WriteLine("2 - Dodaj wydatek");
            Console.WriteLine("3 - Usuń wydatek");
            Console.WriteLine("4 - Dodaj użytkownika");
            Console.WriteLine("5 - Wyloguj");
            Console.WriteLine("6 - Zakończ");

            PobierzKomende(ref listaWydatków, ref koniec, ref panelSterowania, ref wbudowaneAcc, 
                ref listaKont, ref createNewMember, ref konto, ref listaNewMembera, ref arrayList);
        }

        public static void PobierzKomende(ref List<StrukturaWydatku> listaWydatków,
                                                      ref bool koniec,
                                                      ref Login panelSterowania,
                                                      ref StrukturaKonta wbudowaneAcc,
                                                      ref List<StrukturaKonta> listaKont,
                                                      ref StrukturaKonta createNewMember,
                                                      ref StrukturaKonta konto,
                                                      ref List<StrukturaWydatku> listaNewMembera,
                                                      ref ArrayList arrayList
                                                      )
        {
            string komenda = Console.ReadLine();
            Console.Clear();
            DashBoardCommand operacje = WywołajKomende(komenda);
            switch (operacje)
            {
                case DashBoardCommand.ListaWydatków:
                    /*if (konto.nazwa.Contains(wbudowaneAcc.nazwa))
                    {
                        ShowListofCosts(ref listaWydatków);
                    }
                    else
                    {
                        if (konto.nazwa.Contains(createNewMember.nazwa))
                        {
                            ShowListofCosts(ref listaNewMembera);
                        }
                    }*/
                    foreach(var członek in listaKont)
                    {

                        Console.WriteLine($"var członek = {członek.nazwa} w liścieKont");
                        if (konto.nazwa == członek.nazwa)
                        {
                            Console.WriteLine($"konto.nazwa równa się: {konto.nazwa} = członek.nazwa równa się: {członek.nazwa}");


                            foreach (var wydatek in listaWydatków)
                            {
                                Console.WriteLine(wydatek.nazwa);
                                Console.WriteLine(wydatek.kwota);
                            }
                        }
                    }
                    break;
                case DashBoardCommand.DodajWydatek:
                    if (konto.nazwa.Contains(wbudowaneAcc.nazwa))
                    {
                        AddCostToList(ref listaWydatków);
                    }
                    else
                    {
                        if (konto.nazwa.Contains(createNewMember.nazwa))
                        {
                            AddCostToNewMemberList(ref listaNewMembera);
                        }
                        else
                        {
                            if(!konto.nazwa.Contains(wbudowaneAcc.nazwa) || !konto.nazwa.Contains(createNewMember.nazwa))
                            {

                            }
                        }
                    }
                    break;
                case DashBoardCommand.UsuńWydatek:
                    if (konto.nazwa.Contains(wbudowaneAcc.nazwa))
                    {
                        DelateCostFromList(ref listaWydatków);
                    }
                    else
                    {
                        if (konto.nazwa.Contains(createNewMember.nazwa))
                        {
                            DelateCostFromList(ref listaNewMembera);
                        }
                    }
                    break;
                case DashBoardCommand.DodajUżytkownika:
                    AddNewMember(ref listaKont, ref createNewMember);
                    break;
                case DashBoardCommand.Wyloguj:
                    konto = panelSterowania.Zaloguj(ref listaKont, ref wbudowaneAcc, ref createNewMember, ref arrayList);
                    break;
                case DashBoardCommand.Zakończ:
                    koniec = true;
                    Console.WriteLine($"Zamykanie Budżetu Domowego...");
                    break;
            }
            
        }

        private static void AddCostToNewMemberList(ref List<StrukturaWydatku> listaNewMembera)
        {
            StrukturaWydatku newMmberCosts = new StrukturaWydatku();
            newMmberCosts.data = DateTime.UtcNow.ToShortDateString();
            Console.WriteLine($"Podaj nazwę wydatku:");
            newMmberCosts.nazwa = Console.ReadLine();
            Console.WriteLine($"Podaj kwotę wydatku:");
            newMmberCosts.kwota = double.Parse(Console.ReadLine());
            listaNewMembera.Add(newMmberCosts);
            Console.WriteLine($"Wydatek {newMmberCosts.nazwa} o cenie {newMmberCosts.kwota} zł, został dodany do listy");
            Console.WriteLine($"Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
        }

        public static StrukturaKonta AddNewMember(ref List<StrukturaKonta> listaKont, ref StrukturaKonta createNewMember)
        {
            Console.WriteLine("Podaj nową nawę użytkownika:");
            createNewMember.nazwa = Console.ReadLine();
            Console.WriteLine("Stwórz nowe hasło:");
            createNewMember.hasło = Console.ReadLine();
            listaKont.Add(createNewMember);
            Console.WriteLine($"Konto: {createNewMember.nazwa}, zostało dodane do listy.");
            Console.WriteLine($"Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
            return createNewMember;
        }

        private static void DelateCostFromList(ref List<StrukturaWydatku> listaWydatków)
        {
            Console.WriteLine($"Podaj pozycję wydatku zaczynając od 0:");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine($"Wydatek: {listaWydatków[index].data} {listaWydatków[index].nazwa} {listaWydatków[index].kwota} zł, został usunięty z listy");
            listaWydatków.Remove(listaWydatków[index]);
            Console.WriteLine($"Naciśnij dowolny klawisz, aby kontnuować...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void AddCostToList(ref List<StrukturaWydatku> listaWydatków)
        {
            StrukturaWydatku createNewCost = new StrukturaWydatku();
            createNewCost.data = DateTime.UtcNow.ToShortDateString();
            Console.WriteLine($"Podaj nazwę wydatku:");
            createNewCost.nazwa = Console.ReadLine();
            Console.WriteLine($"Podaj kwotę wydatku:");
            createNewCost.kwota = double.Parse(Console.ReadLine());
            listaWydatków.Add(createNewCost);
            Console.WriteLine($"Wydatek {createNewCost.nazwa} o cenie {createNewCost.kwota} zł, został dodany do listy");
            Console.WriteLine($"Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
        }

        public static DashBoardCommand WywołajKomende(string komenda)
        {
            if (komenda == "1" || komenda == "2" || komenda == "3" || komenda == "4" || komenda == "5" || komenda == "6")
            {
                return (DashBoardCommand)int.Parse(komenda);
            }
           /* else
            {*/
                while(komenda != "1" || komenda != "2" || komenda != "3" || komenda != "4" || komenda != "5" || komenda != "6")
                {
                    Console.WriteLine($"Error {komenda} nie mieści się w zakresie komęd\nNaciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Co chcesz zrobić?");
                    Console.WriteLine("1 - Lista wydatków");
                    Console.WriteLine("2 - Dodaj wydatek");
                    Console.WriteLine("3 - Usuń wydatek");
                    Console.WriteLine("4 - Dodaj użytkownika");
                    Console.WriteLine("5 - Wyloguj");
                    Console.WriteLine("6 - Zakończ");
                    komenda = Console.ReadLine();

                    if (komenda == "1" || komenda == "2" || komenda == "3" || komenda == "4" || komenda == "5" || komenda == "6")
                    {
                    Console.Clear();
                    return (DashBoardCommand)int.Parse(komenda);
                    }
                /*}*/
            }
            return (DashBoardCommand)int.Parse(komenda);
        }
    }
}
