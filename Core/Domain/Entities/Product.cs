using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {

        }
        public Product(string Title, string Description , int BrandId , decimal Price , decimal Discount)
        {
            this.Title = Title;
            this.Description = Description;
            this.BrandId = BrandId;
            this.Price = Price;
            this.Discount = Discount;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        //public required string ImagePath { get; set; }
        public int BrandId{ get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> ProductCategories{ get; set; }
    }
}
