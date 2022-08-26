using System;
using System.Collections.Generic;

namespace DrugMApi.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string? AdminName { get; set; }
        public string? AdminPassword { get; set; }
    }
}
