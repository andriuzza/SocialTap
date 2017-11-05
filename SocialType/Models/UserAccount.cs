using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SocialType.Models
{
    public class UserAccount : UserAccounts
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "email is required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public String Username { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public ICollection<NotificationUser> Notifications {get;set;}

        public UserAccount()
        {
            Notifications = new Collection<NotificationUser>();
        }
      

       
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