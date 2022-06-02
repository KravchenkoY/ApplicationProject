using ProductManager.Repository.Models;
using ProductManager.ViewModels;
using System.Collections.Generic;

namespace ProductManager.Extensions
{
    internal static class ListExtensions
    {
        internal static List<PartnerViewModel> ToViewModelList(this List<Partner> input)
        {
            var list = new List<PartnerViewModel>();
            foreach (var partner in input)
            {
                list.Add(partner.ToViewModel());
            }
            return list;
        }
        internal static List<UserViewModel> ToViewModelList(this List<User> input)
        {
            var userList = new List<UserViewModel>();
            foreach (var user in input)
            {
                userList.Add(user.ToViewModel());
            }
            return userList;
        }
        internal static List<ProductViewModel> ToViewModelList(this List<Product> input)
        {
            var productList = new List<ProductViewModel>();
            foreach (var product in input)
            {
                productList.Add(product.ToViewModel());
            }
            return productList;
        }
    }
}
