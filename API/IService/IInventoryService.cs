using API.DTOs.Product;

namespace API.IService
{
	public interface IInventoryService
	{
		Task<bool> ImportAsync(InventoryActionDTO dto);
		Task<bool> ExportAsync(InventoryActionDTO dto);
	}
}
