using System;
using System.Collections.Generic;

namespace DrugMApi.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int PurchaseId { get; set; }
        public int? TotalAmount { get; set; }
        public DateTime? DateofPurchase { get; set; }
        public string? PaymentMode { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
