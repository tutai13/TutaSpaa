using API.Data;
using API.DTOs.Product;
using API.IService;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _context;

        public CategoryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            return await _context.Categorys
                .Select(c => new CategoryDTO
                {
                    LoaiSanPhamId = c.CategoryId,
                    TenLoai = c.CategoryName
                }).ToListAsync();
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _context.Categorys.FindAsync(id);
            if (category == null) return null;

            return new CategoryDTO
            {
                LoaiSanPhamId = category.CategoryId,
                TenLoai = category.CategoryName
            };
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO dto)
        {
            var category = new Category
            {
                CategoryName = dto.TenLoai
            };

            _context.Categorys.Add(category);
            await _context.SaveChangesAsync();

            dto.LoaiSanPhamId = category.CategoryId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, CategoryDTO dto)
        {
            var category = await _context.Categorys.FindAsync(id);
            if (category == null) return false;

            category.CategoryName = dto.TenLoai;
            _context.Categorys.Update(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categorys.FindAsync(id);
            if (category == null) return false;

            _context.Categorys.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
