﻿using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Services
{
    public class AccountManager
    {
        Lazy<MyDbContext> db = new Lazy<MyDbContext>();


        public String getPassword(String userName)
        {
            UserAccount user = db.Value.UserAccount.SingleOrDefault(u => u.Username == userName);
            if (user == null)
            {
                throw new AccountNotFoundException();
            } 
            return user.Password;
        }

        public void changePassword(String userName, String newPassword)
        {
            UserAccount user = db.Value.UserAccount.SingleOrDefault(u => u.Username == userName);
            if(user == null)
            {
                throw new AccountNotFoundException();
            }
            user.Password = newPassword;
            db.Value.SaveChanges();
        }


        public Boolean isPasswordSecure(String password)
        {
            if(password.Length >= 5)
            {
                return true;
            }
            return false;
        }
    }
}