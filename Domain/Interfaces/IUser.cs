using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;
public interface IUser
{
    Task<User> FindFirst(Expression<Func<User, bool>> expression);

    Task<IEnumerable<User>> GetAllAsync();
    // Task<IEnumerable<User>> GetAllAsync(IParam param);
    // Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> predicate, IParam param);    
    Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression);
    // Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression , IParam param);    
    void Add(User entity);
    void AddRange(IEnumerable<User> entities);
    void Remove(User entity);
    void RemoveRange(IEnumerable<User> entities);
    void Update(User entity);
    string GenerateRandomTwoSecret();
}