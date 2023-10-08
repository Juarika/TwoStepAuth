using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class UserRepository : IUser
{
    private readonly TwoStepAuthContext _context;

    public UserRepository(TwoStepAuthContext context)
    {
        _context = context;
    }

    protected virtual async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> expression = null)
    {
        if (expression is not null)
        {
            return await _context.Set<User>().Where(expression).ToListAsync();
        }
        return await _context.Set<User>().ToListAsync();
    }
    public async virtual Task<User> FindFirst(Expression<Func<User, bool>> expression)
    {
        if (expression != null)
        {
            var rst = await _context.Set<User>().Where(expression).ToListAsync();
            return rst.First();
        }
        return await _context.Set<User>().FirstAsync();
    }
    public virtual void Add(User entity)
    {
        entity.TwoSecret = GenerateRandomTwoSecret();
        _context.Set<User>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<User> entities)
    {
        _context.Set<User>().AddRange(entities);
    }
    public virtual IEnumerable<User> Find(Expression<Func<User, bool>> expression)
    {
        return _context.Set<User>().Where(expression);
    }
    public virtual async Task<User> GetByIdAsync(int id)
    {
        return await _context.Set<User>().FindAsync(id);
    }
    public void Remove(User entity)
    {
        _context.Set<User>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<User> entities)
    {
        _context.Set<User>().RemoveRange(entities);
    }
    public void Update(User entity)
    {
        _context.Set<User>().Update(entity);
    }
    public virtual async Task<IEnumerable<User>> GetAllAsync() => await GetAll();
    public virtual async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression) => await GetAll(expression);
    public virtual string GenerateRandomTwoSecret()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000);
            return randomNumber.ToString();
        }
}