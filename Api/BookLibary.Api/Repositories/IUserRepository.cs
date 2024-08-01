namespace BookLibary.Api.Repositories
{
    public interface IUserRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByNameAsync(string userName);
    }
}
