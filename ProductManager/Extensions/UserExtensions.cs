using ProductManager.Repository.Models;
using ProductManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Extensions
{
    internal static class UserExtensions
    {
        public static UserViewModel ToViewModel(this User model)
        {
            return new UserViewModel
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Password = model.Password,
                Email = model.Email,
                UserRoleName = model.UserRole.Name
            };
        }
    }
}
