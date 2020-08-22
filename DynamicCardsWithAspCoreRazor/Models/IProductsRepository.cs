using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicCardsWithAspCoreRazor.Models
{
   public interface IProductsRepository
    {
        IEnumerable<Products> GetAllProducts();
    }
}
