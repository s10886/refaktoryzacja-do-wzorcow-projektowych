using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringToDesignPatterns.CH06_NetDesignPatterns.Zadania
{
    class Program
    {
        static void Main(string[] args)
        {
            var vault1 = Vault.GetInstance();
            Console.WriteLine(vault1.GetAccessKey());

            //próba ponownego pobrania klucza
            try
            {
                Console.WriteLine(vault1.GetAccessKey());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            var vault2 = Vault.GetInstance();
            Console.WriteLine($"To ten sam obiekt??? {object.ReferenceEquals(vault1, vault2)}");
        }
    }
}
