using System;
using System.Collections.Generic;

namespace DrugMApi.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail1s = new HashSet<OrderDetail1>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? MfdDate { get; set; }
        public string? ExpDate { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<OrderDetail1> OrderDetail1s { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
