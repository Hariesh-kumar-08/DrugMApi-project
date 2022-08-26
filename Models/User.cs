using System;
using System.Collections.Generic;

namespace DrugMApi.Models
{
    public partial class User
    {
        public User()
        {
            Buyers = new HashSet<Buyer>();
            OrderDetail1s = new HashSet<OrderDetail1>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Loc { get; set; }
        public string? UserPassword { get; set; }

        public virtual ICollection<Buyer> Buyers { get; set; }
        public virtual ICollection<OrderDetail1> OrderDetail1s { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
