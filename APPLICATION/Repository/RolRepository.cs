using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOMAIN.Entities;
using DOMAIN.Interfaces;
using Infrastructure.Repositories;
using PERSISTENCE.Data;

namespace APPLICATION.Repository;
public class RolRepository : GenericRepository<Rol> , IRolRepository
{
    private readonly EjercicioCapasContext _context;

    public RolRepository(EjercicioCapasContext context) : base(context)
    {
        _context = context;
    }
}
