using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Välkommen till Personnummerkontrollen!");
        Console.WriteLine("Skriv in ett svenskt personnummer (10 eller 12 siffror):");

        string personnummer = Console.ReadLine();

        if (ValideraPersonnummer(personnummer))
        {
            Console.WriteLine("Personnumret är giltigt!");
        }
        else
        {
            Console.WriteLine("Personnumret är ogiltigt!");
        }
    }

    static bool ValideraPersonnummer(string personnummer)
    {
        // Rensa bort bindestreck eller mellanslag
        personnummer = personnummer.Replace("-", "").Replace(" ", "");

        // Kontrollera längden (10 eller 12 siffror)
        if (personnummer.Length == 12)
        {
            // Ta bort de två första siffrorna om det är ett 12-siffrigt personnummer
            personnummer = personnummer.Substring(2);
        }

        if (personnummer.Length != 10)
        {
            return false;
        }

        // Kontrollera att det bara innehåller siffror
        foreach (char c in personnummer)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        // Kontrollera födelsedatum
        string födelsedatum = personnummer.Substring(0, 6);
        if (!ÄrGiltigtDatum(födelsedatum))
        {
            return false;
        }

        // Kontrollera checksiffran med Luhn-algoritmen
        return KontrolleraLuhn(personnummer);
    }

    static bool ÄrGiltigtDatum(string datum)
    {
        // Försök att parsa datumet till ett giltigt datum
        try
        {
            int år = int.Parse(datum.Substring(0, 2)) + 1900; // Anta 1900-talet
            int månad = int.Parse(datum.Substring(2, 2));
            int dag = int.Parse(datum.Substring(4, 2));

            DateTime parsedDatum = new DateTime(år, månad, dag);
            return true;
        }
        catch
        {
            return false;
        }
    }

    static bool KontrolleraLuhn(string personnummer)
    {
        int summa = 0;

        for (int i = 0; i < personnummer.Length - 1; i++)
        {
            int siffra = int.Parse(personnummer[i].ToString());

            // Multiplicera varannan siffra med 2
            if (i % 2 == 0)
            {
                siffra *= 2;

                // Om resultatet är tvåsiffrigt, addera siffrorna
                if (siffra > 9)
                {
                    siffra -= 9;
                }
            }

            summa += siffra;
        }

        // Hämta sista siffran i personnumret (checksiffran)
        int checksiffra = int.Parse(personnummer[personnummer.Length - 1].ToString());

        // Kontrollera om summan plus checksiffran är delbart med 10
        return (summa + checksiffra) % 10 == 0;
    }
}
