using API.Data;
using API.DTOs.Product;
using API.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InventoryController : ControllerBase
    {
		private readonly IInventoryService _inventoryService;
		private readonly ApplicationDBContext _context;

		

		[HttpPost("import")]
		public async Task<IActionResult> Import([FromBody] InventoryActionDTO dto)
		{
			var result = await _inventoryService.ImportAsync(dto);
			if (!result) return BadRequest("Nhập hàng thất bại. Kiểm tra lại thông tin.");

			return Ok("Nhập hàng thành công.");
		}

		[HttpPost("export")]
		public async Task<IActionResult> Export([FromBody] InventoryActionDTO dto)
		{
			var result = await _inventoryService.ExportAsync(dto);
			if (!result) return BadRequest("Xuất hàng thất bại. Kiểm tra số lượng tồn kho.");

			return Ok("Xuất hàng thành công.");
		}
		public InventoryController(IInventoryService inventoryService, ApplicationDBContext context)
		{
			_inventoryService = inventoryService;
			_context = context;
		}
		[HttpGet("history")]
		public async Task<IActionResult> GetHistory()
		{
			var history = await _context.InventoryHistories
				.Include(x => x.Product)
				.OrderByDescending(x => x.Timestamp)
				.ToListAsync();

			return Ok(history);
		}
	}
}
