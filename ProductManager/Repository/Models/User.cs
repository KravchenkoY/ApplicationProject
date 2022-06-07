using System.Collections.Generic;

namespace ProductManager.Repository.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public List<OrderHeader> OrderHeaders { get; set; }

    }
}
