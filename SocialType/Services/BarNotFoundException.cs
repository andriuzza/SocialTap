using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace SocialType.Services
{
    public class BarNotFoundException : Exception
    {
        public BarNotFoundException(string message) : base(message)
        {     
                MessageBox.Show(message);
        }
    }
}