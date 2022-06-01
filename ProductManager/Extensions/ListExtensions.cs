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
    }
}
