using SingletonVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringToDesignPatterns.CH06_NetDesignPatterns.Zadania
{
    public class Vault
    {
        private static Vault _instance;

        private static readonly object _lock = new object();

        private Vault()
        {
            _accessKey = GenerateKey();
        }

        private readonly string _accessKey;
        private bool _keyReturned = false;


        public static Vault GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Vault();
                }
                return _instance;
            }
        }

        //klucz tylko raz
        public string GetAccessKey()
        {
            if (_keyReturned)
                throw new InvalidOperationException("The key was already downloaded");

            _keyReturned = true;
            return _accessKey;
        }

        private string GenerateKey()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }
    }
}
