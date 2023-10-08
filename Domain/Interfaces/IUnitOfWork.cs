namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IUser Users { get; }
    Task<int> SaveAsync();
}