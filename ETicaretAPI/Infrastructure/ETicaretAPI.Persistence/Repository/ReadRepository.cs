﻿namespace ETicaretAPI.Persistence.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
            => await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
    }
}