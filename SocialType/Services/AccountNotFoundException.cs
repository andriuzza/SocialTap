using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace SocialType.Services
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException()
        {
            MessageBox.Show("account does not exist");
        }

        public AccountNotFoundException(String message) : base(message)
        {
            MessageBox.Show(message);
        }
    }
}