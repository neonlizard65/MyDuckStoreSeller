using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDuckStoreSeller.Classes
{

    public class OrderList
    {
        public List<Order> order { get; set; }
    }

    public class Order
    {
        public string OrderID { get; set; }
        public string UserId { get; set; }
        public string InstanceId { get; set; }
        public string DateOfPurchase { get; set; }
        public string Price { get; set; }

        public Order(string OrderID, string UserId, string InstanceId, string DateOfPurchase, string Price)
        {
            this.OrderID = OrderID;
            this.UserId = UserId;
            this.InstanceId = InstanceId;
            this.DateOfPurchase = DateOfPurchase;
            this.Price = Price;
        }
    }

}
