using ProductManager.Repository.Models;
using ProductManager.ViewModels;

namespace ProductManager.Extensions
{
    internal static class PartnerExtensions
    {
        public static PartnerViewModel ToViewModel(this Partner model)
        {
            return new PartnerViewModel
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone,
                Country = model.Country,
                City = model.City,
                PostalCode = model.PostalCode,
                Address = model.Address,
                PartnerTypeName = model.PartnerType.Name
            };
        }
    }
}
