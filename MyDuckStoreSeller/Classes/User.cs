using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{
    public class User
    {
        public string UserID { get; set; }
        public string UserLogin { get; set; }
        public string UserFullName { get; set; }
        public string UserPass { get; set; }
        public string UserEmail { get; set; }
        public string UserAdress { get; set; }
        public string UserPhone { get; set; }

        public User(string UserID, string UserLogin, string UserFullName, string UserPass, string UserEmail, string UserAdress, string UserPhone)
        {
            this.UserID = UserID;
            this.UserLogin = UserLogin;
            this.UserFullName = UserFullName;
            this.UserPass = UserPass;
            this.UserEmail = UserEmail;
            this.UserAdress = UserAdress;
            this.UserPhone = UserPhone;
        }
    }

}
