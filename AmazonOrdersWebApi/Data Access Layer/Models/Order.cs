﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Data_Access_Layer.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? Cost { get; set; }
        public int ItemQty { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AmazonId { get; set; }

        public virtual Amazon Amazon { get; set; }
    }
}
