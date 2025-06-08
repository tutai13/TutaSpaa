using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class InventoryHistory
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public Product Product { get; set; }

		[Required]
		public int QuantityChanged { get; set; } // + nhập, - xuất

		[Required]
		public DateTime Timestamp { get; set; } = DateTime.Now;

		[Required]
		[StringLength(100)]
		public string ActionType { get; set; } // "Import" | "Export"

		public string Note { get; set; }
	}
}
