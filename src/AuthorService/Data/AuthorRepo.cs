using LightNovelService.Models;
using Microsoft.EntityFrameworkCore;

namespace LightNovelService.Data
{
    public interface IAuthorRepo
    {
        Task<IEnumerable<Author>> GetAll();

        Task<Author?> GetById(int id);

        Task Add(Author entity);

        void Delete(Author author);

        Task<bool> SaveChangeAsync();
    }

    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;

        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.AddAsync(entity);
        }

        public void Delete(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Remove(entity);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var rs = await _context.Authors.ToListAsync();

            return rs;
        }

        public async Task<Author?> GetById(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}