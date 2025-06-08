using API.Data;
using API.DTOs.Product;
using API.IService;
using API.Models;

namespace API.Services
{
	public class InventoryService : IInventoryService
	{
		private readonly ApplicationDBContext _context;

		public InventoryService(ApplicationDBContext context)
		{
			_context = context;
		}

		public async Task<bool> ImportAsync(InventoryActionDTO dto)
		{
			var product = await _context.Product.FindAsync(dto.ProductId);
			if (product == null) return false;

			product.Quantity += dto.QuantityChanged;

			var history = new InventoryHistory
			{
				ProductId = dto.ProductId,
				QuantityChanged = dto.QuantityChanged,
				ActionType = "Import",
				Note = dto.Note,
				Timestamp = DateTime.Now
			};

			_context.InventoryHistories.Add(history);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> ExportAsync(InventoryActionDTO dto)
		{
			var product = await _context.Product.FindAsync(dto.ProductId);
			if (product == null) return false;

			if (product.Quantity < dto.QuantityChanged) return false;

			product.Quantity -= dto.QuantityChanged;

			var history = new InventoryHistory
			{
				ProductId = dto.ProductId,
				QuantityChanged = -dto.QuantityChanged,
				ActionType = "Export",
				Note = dto.Note,
				Timestamp = DateTime.Now
			};

			_context.InventoryHistories.Add(history);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
