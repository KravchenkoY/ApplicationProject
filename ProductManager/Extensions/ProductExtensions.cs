using ProductManager.Repository.Models;
using ProductManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Extensions
{
    internal static class ProductExtensions
    {
        public static ProductViewModel ToViewModel(this Product model)
        {
            return new ProductViewModel
            {
                Name = model.Name,
                Brand = model.Brand,
                Id = model.Id,
                PartnerName = model.Partner.Name,
                Price = model.Price,
                ProductType = model.ProductType,
                Quantity = model.Quantity,
            };
        }
    }
}
