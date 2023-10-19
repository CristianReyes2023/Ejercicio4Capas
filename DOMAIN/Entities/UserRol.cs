using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOMAIN.Entities;
public class UserRol
{
    public int UsarioId { get; set; }
    public User Usario { get; set; }
    public int RolId { get; set; }
    public Rol Rols { get; set; }
}
