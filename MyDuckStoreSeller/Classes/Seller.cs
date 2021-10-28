using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{
    public class Seller
    {
        public string SellerID { get; set; }
        public string SellerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Storage { get; set; }
        public string Password { get; set; }
        public string INN { get; set; }

        public Seller(string sellerID, string sellerName, string email, string phone, string adress, string storage, string password, string inn)
        {
            SellerID = sellerID;
            SellerName = sellerName;
            Email = email;
            Phone = phone;
            Adress = adress;
            Storage = storage;
            Password = password;
            INN = inn;
        }
    }
}
