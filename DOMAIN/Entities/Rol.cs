using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DOMAIN.Entities;
public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<UserRol> UserRols { get; set; }
}
