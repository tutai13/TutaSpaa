namespace API.DTOs.Product
{
	public class InventoryActionDTO
	{
		public int ProductId { get; set; }
		public int QuantityChanged { get; set; } // luôn truyền số dương
		public string Note { get; set; }
	}
}
