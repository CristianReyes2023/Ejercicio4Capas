using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PERSISTENCE.Data;
public class EjercicioCapasContext : DbContext
{
    public EjercicioCapasContext(DbContextOptions options) : base(options)
    {
    }
}
