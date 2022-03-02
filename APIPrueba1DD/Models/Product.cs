using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIPrueba1DD.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [StringLength(150)]
        [Required(AllowEmptyStrings = false)]
        public string ProductName { get; set; }
        [Required]
        public int ProductInventory { get; set; }
        [Required]
        public string ProductExpiration { get; set; }
        public string ProductRegistered { get; set; }

        public static string reformatDate(DateTime dateTime) 
        {
            return dateTime.ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}