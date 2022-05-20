using System.Collections.Generic;

namespace ProductManager.Repository.Models
{
    internal class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public List<User> Users { get; set; }
    }
}
