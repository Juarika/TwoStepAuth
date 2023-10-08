using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TwoStepAuthContext context;

    private UserRepository _user;
    public UnitOfWork(TwoStepAuthContext _context)
    {
        context = _context;
    }
    public IUser Users
    {
        get
        {
            if (_user == null)
            {
                _user = new UserRepository(context);
            }
            return _user;
        }
    }
    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

}