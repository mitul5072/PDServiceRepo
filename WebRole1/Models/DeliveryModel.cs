using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class DeliveryModel
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }
    }
}