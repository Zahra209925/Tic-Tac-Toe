using System;

namespace TICTAKTOE
{
    class Program
    {
        // pelilauta on 3x3 merkkitaulukko
        // pelilauta, 9,ruutua (3x3)
        static char[,] pelilauta ={
        { '1','2','3' },
        { '4', '5', '6'},
        { '7','8', '9' }
       };
        // pelaaja, joka on vuorossa (0 = x, 1 = 0)
        // Muuttuja joka seuraa nykyisestä pelaajaa ('x' tai 'o')
        static char pelaaja = 'x';

        static void Main(string[] args) // alustetaan pelilauta
        {
            int siirrot = 0;  // pelaajan siirto
            bool peliKaynnissa = true;
            // pääpelisilmukka
            while (peliKaynnissa)
            {
                Console.Clear(); // Tyhjennetään konsoli ennen seuraavaa vuoroa
                NaytaPelilauta(); // Näytetään pelilauta
                Console.WriteLine($"\nPelaaja {pelaaja}, valitse ruutu (1-9): ");
                string valinta = Console.ReadLine();
                if (TeeSiirto(valinta)) // Tarkistetaan onko voittaja 
                {
                    siirrot++;  // Lisätään siirtojen laskuriin
                    // Tarkistetaan onko peli päättynyt voittoon
                    if (TarkistaVoitto())
                    {
                        Console.Clear();
                        NaytaPelilauta();
                        Console.WriteLine($"\nPelaaja {pelaaja} voitti pelin!");
                        peliKaynnissa = false;
                    }
                    else if (siirrot >= 9) // jos siirrot ovat täynnä ja ei ole voittajaa, peli päättyy tasapelin
                    {
                        Console.Clear();
                        NaytaPelilauta();
                        Console.WriteLine("\nTasapeli!");
                        // peli päättyy voittajaan
                        peliKaynnissa = false; // lopetetaan peli
                    }
                    else
                    {
                        // vaihdetaan vuoroa
                        VaihdaPelaaja();
                    }
                }
                else
                {
                    // Virheellinen valinta ( syöte ei ole numero 1-9tai ruutu on jo varattu)
                    Console.WriteLine("Virheellinen valinta, yritä uudelleen.");
                    // Odotetaan, että pelaaja lukee virheilmoituksen
                    Console.ReadKey();
                }
            }
        }
        // pelilauta piirtäminen konsolle
        static void NaytaPelilauta()
        {
            Console.WriteLine($" {pelilauta[0, 0]} | {pelilauta[0, 1]} | {pelilauta[0, 2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {pelilauta[1, 0]} | {pelilauta[1, 1]} | {pelilauta[1, 2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {pelilauta[2, 0]} | {pelilauta[2, 1]} | {pelilauta[2, 2]} ");
        }

        // Siirron tekeminen pelilautaan
        static bool TeeSiirto(string valinta)
        {
            int ruutu;
            // Tarkistetaan , että syöte on numero ja se on kelvollinen (1-9)
            if (int.TryParse(valinta, out ruutu) && ruutu >= 1 && ruutu <= 9)
            {
                int rivi = (ruutu - 1) / 3; // Määritetään rivi (0, 1, 2)
                int sarake = (ruutu - 1) % 3; // Määritetään sarake (0, 1, 2)

                // Tarkistetaan onko ruutu tyhjä
                if (pelilauta[rivi, sarake] != 'X' && pelilauta[rivi, sarake] != 'O')
                {
                    // Asetetaan pelaajan merkki (x tai 0 valttuun ruutuun)
                    pelilauta[rivi, sarake] = pelaaja;
                    return true; // siirto onnistui
                }
            }
            return false;  // jos epäooistui ( seim. ruutu varattu tai virheellinen syöte)
        }

        static void VaihdaPelaaja()  // Vaihdetaan pelaajaa
        {
            // Vaihdetaan vuoroa, jos pelaaja oli x, vaihdetaan 0:kasi ja päinvastoin
            pelaaja = (pelaaja == 'X') ? 'O' : 'X'; // Asetetaan pelaajan merkki
        }


        static bool TarkistaVoitto()  // Tarkistaa, onko jollain pelaajalla voittokombo
        {
            // Tarkistetaan Rivit, Sarakkeet ja Lävistäjät
            for (int i = 0; i < 3; i++) // käydään kaikki voittolinjat läpi
            {
                if (pelilauta[i, 0] == pelaaja && pelilauta[i, 1] == pelaaja && pelilauta[i, 2] == pelaaja)
                    return true;
                if (pelilauta[0, i] == pelaaja && pelilauta[1, i] == pelaaja && pelilauta[2, i] == pelaaja)
                    return true;
            }
            // Tarkistetaan lävistäjät
            if (pelilauta[0, 0] == pelaaja && pelilauta[1, 1] == pelaaja && pelilauta[2, 2] == pelaaja)
                // Lävitäjä 1
                return true; // Jos löydetään voittava kombinnaatio, palautetaan true

            if (pelilauta[0, 2] == pelaaja && pelilauta[1, 1] == pelaaja && pelilauta[2, 0] == pelaaja)
                // Lävistäjä 2
                return true;
            // jos ei vottokomboa,palautetaan false
            return false; // Ei voittajaa tai tasapeliä
        }

        /* Tämä koodi on kirjoittanut Zahra Nabavi.*/
        /// <author> Zahra Nabavi </author>
        /// <date>18.12.2024</date>
        /// <param name="Zahra Nabavi"></param>
        public void AddUser(String name)
        {
            Console.WriteLine($"Käyttäjä {name} on lisätty.");
        }
    }
}
