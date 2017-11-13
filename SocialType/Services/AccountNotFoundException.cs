using System;

namespace SocialType.Services
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException()
        {
            Console.WriteLine("account does not exist");
        }

        public AccountNotFoundException(String message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}