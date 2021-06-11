using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Model
{
    public class Role : IdentityRole
    {
        public ICollection<Permission> Permissions { get; set; }
    }
}
