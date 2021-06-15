using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string PrmoductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public DateTimeOffset ExpiryDate { get; set; }
    }
}