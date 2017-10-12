﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace SocialType.Models
{
    public class UserAccount: UserAccounts
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public String Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }       
    }
    public class UserAccounts : IEnumerable
    {
        List<UserAccount> acc = new List<UserAccount>();
        int current = 0;
        public IEnumerator GetEnumerator()
        {
            return acc.GetEnumerator();
        }

        public void Add(UserAccount a)
        {
            acc.Add(a);
        }

        public bool MoveNext()
        {
            if (acc.Count == 0 || acc.Count <= current)
            {
                return false;
            }
            return true;
        }
    }
}