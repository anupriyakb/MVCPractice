using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Product 
    {
        [Key]
        public  int ProductID { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity  { get; set; }
        [Required]
        public int Price { get; set; }


        public   Category Category{ get; set; }

    }
}



