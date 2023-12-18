namespace BackEnd.Interfaces
{
    public interface IRepository<TDto>
    {
        public Task<IEnumerable<TDto>> GetAllAsync();

        public Task<TDto> UpdateAsync(TDto input);

        public Task<TDto> CreateAsync(TDto input);

    }
}
