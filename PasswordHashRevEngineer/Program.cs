using System;

namespace PasswordHashRevEngineer
{
    class Program
    {
        static void Main(string[] args)
        {
            string keySalt = "FCSD";

            PasswordHashGen pHG = new PasswordHashGen();
            Console.Write("Enter string to hash: ");
            string textToHash = Console.ReadLine();
            Console.WriteLine(pHG.getHash(textToHash, keySalt));
            // Console.WriteLine(PasswordHashGen.PasswordHash("OluwaremiEO","SN027053"));
        }
    }
}
