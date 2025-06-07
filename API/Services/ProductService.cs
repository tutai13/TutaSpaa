using API.Data;
using API.DTOs.Product;
using API.IService;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;

        public ProductService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            return await _context.Product
                .Select(p => new ProductDTO
                {
                    SanPhamId = p.ProductId,
                    TenSP = p.ProductName,
                    SoLuong = p.Quantity,
                    MoTa = p.Description,
                    Gia = p.Price,
                    HinhAnh = p.Images,
                    LoaiSanPhamId = p.CategoryId
                })
                .ToListAsync();
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return null;

            return new ProductDTO
            {
                SanPhamId = product.ProductId,
                TenSP = product.ProductName,
                SoLuong = product.Quantity,
                MoTa = product.Description,
                Gia = product.Price,
                HinhAnh = product.Images,
                LoaiSanPhamId = product.CategoryId
            };
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO dto)
        {
            var product = new Product
            {
                ProductName = dto.TenSP,
                Quantity = dto.SoLuong,
                Description = dto.MoTa,
                Price = dto.Gia,
                Images = dto.HinhAnh,
                CategoryId = dto.LoaiSanPhamId
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            dto.SanPhamId = product.ProductId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ProductDTO dto)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return false;

            product.ProductName = dto.TenSP;
            product.Quantity = dto.SoLuong;
            product.Description = dto.MoTa;
            product.Price = dto.Gia;
            product.Images = dto.HinhAnh;
            product.CategoryId = dto.LoaiSanPhamId;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return false;

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
