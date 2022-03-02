using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPrueba1DD.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductInventory { get; set; }
        public string ProductExpiration { get; set; }
        public string ProductRegistered { get; set; }

        public static string reformatDate(DateTime dateTime) 
        {
            return dateTime.ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}