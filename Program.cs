using System;
using System.IO;

namespace JopeFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter("textfil.txt", true);
            streamWriter.WriteLine("asd");
            PetOwner pets = new PetOwner(26);
            pets.Menu();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
