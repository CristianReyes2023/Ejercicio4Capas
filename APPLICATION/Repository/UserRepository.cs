using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOMAIN.Entities;
using DOMAIN.Interfaces;
using Infrastructure.Repositories;
using PERSISTENCE.Data;

namespace APPLICATION.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly EjercicioCapasContext _context;

    public UserRepository(EjercicioCapasContext context) : base(context)
    {
        _context = context;
    }
}