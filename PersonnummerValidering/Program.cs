using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Välkommen till Personnummerkontrollen!");
        Console.WriteLine("Skriv in ett svenskt personnummer (10 eller 12 siffror):");

        string personnummer = Console.ReadLine();

        if (PersonnummerValidering.PersonnummerValidator.ValideraPersonnummer(personnummer))
        {
            Console.WriteLine("Personnumret är giltigt!");
        }
        else
        {
            Console.WriteLine("Personnumret är ogiltigt!");
        }
    }
}
