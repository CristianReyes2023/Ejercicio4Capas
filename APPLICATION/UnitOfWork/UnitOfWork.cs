using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPLICATION.Repository;
using DOMAIN.Interfaces;
using PERSISTENCE.Data;

namespace APPLICATION.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{

    private IRolRepository _rols;
    private IUserRepository _users;

    private readonly EjercicioCapasContext _context;

    public UnitOfWork(EjercicioCapasContext context)
    {
        _context = context;
    }
    public IRolRepository Rol
    {
        get
        {
            if (_rols == null)
            {
                _rols = new RolRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _rols;
        }
    }
    public IUserRepository User
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _users;
        }
    }


    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}