namespace FunctionsDemo.Infrastructure
{
    public interface IRepository<T>
    {
        public Task AddAsync(T item);
        public Task UpdateAsync(T item);
        public Task Remove(T item);
    }
}