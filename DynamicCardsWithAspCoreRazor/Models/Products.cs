using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicCardsWithAspCoreRazor.Models
{
    public class Products
    {
        private int productID;
        private string productName;
        private string productDesc;
        private float productPrice;
        private string productImage;

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductDesc { get => productDesc; set => productDesc = value; }
        public float ProductPrice { get => productPrice; set => productPrice = value; }
        public string ProductImage { get => productImage; set => productImage = value; }
    }
}
