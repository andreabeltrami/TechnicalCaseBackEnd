namespace BackEnd.Interfaces
{
    public interface IRepository<TDto, TKey>
    {
        public Task<IEnumerable<TDto>> GetAllAsync();

        public Task<TDto> GetByKey(TKey key);

        public Task<TDto> UpdateAsync(TDto input);

        public Task<TDto> CreateAsync(TDto input);

    }
}
