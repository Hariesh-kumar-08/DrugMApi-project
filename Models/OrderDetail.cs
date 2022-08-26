using System;
using System.Collections.Generic;

namespace DrugMApi.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? PurchaseId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Buyer? Purchase { get; set; }
        public virtual User? User { get; set; }
    }
}
