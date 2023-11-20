using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_2_C_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool provjeraUnosa = true;
            int unos = 1;
            int br = 1;

            var radnici = new Dictionary<string, DateTime>()
            {
                {"Ante Antic", new DateTime(2000, 01, 01) },
                {"Mate Matic", new DateTime(1955, 09, 15) },
                {"Lovre Lovric", new DateTime(1990, 12, 03) },
                {"Ana Anic", new DateTime(1950, 05, 23) },
                {"Roko Rokic", new DateTime(1977, 07, 19) },
            };

            var artikli = new Dictionary<string, (int, double, DateTime)>()
            {
                {"Mlijeko", (300, 2d, new DateTime(2023, 10, 15)) },
                {"Jaja", (600, 1d, new DateTime(2024, 01, 01)) },
                {"Sir", (100, 3d, new DateTime(2025, 06, 20)) },
                {"Sunka", (50, 2d, new DateTime(2023, 11, 25)) },
                {"Sok", (70, 2d, new DateTime(2024, 10, 08)) },
            };

            var racuni = new Dictionary<int, (DateTime, Dictionary<string, int>, double)>()
            {
                {br++, (new DateTime(2023, 11, 11, 21, 05, 13), new Dictionary<string, int>(){{"Mlijeko", 2}, {"Sok", 1}}, 6d)},
                {br++, (new DateTime(2023, 10, 26, 13, 43, 52), new Dictionary<string, int>(){{"Sunka", 1}, {"Sir", 2}}, 8d)},
            };

            while (unos != 0)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Artikli");
                    Console.WriteLine("2 - Radnici");
                    Console.WriteLine("3 - Racuni");
                    Console.WriteLine("4 - Statistika");
                    Console.WriteLine("0 - Izlaz iz aplikacije");
                    if (!provjeraUnosa)
                    {
                        Console.WriteLine("Krivi unos, pokusajte ponovno:");
                    }
                    provjeraUnosa = int.TryParse(Console.ReadLine(), out unos);
                } while (!provjeraUnosa);

                switch (unos)
                {
                    case 1:
                        int unos1 = 1;
                        while (unos1 != 0)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("1 - Unos artikla");
                                Console.WriteLine("2 - Brisanje artikla");
                                Console.WriteLine("3 - Uredivanje artikla");
                                Console.WriteLine("4 - Ispis");
                                Console.WriteLine("0 - Povratak na pocetni izbornik");
                                if (!provjeraUnosa)
                                {
                                    Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                }
                                provjeraUnosa = int.TryParse(Console.ReadLine(), out unos1);
                            } while (!provjeraUnosa);

                            string imeArtikla;
                            int kolicinaArtikla;
                            int cijenaArtikla;
                            DateTime datumIstekaArtikla;
                            switch (unos1)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Unesite ime artikla:");
                                    imeArtikla = Console.ReadLine();

                                    Console.Clear();
                                    Console.WriteLine("Unesite kolicinu artikla:");
                                    kolicinaArtikla = int.Parse(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("Unesite cijenu artikla:");
                                    cijenaArtikla = int.Parse(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("Unesite datum rodenja novog radnika (Godina mjesec dan):");
                                    datumIstekaArtikla = DateTime.Parse(Console.ReadLine());

                                    artikli.Add(imeArtikla, (kolicinaArtikla, cijenaArtikla, datumIstekaArtikla));

                                    Console.Clear();
                                    Console.WriteLine("Uspjesno dodan artikl, pritisnite neku tipku za povratak na pocetni izbornik.");
                                    Console.ReadKey();
                                    unos1 = 0;

                                    break;
                                case 2:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Brisanje artikla:");
                                        Console.WriteLine("a - Po imenu artikla");
                                        Console.WriteLine("b - Onima kojima je istekao datum trajanja");
                                        Console.WriteLine("0 - Povratak na pocetni izbornik");
                                        if (!provjeraUnosa)
                                        {
                                            Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                        }
                                        var unos12 = Console.ReadLine();

                                        if (unos12 == "0")
                                        {
                                            provjeraUnosa = true;
                                            unos1 = 0;
                                            break;
                                        }

                                        else if (unos12 == "a")
                                        {
                                            provjeraUnosa = true;
                                            do
                                            {
                                                Console.Clear();
                                                if (!provjeraUnosa)
                                                    Console.Write("Taj artikl ne postoji. ");
                                                Console.WriteLine("Unesite ime artikla kojeg zelite izbrisati ili 0 za povratak na pocetni izbornik:");
                                                imeArtikla = Console.ReadLine();
                                                if (artikli.ContainsKey(imeArtikla) || imeArtikla == "0")
                                                {
                                                    provjeraUnosa = true;
                                                    break;
                                                }
                                                else
                                                    provjeraUnosa = false;
                                            } while (!provjeraUnosa);

                                            if (imeArtikla == "0")
                                            {
                                                unos1 = 0;
                                                break;
                                            }

                                            Console.Clear();
                                            Console.WriteLine("Jeste li sigurni da zelite izbrisati ovaj artikl (da/ne):");
                                            string potvrda = Console.ReadLine();

                                            Console.Clear();
                                            if (potvrda == "da")
                                            {
                                                artikli.Remove(imeArtikla);
                                                Console.WriteLine("Uspjesno izbrisan artikl, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            }
                                            else
                                                Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                            unos1 = 0;
                                        }

                                        else if (unos12 == "b")
                                        {
                                            provjeraUnosa = true;

                                            Console.Clear();
                                            Console.WriteLine("Jeste li sigurni da zelite izbrisati sve artikle kojima je istekao datum trajanja (da/ne):");
                                            string potvrda = Console.ReadLine();

                                            Console.Clear();
                                            if (potvrda == "da")
                                            {
                                                var list = new List<string>();

                                                foreach (var item in artikli)
                                                    if (DateTime.Now > item.Value.Item3)
                                                        list.Add(item.Key);
                                                    else
                                                        list.Add("0");

                                                int pozicija = 0;
                                                foreach (var item in list)
                                                {
                                                    if (item != "0")
                                                        artikli.Remove(list[pozicija]);
                                                    pozicija++;
                                                }

                                                Console.WriteLine("Uspjesno izbrisan/i artikl/i, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            }
                                            else
                                                Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                            unos1 = 0;
                                        }

                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);
                                    break;
                                case 3:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Uredivanje:");
                                        Console.WriteLine("a - Zasebnog proizvoda (Unesite ime artikla)");
                                        Console.WriteLine("b - Popust/poskupljenje na sve proizvode");
                                        Console.WriteLine("0 - Povratak na pocetni izbornik");
                                        if (!provjeraUnosa)
                                        {
                                            Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                        }
                                        var unos13 = Console.ReadLine();

                                        if (unos13 == "0")
                                        {
                                            provjeraUnosa = true;
                                            unos1 = 0;
                                            break;
                                        }

                                        else if (unos13 == "a")
                                        {
                                            provjeraUnosa = true;
                                            do
                                            {
                                                Console.Clear();
                                                if (!provjeraUnosa)
                                                    Console.Write("Taj artikl ne postoji. ");
                                                Console.WriteLine("Unesite ime artikla kojeg zelite urediti ili 0 za povratak na pocetni izbornik:");
                                                imeArtikla = Console.ReadLine();
                                                if (artikli.ContainsKey(imeArtikla) || imeArtikla == "0")
                                                {
                                                    provjeraUnosa = true;
                                                    break;
                                                }
                                                else
                                                    provjeraUnosa = false;
                                            } while (!provjeraUnosa);

                                            if (imeArtikla == "0")
                                            {
                                                unos1 = 0;
                                                break;
                                            }

                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Sto zelite promijeniti:");
                                                Console.WriteLine("a - Ime artikla");
                                                Console.WriteLine("b - Kolicinu artikla");
                                                Console.WriteLine("c - Cijenu artikla");
                                                Console.WriteLine("d - Datum isteka artikla");
                                                Console.WriteLine("0 - Povratak na pocetni izbornik");
                                                if (!provjeraUnosa)
                                                {
                                                    Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                                }
                                                var unos131 = Console.ReadLine();

                                                if (unos131 == "0")
                                                {
                                                    provjeraUnosa = true;
                                                    unos1 = 0;
                                                    break;
                                                }

                                                else if (unos131 == "a")
                                                {
                                                    provjeraUnosa = true;

                                                    Console.Clear();
                                                    Console.WriteLine("Unesite novo ime artikla ili 0 za povratak na pocetni izbornik:");
                                                    string novoImeArtikla = Console.ReadLine();

                                                    if (novoImeArtikla == "0")
                                                    {
                                                        unos1 = 0;
                                                        break;
                                                    }

                                                    Console.Clear();
                                                    Console.WriteLine("Jeste li sigurni da zelite promijeniti ime ovog artikla (da/ne):");
                                                    string potvrda = Console.ReadLine();

                                                    Console.Clear();
                                                    if (potvrda == "da")
                                                    {
                                                        var value = artikli[imeArtikla];
                                                        artikli.Remove(imeArtikla);
                                                        artikli.Add(novoImeArtikla, value);
                                                        Console.WriteLine("Uspjesno promijenjeno ime artikla, pritisnite neku tipku za povratak na pocetni izbornik.");
                                                    }

                                                    else
                                                        Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                                    Console.ReadKey();
                                                    unos1 = 0;
                                                }

                                                else if (unos131 == "b")
                                                {
                                                    provjeraUnosa = true;

                                                    Console.Clear();
                                                    Console.WriteLine("Unesite novu kolicinu artikla ili 0 za povratak na pocetni izbornik:");
                                                    int novaKolicinaArtikla = int.Parse(Console.ReadLine());
                                                    
                                                    if (novaKolicinaArtikla == 0)
                                                    {
                                                        unos1 = 0;
                                                        break;
                                                    }
                                                    
                                                    Console.Clear();
                                                    Console.WriteLine("Jeste li sigurni da zelite promijeniti kolicinu ovog artikla (da/ne):");
                                                    string potvrda = Console.ReadLine();

                                                    Console.Clear();
                                                    if (potvrda == "da")
                                                    {
                                                        double privremenaCijenaArtikla = artikli[imeArtikla].Item2;
                                                        DateTime privremeniDatumIstekaArtikla = artikli[imeArtikla].Item3;
                                                        artikli[imeArtikla] = (novaKolicinaArtikla, privremenaCijenaArtikla, privremeniDatumIstekaArtikla);
                                                        Console.WriteLine("Uspjesno promijenjena kolicina artikla, pritisnite neku tipku za povratak na pocetni izbornik.");
                                                    }

                                                    else
                                                        Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                                    Console.ReadKey();
                                                    unos1 = 0;
                                                }

                                                else if (unos131 == "c")
                                                {
                                                    provjeraUnosa = true;

                                                    Console.Clear();
                                                    Console.WriteLine("Unesite novu cijenu artikla ili 0 za povratak na pocetni izbornik:");
                                                    int novaCijenaArtikla = int.Parse(Console.ReadLine());

                                                    if (novaCijenaArtikla == 0)
                                                    {
                                                        unos1 = 0;
                                                        break;
                                                    }

                                                    Console.Clear();
                                                    Console.WriteLine("Jeste li sigurni da zelite promijeniti cijenu ovog artikla (da/ne):");
                                                    string potvrda = Console.ReadLine();

                                                    Console.Clear();
                                                    if (potvrda == "da")
                                                    {
                                                        int privremenaKolicinaArtikla = artikli[imeArtikla].Item1;
                                                        DateTime privremeniDatumIstekaArtikla = artikli[imeArtikla].Item3;
                                                        artikli[imeArtikla] = (privremenaKolicinaArtikla, novaCijenaArtikla, privremeniDatumIstekaArtikla);
                                                        Console.WriteLine("Uspjesno promijenjena cijena artikla, pritisnite neku tipku za povratak na pocetni izbornik.");
                                                    }

                                                    else
                                                        Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                                    Console.ReadKey();
                                                    unos1 = 0;
                                                }

                                                else if (unos131 == "d")
                                                {
                                                    provjeraUnosa = true;

                                                    Console.Clear();
                                                    Console.WriteLine("Unesite novi datum isteka artikla (Godine mjesec dan):");
                                                    DateTime noviDatumIstekaArtikla = DateTime.Parse(Console.ReadLine());
                                                    
                                                    Console.Clear();
                                                    Console.WriteLine("Jeste li sigurni da zelite promijeniti datum isteka ovog artikla (da/ne):");
                                                    string potvrda = Console.ReadLine();

                                                    Console.Clear();
                                                    if (potvrda == "da")
                                                    {
                                                        int privremenaKolicinaArtikla = artikli[imeArtikla].Item1;
                                                        double privremenaCijenaArtikla = artikli[imeArtikla].Item2;
                                                        artikli[imeArtikla] = (privremenaKolicinaArtikla, privremenaCijenaArtikla, noviDatumIstekaArtikla);
                                                        Console.WriteLine("Uspjesno promijenjen datum isteka artikla, pritisnite neku tipku za povratak na pocetni izbornik.");
                                                    }

                                                    else
                                                        Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                                    Console.ReadKey();
                                                    unos1 = 0;
                                                }

                                                else
                                                    provjeraUnosa = false;
                                            } while (!provjeraUnosa);

                                            break;
                                        }

                                        else if (unos13 == "b")
                                        {
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Odaberite opciju:");
                                                Console.WriteLine("a - Popust na sve artikle");
                                                Console.WriteLine("b - Poskupljenje svih artikala");
                                                Console.WriteLine("0 - Povratak na pocetni izbornik");
                                                if (!provjeraUnosa)
                                                {
                                                    Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                                }
                                                var unos132 = Console.ReadLine();

                                                if (unos132 == "0")
                                                {
                                                    provjeraUnosa = true;
                                                    unos1 = 0;
                                                    break;
                                                }

                                                else if (unos132 == "a")
                                                {
                                                    provjeraUnosa = true;
                                                    unos1 = 0;

                                                    Console.Clear();
                                                    Console.WriteLine("Unesite postotak za koji zelite spustiti cijenu svih proizvoda (bez znaka %):");

                                                    int popust = int.Parse(Console.ReadLine());

                                                    Console.Clear();
                                                    Console.WriteLine("Jeste li sigurni da zelite spustiti cijenu svih artikla (da/ne):");
                                                    string potvrda = Console.ReadLine();

                                                    Console.Clear();
                                                    if (potvrda == "da")
                                                    {
                                                        var list = new List<string>();
                                                        
                                                        foreach (var item in artikli)
                                                            list.Add(item.Key);

                                                        int pozicija = 0;
                                                        foreach (var item in list)
                                                        {
                                                            artikli[list[pozicija]] = (artikli[list[pozicija]].Item1, Math.Round(artikli[list[pozicija]].Item2 - artikli[list[pozicija]].Item2 * ((double)popust / 100d), 2), artikli[list[pozicija]].Item3);
                                                            pozicija++;
                                                        }

                                                        Console.WriteLine("Uspjesno spustena cijena svih artikala, pritisnite neku tipku za povratak na pocetni izbornik.");
                                                    }

                                                    else
                                                        Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                                    Console.ReadKey();
                                                }

                                                else if (unos132 == "b")
                                                {
                                                    provjeraUnosa = true;
                                                    unos1 = 0;

                                                    Console.Clear();
                                                    Console.WriteLine("Unesite postotak za koji zelite povisiti cijenu svih proizvoda (bez znaka %):");

                                                    int poskupljenje = int.Parse(Console.ReadLine());

                                                    Console.Clear();
                                                    Console.WriteLine("Jeste li sigurni da zelite povisiti cijenu svih artikla (da/ne):");
                                                    string potvrda = Console.ReadLine();

                                                    Console.Clear();
                                                    if (potvrda == "da")
                                                    {
                                                        var list = new List<string>();

                                                        foreach (var item in artikli)
                                                            list.Add(item.Key);

                                                        int pozicija = 0;
                                                        foreach (var item in list)
                                                        {
                                                            artikli[list[pozicija]] = (artikli[list[pozicija]].Item1, Math.Round(artikli[list[pozicija]].Item2 + artikli[list[pozicija]].Item2 * ((double)poskupljenje / 100d), 2), artikli[list[pozicija]].Item3);
                                                            pozicija++;
                                                        }

                                                        Console.WriteLine("Uspjesno povisena cijena svih artikala, pritisnite neku tipku za povratak na pocetni izbornik.");
                                                    }

                                                    else
                                                        Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                                    Console.ReadKey();
                                                }

                                                else
                                                    provjeraUnosa = false;
                                            } while (!provjeraUnosa);
                                            break;
                                        }

                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);
                                    break;
                                case 4:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ispis:");
                                        Console.WriteLine("a - Svih artikala kako su spremljeni");
                                        Console.WriteLine("b - Svih artikala sortirano po imenu");
                                        Console.WriteLine("c - Svih artikala sortirano po datumu silazno");
                                        Console.WriteLine("d - Svih artikala sortirano po datumu silazno");
                                        Console.WriteLine("e - Svih artikala sortirano po kolicini");
                                        Console.WriteLine("f - Najprodavaniji artikl");
                                        Console.WriteLine("g - Najmanje prodavani artikl");
                                        Console.WriteLine("0 - Povratak na pocetni izbornik");
                                        if (!provjeraUnosa)
                                        {
                                            Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                        }
                                        var unos14 = Console.ReadLine();

                                        var prodavnostArtikala = new Dictionary<string, int>();
                                        foreach (var item in artikli)
                                            prodavnostArtikala.Add(item.Key, 0);

                                        if (unos14 == "0")
                                        {
                                            provjeraUnosa = true;
                                            unos1 = 0;
                                            break;
                                        }

                                        else if (unos14 == "a")
                                        {
                                            provjeraUnosa = true;
                                            Console.Clear();
                                            foreach (var item in artikli)
                                                Console.WriteLine($"{item.Key} ({item.Value.Item1}) - {item.Value.Item2}$ - {item.Value.Item3}");
                                            unos1 = 0;
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos14 == "b")
                                        {
                                            provjeraUnosa = true;
                                            var sortirano = artikli.OrderBy(item => item.Key);
                                            Console.Clear();
                                            foreach (var item in sortirano)
                                                Console.WriteLine($"{item.Key} ({item.Value.Item1}) - {item.Value.Item2}$ - {item.Value.Item3}");
                                            unos1 = 0;
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos14 == "c")
                                        {
                                            provjeraUnosa = true;
                                            var sortirano = artikli.OrderBy(item => item.Value.Item3);
                                            sortirano.Reverse();
                                            Console.Clear();
                                            foreach (var item in sortirano)
                                                Console.WriteLine($"{item.Key} ({item.Value.Item1}) - {item.Value.Item2}$ - {item.Value.Item3}");
                                            unos1 = 0;
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos14 == "d")
                                        {
                                            provjeraUnosa = true;
                                            var sortirano = artikli.OrderBy(item => item.Value.Item3);
                                            Console.Clear();
                                            foreach (var item in sortirano)
                                                Console.WriteLine($"{item.Key} ({item.Value.Item1}) - {item.Value.Item2}$ - {item.Value.Item3}");
                                            unos1 = 0;
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos14 == "e")
                                        {
                                            provjeraUnosa = true;
                                            var sortirano = artikli.OrderBy(item => item.Value.Item1);
                                            Console.Clear();
                                            foreach (var item in sortirano)
                                                Console.WriteLine($"{item.Key} ({item.Value.Item1}) - {item.Value.Item2}$ - {item.Value.Item3}");
                                            unos1 = 0;
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos14 == "f")
                                        {
                                            provjeraUnosa = true;
                                            
                                            Console.Clear();

                                            foreach (var item in racuni)
                                            {
                                                foreach (var item2 in item.Value.Item2)
                                                {
                                                    prodavnostArtikala[item2.Key] = prodavnostArtikala[item2.Key] + item2.Value;
                                                }
                                            }

                                            unos1 = 0;

                                            var sortirano = prodavnostArtikala.OrderBy(item => item.Value);
                                            foreach (var item in sortirano)
                                            {
                                                Console.WriteLine($"{item.Key} - {item.Value}");
                                                break;
                                            }
                                            
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos14 == "g")
                                        {
                                            provjeraUnosa = true;

                                            Console.Clear();

                                            foreach (var item in racuni)
                                            {
                                                foreach (var item2 in item.Value.Item2)
                                                {
                                                    prodavnostArtikala[item2.Key] = prodavnostArtikala[item2.Key] + item2.Value;
                                                }
                                            }

                                            unos1 = 0;

                                            var sortirano = prodavnostArtikala.OrderBy(item => item.Value);
                                            sortirano.Reverse();
                                            foreach (var item in sortirano)
                                            {
                                                Console.WriteLine($"{item.Key} - {item.Value}");
                                                break;
                                            }

                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);
                                    break;
                                case 0:
                                    break;
                                default:
                                    provjeraUnosa = false;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        int unos2 = 1;
                        while (unos2 != 0)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("1 - Unos radnika");
                                Console.WriteLine("2 - Brisanje radnika");
                                Console.WriteLine("3 - Uredivanje radnika");
                                Console.WriteLine("4 - Ispis");
                                Console.WriteLine("0 - Povratak na pocetni izbornik");
                                if (!provjeraUnosa)
                                {
                                    Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                }
                                provjeraUnosa = int.TryParse(Console.ReadLine(), out unos2);
                            } while (!provjeraUnosa);

                            string imeIPrezime;
                            DateTime datumRodenja;
                            switch (unos2)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Unesite ime i prezime novog radnika (Odvojeno razmakom):");
                                    imeIPrezime = Console.ReadLine();

                                    Console.Clear();
                                    Console.WriteLine("Unesite datum rodenja novog radnika (Godina mjesec dan):");
                                    datumRodenja = DateTime.Parse(Console.ReadLine());
                                    
                                    radnici.Add(imeIPrezime, datumRodenja);

                                    Console.Clear();
                                    Console.WriteLine("Uspjesno dodan radnik, pritisnite neku tipku za povratak na pocetni izbornik.");
                                    Console.ReadKey();
                                    unos2 = 0;

                                    break;
                                case 2:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Brisanje radnika:");
                                        Console.WriteLine("a - Po imenu");
                                        Console.WriteLine("b - Svih koji imaju vise od 65 godina");
                                        Console.WriteLine("0 - Povratak na pocetni izbornik");
                                        if (!provjeraUnosa)
                                        {
                                            Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                        }
                                        var unos22 = Console.ReadLine();

                                        if (unos22 == "0")
                                        {
                                            provjeraUnosa = true;
                                            unos2 = 0;
                                            break;
                                        }

                                        else if (unos22 == "a")
                                        {
                                            provjeraUnosa = true;
                                            do
                                            {
                                                Console.Clear();
                                                if (!provjeraUnosa)
                                                    Console.Write("Taj radnik ne postoji. ");
                                                Console.WriteLine("Unesite ime i prezime radnika kojeg zelite izbrisati ili 0 za povratak na pocetni izbornik:");
                                                imeIPrezime = Console.ReadLine();
                                                if (radnici.ContainsKey(imeIPrezime) || imeIPrezime == "0")
                                                {
                                                    provjeraUnosa = true;
                                                    break;
                                                }
                                                else
                                                    provjeraUnosa = false;
                                            } while (!provjeraUnosa);

                                            if (imeIPrezime == "0")
                                            {
                                                unos2 = 0;
                                                break;
                                            }

                                            Console.Clear();
                                            Console.WriteLine("Jeste li sigurni da zelite izbrisati ovog radnika (da/ne):");
                                            string potvrda = Console.ReadLine();
                                            
                                            Console.Clear();
                                            if (potvrda == "da")
                                            {
                                                radnici.Remove(imeIPrezime);
                                                Console.WriteLine("Uspjesno izbrisan radnik, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            }
                                            else
                                                Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                            unos2 = 0;
                                        }

                                        else if (unos22 == "b")
                                        {
                                            provjeraUnosa = true;

                                            Console.Clear();
                                            Console.WriteLine("Jeste li sigurni da zelite izbrisati sve radnike starije od 65 godina (da/ne):");
                                            string potvrda = Console.ReadLine();

                                            Console.Clear();
                                            if (potvrda == "da")
                                            {
                                                var list = new List<string>();

                                                foreach (var item in radnici)
                                                    if (DateTime.Now.Year - item.Value.Year - (DateTime.Now.Month - item.Value.Month == 0 ? (DateTime.Now.Day - item.Value.Day < 0 ? 1 : 0) : (DateTime.Now.Month - item.Value.Month > 0 ? 0 : 1)) > 65)
                                                        list.Add(item.Key);
                                                    else
                                                        list.Add("0");

                                                int pozicija = 0;
                                                foreach (var item in list)
                                                {
                                                    if (item != "0")
                                                        radnici.Remove(list[pozicija]);
                                                    pozicija++;
                                                }

                                                Console.WriteLine("Uspjesno izbrisan/i radnik/ci, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            }
                                            else
                                                Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                            unos2 = 0;
                                        }

                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);
                                    break;
                                case 3:
                                    provjeraUnosa = true;
                                    do
                                    {
                                        Console.Clear();
                                        if (!provjeraUnosa)
                                            Console.Write("Taj radnik ne postoji. ");
                                        Console.WriteLine("Unesite ime radnika kojeg zelite urediti ili 0 za povratak na pocetni izbornik:");
                                        imeIPrezime = Console.ReadLine();
                                        if (radnici.ContainsKey(imeIPrezime) || imeIPrezime == "0")
                                        {
                                            provjeraUnosa = true;
                                            break;
                                        }
                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);

                                    if (imeIPrezime == "0")
                                    {
                                        unos2 = 0;
                                        break;
                                    }

                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Sto zelite promijeniti:");
                                        Console.WriteLine("a - Ime i prezime");
                                        Console.WriteLine("b - Datum rodenja");
                                        Console.WriteLine("0 - Povratak na pocetni izbornik");
                                        if (!provjeraUnosa)
                                        {
                                            Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                        }
                                        var unos23 = Console.ReadLine();

                                        if (unos23 == "0")
                                        {
                                            provjeraUnosa = true;
                                            unos2 = 0;
                                            break;
                                        }

                                        else if (unos23 == "a")
                                        {
                                            provjeraUnosa = true;

                                            Console.Clear();
                                            Console.WriteLine("Unesite novo ime i prezime radnika ili 0 za povratak na pocetni izbornik:");
                                            string novoImeIPrezime = Console.ReadLine();

                                            if (novoImeIPrezime == "0")
                                            {
                                                unos2 = 0;
                                                break;
                                            }

                                            Console.Clear();
                                            Console.WriteLine("Jeste li sigurni da zelite promijeniti ime ovog radnika (da/ne):");
                                            string potvrda = Console.ReadLine();

                                            Console.Clear();
                                            if (potvrda == "da")
                                            {
                                                DateTime value = radnici[imeIPrezime];
                                                radnici.Remove(imeIPrezime);
                                                radnici.Add(novoImeIPrezime, value);
                                                Console.WriteLine("Uspjesno promijenjeno ime radnika, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            }

                                            else
                                                Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                            Console.ReadKey();
                                            unos2 = 0;
                                        }

                                        else if (unos23 == "b")
                                        {
                                            provjeraUnosa = true;

                                            Console.Clear();
                                            Console.WriteLine("Unesite novi datum rodenja radnika (Godina mjesec dan):");
                                            DateTime noviDatumRodenja = DateTime.Parse(Console.ReadLine());
                                            
                                            Console.Clear();
                                            Console.WriteLine("Jeste li sigurni da zelite promijeniti datum rodenja ovog radnika (da/ne):");
                                            string potvrda = Console.ReadLine();

                                            Console.Clear();
                                            if (potvrda == "da")
                                            {
                                                radnici[imeIPrezime] = noviDatumRodenja;
                                                Console.WriteLine("Uspjesno promijenjen datum rodenja radnika, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            }

                                            else
                                                Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                            Console.ReadKey();
                                            unos2 = 0;
                                        }

                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);

                                    break;
                                case 4:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ispis:");
                                        Console.WriteLine("a - Svih radnika");
                                        Console.WriteLine("b - Svih radnika kojima je rodendan u tekucem mjesecu");
                                        Console.WriteLine("0 - Povratak na pocetni izbornik");
                                        if (!provjeraUnosa)
                                        {
                                            Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                        }
                                        var unos24 = Console.ReadLine();

                                        if (unos24 == "0")
                                        {
                                            provjeraUnosa = true;
                                            unos2 = 0;
                                            break;
                                        }

                                        else if (unos24 == "a")
                                        {
                                            provjeraUnosa = true;
                                            Console.Clear();
                                            foreach (var item in radnici)
                                                Console.WriteLine($"{item.Key} - {DateTime.Now.Year - item.Value.Year - (DateTime.Now.Month - item.Value.Month == 0 ? (DateTime.Now.Day - item.Value.Day < 0 ? 1 : 0) : (DateTime.Now.Month - item.Value.Month > 0 ? 0 : 1))}");
                                            unos2 = 0;
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos24 == "b")
                                        {

                                        }

                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);
                                    break;
                                case 0:
                                    break;
                                default:
                                    provjeraUnosa = false;
                                    break;
                            }
                        }
                        break;
                    case 3:
                        int unos3 = 1;
                        while (unos3 != 0)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("1 - Unos novnog racuna");
                                Console.WriteLine("2 - Ispis");
                                Console.WriteLine("0 - Povratak na pocetni izbornik");
                                if (!provjeraUnosa)
                                {
                                    Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                }
                                provjeraUnosa = int.TryParse(Console.ReadLine(), out unos3);
                            } while (!provjeraUnosa);

                            var kosarica = new Dictionary<string, int>();

                            switch (unos3)
                            {
                                case 1:
                                    string odabirArtikla = "0", kopijaUnosa;
                                    int odabirKolicine;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Upisite ime od nekog proizvoda kako bi ste ga stavili u kosaricu ili 0 kako bi zavrsili kupnju:");
                                        foreach (var item in artikli)
                                            Console.WriteLine($"{item.Key}");
                                        kopijaUnosa = odabirArtikla;
                                        odabirArtikla = Console.ReadLine();

                                        if (odabirArtikla == "0")
                                        {
                                            unos3 = 0;
                                            break;
                                        }

                                        Console.Clear();
                                        Console.WriteLine("Upisite kolicinu koju bi ste stavili u kosaricu:");
                                        Console.WriteLine($"Dostupno - {artikli[odabirArtikla].Item1}");
                                        odabirKolicine = int.Parse(Console.ReadLine());

                                        kosarica.Add(odabirArtikla, odabirKolicine);

                                    } while (true);

                                    if (kopijaUnosa == "0")
                                    {
                                        unos3 = 0;
                                        break;
                                    }

                                    Console.Clear();
                                    foreach (var item in kosarica)
                                        Console.WriteLine($"{item.Key} - {item.Value}");
                                    Console.WriteLine("Jeste li sigurni da zelite potvrditi i printati ovaj racun (da/ne):");
                                    string potvrda = Console.ReadLine();

                                    Console.Clear();
                                    if (potvrda == "da")
                                    {
                                        double ukupnaCijena = 0d;
                                        foreach (var item in kosarica)
                                            ukupnaCijena += item.Value * artikli[item.Key].Item2;
                                        racuni.Add(br++, (DateTime.Now, kosarica, ukupnaCijena));

                                        foreach (var item in kosarica)
                                        {
                                            artikli[item.Key] = (artikli[item.Key].Item1 - item.Value, artikli[item.Key].Item2, artikli[item.Key].Item3);
                                            if (artikli[item.Key].Item1 <= 0)
                                                artikli.Remove(item.Key);
                                        }
                                        
                                        Console.WriteLine($"{br - 1} - {racuni[br - 1].Item1} - proizvodi:");
                                        foreach (var item in kosarica)
                                            Console.WriteLine($"{item.Key} - {item.Value}");
                                        Console.WriteLine($"Ukupna cijena - {racuni[br - 1].Item3}$");

                                        Console.WriteLine("Uspjesno isprintan racun, pritisnite neku tipku za povratak na pocetni izbornik.");
                                    }

                                    else
                                        Console.WriteLine("Akcija ponistena, pritisnite neku tipku za povratak na pocetni izbornik.");

                                    Console.ReadKey();

                                    break;
                                case 2:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ispis:");
                                        Console.WriteLine("a - Svih racuna");
                                        Console.WriteLine("b - Jednog racuna (Potreban id racuna)");
                                        Console.WriteLine("0 - Povratak na pocetni izbornik");
                                        if (!provjeraUnosa)
                                        {
                                            Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                        }
                                        var unos32 = Console.ReadLine();
                                        
                                        int id;

                                        if (unos32 == "0")
                                        {
                                            provjeraUnosa = true;
                                            unos3 = 0;
                                            break;
                                        }

                                        else if (unos32 == "a")
                                        {
                                            provjeraUnosa = true;
                                            unos3 = 0;
                                            Console.Clear();
                                            foreach (var item in racuni)
                                                Console.WriteLine($"{item.Key} - {item.Value.Item1} - {item.Value.Item3}$");
                                            Console.WriteLine("Pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else if (unos32 == "b")
                                        {
                                            provjeraUnosa = true;
                                            unos3 = 0;
                                            do
                                            {
                                                Console.Clear();
                                                if (!provjeraUnosa)
                                                    Console.Write("Taj racun ne postoji. ");
                                                Console.WriteLine("Unesite id racuna kojeg zelite ispisati ili 0 za povratak na pocetni izbornik:");
                                                id = int.Parse(Console.ReadLine());
                                                if (racuni.ContainsKey(id) || id == 0)
                                                {
                                                    provjeraUnosa = true;
                                                    break;
                                                }
                                                else
                                                    provjeraUnosa = false;
                                            } while (!provjeraUnosa);

                                            if (id == 0)
                                                break;

                                            Console.Clear();
                                            Console.WriteLine($"{id} - {racuni[id].Item1} - proizvodi:");
                                            foreach (var item in racuni[id].Item2)
                                                Console.WriteLine($"{item.Key} - {item.Value}");
                                            Console.WriteLine($"Ukupna cijena - {racuni[id].Item3}$");

                                            Console.WriteLine("Uspjesno isprintan racun, pritisnite neku tipku za povratak na pocetni izbornik.");
                                            Console.ReadKey();
                                        }

                                        else
                                            provjeraUnosa = false;
                                    } while (!provjeraUnosa);
                                    break;
                                case 0:
                                    break;
                                default:
                                    provjeraUnosa = false;
                                    break;
                            }
                        }
                        break;
                    case 4:
                        int unos4 = 1;
                        string sifra = "password";
                        do
                        {
                            Console.Clear();

                            if (sifra == "0")
                            {
                                unos4 = 0;
                                break;
                            }

                            if (sifra != "password")
                                Console.WriteLine("Kriva sifra, pokusajte ponovno ili upisite 0 za povratak na pocetni izbornik:");

                            else
                                Console.WriteLine("Unesite sifru kako bi nastavili ili upisite 0 za povratak na pocetni izbornik:");

                            sifra = Console.ReadLine();
                        } while (sifra != "password");

                        while (unos4 != 0)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("1 - Ukupan broj artikala u trgovini");
                                Console.WriteLine("2 - Vrijednost artikala koji nisu još prodani");
                                Console.WriteLine("3 - Vrijednost svih artikala koji su prodani");
                                Console.WriteLine("4 - Stanje po mjesecima");
                                Console.WriteLine("0 - Povratak na pocetni izbornik");
                                if (!provjeraUnosa)
                                {
                                    Console.WriteLine("Krivi unos, pokusajte ponovno:");
                                }
                                provjeraUnosa = int.TryParse(Console.ReadLine(), out unos4);
                            } while (!provjeraUnosa);

                            double suma = 0;
                            switch (unos4)
                            {
                                case 1:
                                    provjeraUnosa = true;

                                    Console.Clear();
                                    foreach (var item in artikli)
                                        suma += item.Value.Item1;

                                    Console.WriteLine($"Ukupan broj artikala u trgovini - {suma}");
                                    Console.WriteLine("Pritisnite neku tipku za povratak na prosli izbornik.");

                                    Console.ReadKey();
                                    break;
                                case 2:
                                    provjeraUnosa = true;

                                    Console.Clear();
                                    foreach (var item in artikli)
                                        suma += item.Value.Item1 * item.Value.Item2;

                                    Console.WriteLine($"Ukupna vrijednost artikala u trgovini - {suma}$");
                                    Console.WriteLine("Pritisnite neku tipku za povratak na prosli izbornik.");

                                    Console.ReadKey();
                                    break;
                                case 3:
                                    provjeraUnosa = true;
                                    
                                    Console.Clear();
                                    foreach (var item in racuni)
                                        suma += item.Value.Item3;
                                    
                                    Console.WriteLine($"Vrijednost svih artikala koji su prodani - {suma}$");
                                    Console.WriteLine("Pritisnite neku tipku za povratak na prosli izbornik.");

                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Unesite godinu i mjesec koji vas zanima:");
                                    DateTime mjesec = DateTime.Parse(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("Unesite ukupnu placu radnika:");
                                    int placaRadnika = int.Parse(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("Unesite ukupni trosak za taj mjesec:");
                                    int ostaliTroskovi = int.Parse(Console.ReadLine());

                                    double ukupnaZarada = 0;
                                    foreach (var item in racuni)
                                        if (mjesec.Year == item.Value.Item1.Year)
                                            if (mjesec.Month == item.Value.Item1.Month)
                                                ukupnaZarada += item.Value.Item3;

                                    double stanjeUMjesecu = (double)ukupnaZarada / 3d - (double)placaRadnika - (double)ostaliTroskovi;
                                    stanjeUMjesecu = Math.Round(stanjeUMjesecu, 2);
                                    Console.Clear();
                                    if (stanjeUMjesecu > 0)
                                        Console.WriteLine($"Trgovina je u tom mjesecu ukupno zaradila {stanjeUMjesecu}$");
                                    else
                                        Console.WriteLine($"Trgovina je u tom mjesecu ukupno izgubila {-stanjeUMjesecu}$");

                                    Console.WriteLine("Pritisnite neku tipku za povratak na prosli izbornik.");
                                    Console.ReadLine();
                                    break;
                                case 0:
                                    break;
                                default:
                                    provjeraUnosa = false;
                                    break;
                            }
                        }
                        break;
                    case 0:
                        break;
                    default:
                        provjeraUnosa = false;
                        break;
                }
            }
        }
    }
}
