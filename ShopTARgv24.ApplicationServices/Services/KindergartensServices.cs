using Microsoft.EntityFrameworkCore;
using ShopTARgv24_Ksenia.Core.Domain;
using ShopTARgv24_Ksenia.Core.Dto;
using ShopTARgv24_Ksenia.Core.ServiceInterface;
using ShopTARgv24_Ksenia.Data;

namespace ShopTARgv24_Ksenia.ApplicationServices.Services
{
    public class KindergartensServices : IKindergartensServices
    {
        private readonly ShopContext _context;

        public KindergartensServices(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Kindergarten>> GetAllAsync() =>
            await _context.Kindergartens.ToListAsync();

        public async Task<Kindergarten?> GetByIdAsync(Guid id) =>
            await _context.Kindergartens.FindAsync(id);

        public async Task<Kindergarten> CreateAsync(Kindergarten kindergarten)
        {
            _context.Kindergartens.Add(kindergarten);
            await _context.SaveChangesAsync();
            return kindergarten;
        }

        public async Task<Kindergarten?> UpdateAsync(Kindergarten kindergarten)
        {
            var existing = await _context.Kindergartens.FindAsync(kindergarten.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(kindergarten);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Kindergarten?> DeleteAsync(Guid id)
        {
            var existing = await _context.Kindergartens.FindAsync(id);
            if (existing == null) return null;

            _context.Kindergartens.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public Task<Kindergarten> Create(KindergartenDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Kindergarten> DetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Kindergarten> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Kindergarten> Update(KindergartenDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
